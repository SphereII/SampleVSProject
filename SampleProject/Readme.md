Sample Project by sphereii


References:
	- Most references are self contained in this project. However, Assembly-CSharp.dll is not allowed to be distributed.
		By default, the reference to Assembly-CSharp.dll points to the default steam folder: 
			C:\Program Files (x86)\Steam\steamapps\common\7 Days To Die\7DaysToDie_Data\Managed
		Remove and re-add this reference if you want a different path.

Quick Start:
	1) Adjust the Assembly-CSharp.dll, if necessary, as mentioned above.
	2) Build -> Build Solution
	3) Copy the bin/Debug/SampleProject.dll to the Mods/SampleProject


Definitions:
	Harmony scripts are used to modify existing methods in the game.

	Scripts are used when you want to add in new item, block, and entity code, rather than just adjusting existing code.


Note:  Folders are used in this project to seperate Harmony and Scripts. This is not necessary, but does help organization.

Harmony/
	- HarmonyInit.cs:
		Every DLL that contains Harmony script must contain a Start() method like in this example. This initializes all the Harmony patches for the DLL.
		You do not need to modify this HarmonyInit.cs. It will work with all projects.

	- HarmonySample.cs:
		This script contains a few examples using Prefix and Postfix code. 

		The HarmonySample.cs contains a namespace called MyHarmonyPatches.  This is not required, and is again used for organization. 
			If you use dnSpy to open up your DLL, the Harmony scripts will be all under the MyHarmonySample.cs rather than the default {} anonymous namespace. It will be easy to tell which are Scripts and which are Harmony patches

		You may have multiple scripts with Harmony patches. 

		For example, you could have a Harmony/blocks.cs  that contains all the Harmony patches for blocks, and Harmony/items.cs for all items.

Scripts/
	- SampleBlock.cs
		This is a simple, bare minimum class to add a new block.


	When reference a new class via XML, you need to reference the class name, as well as the assembly name of the DLL.
	
	In this project, the Assembly name is "SampleProject".  
	The sample block's class name is BlockSampleBlock. The game will sometimes add in a prefix automatically to the class name. 

	Example:
		class BlockSampleBlock : Block

		<!-- The game auto-adds Block to the class name, so you do not need to list to list it as  "BlockSampleBlock, SampleProject"
		<property name="Class" value="SampleBlock, SampleProject"/>


If you open up the SampleProject.dll using dnSpy, you'll see this structure:

	SampleProject.dll
		{} -
			<Module>  (auto generated)
			BlockSampleBlock   ( our sample block code )
		MyHarmonyPatches -
			SampleProjectHarmonyInit 
			SampleProjectMainMenuHarmonyPatch
			SampleProject_Block_Init
			SSampleProjectBlockSecureLoot


Other Notes:

	The DLL in the Modlet folder will generate a warning in the Player.log:

		2020-12-27T18:33:15 6.275 INF [MODS] Trying to load from folder: SampleProject
		2020-12-27T18:33:15 6.285 WRN [MODS] Not loading DLL, only supported on the dedicated server build
		2020-12-27T18:33:15 6.286 INF [MODS] Loaded Mod: SampleProject (19.4.0.0)

	The DMTBridgePlugin will recursively look in the Mods folder for all DLLs. To avoid that WRN, you may make a subfolder in your modlet and place the DLL there. The name of the subfolder does not matter.

		SampleProject/
			Config/blocks.xml
			Scripts/SampleProject.dll
			ModInfo.xml


	As a general rule of thumb, I do not put any Scripts into namespaces. Using namespaces for the Script references is a bit confusing to format correctly.

