using HarmonyLib;
using System;
using UnityEngine;


// Patches The mainMenu.
namespace MyHarmonyPatches
{
    [HarmonyPatch(typeof(XUiC_MainMenu))]
    [HarmonyPatch("OnOpen")]
    public class SampleProjectMainMenuHarmonyPatch
    {
        // __instance is type is always the class you are patching
        static void Postfix(XUiC_MainMenu __instance)
        {
            Debug.Log("SampleProject(): XUiC_MainMenu.OnOpen()");
        }
    }

    /* This class includes a Harmony patch to allow particles to be loaded from any blocks.
    * 
    * Usage XML: 
    *
    * Adding to new blocks:
    *   	<property name="ParticleName" value="#@modfolder(0-SphereIICore):Resources/PathSmoke.unity3d?P_PathSmoke_X"/>
    *
    */
    [HarmonyPatch(typeof(Block))]
    [HarmonyPatch("Init")]
    public class SampleProject_Block_Init
    {
        // Postfix happens after all Prefix and the target method runs.
        public static void Postfix(Block __instance)
        {
            // We use __instance to access the methods and properties.
            if (__instance.Properties.Values.ContainsKey("ParticleName"))
            {
                String strParticleName = __instance.Properties.Values["ParticleName"];
                if (!ParticleEffect.IsAvailable(strParticleName))
                    ParticleEffect.RegisterBundleParticleEffect(strParticleName);
            }
            if (__instance is BlockDoorSecure)
                return;
        }
    }

    // More complicated example.
    [HarmonyPatch(typeof(BlockSecureLoot))]
    [HarmonyPatch("OnBlockActivated")]

    // Since more than OnBlockActivated() exists in the class, with different parameters, we must explicitly declare the parameters type to help Harmony find the right one. 
    [HarmonyPatch(new Type[] { typeof(int), typeof(WorldBase), typeof(int), typeof(Vector3i), typeof(BlockValue), typeof(EntityPlayer) })]
    public class SSampleProjectBlockSecureLoot
    {
        // Prefixes occur before the target method is run, so we can make changes.
        // We don't need to declare all the parameters here, only the onces you want to access.
        // Notice the ___lockPickItem? lockPickItem is a private variable for this class. If we want to access it, we use three underscores. This tells Harmony that it's a private variable of the class.
        public static bool Prefix(Block __instance, int _indexInBlockActivationCommands, WorldBase _world, int _cIdx, Vector3i _blockPos, BlockValue _blockValue, EntityAlive _player
            , string ___lockPickItem)
        {

            Debug.Log("SampleProject() BlockSecureLoot On Block Activated() " + __instance.GetBlockName());
            return true;
        }
    }
}