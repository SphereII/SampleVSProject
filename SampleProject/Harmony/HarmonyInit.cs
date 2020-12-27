using HarmonyLib;
using DMT;
using UnityEngine;
using System.Reflection;

namespace MyHarmonyPatches
{
    // Each DLL that contains Harmony scripts must contain a Start() for the DMT hooks to kick in.
    public class SampleProjectHarmonyInit : IHarmony
    {
        public void Start()
        {
            Debug.Log(" Loading Patch: " + this.GetType().ToString());

            // Reduce extra logging stuff
            Application.SetStackTraceLogType(UnityEngine.LogType.Log, StackTraceLogType.None);
            Application.SetStackTraceLogType(UnityEngine.LogType.Warning, StackTraceLogType.None);

            // Triggers the Harmony patch for the DLL.
            var harmony = new Harmony(GetType().ToString());
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

}
