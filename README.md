Sample Visual Studio Project for a BepInEx.


Installation:
	Copy the contents of Deployment/  into your 7 Days To Die root folder
	Run  7daystodie.exe

Contents:
	Deployment/   	- BepInEx plugins and all supporting files
	Deployment/Mods	- Sample Modlet with DLL and XML reference
	SampleProject/	- Visual Studio 2017 Community Edition sample project
					- Contains a new block and a few Harmony patches

BepInEx as configured, will write it's output in Player.log

	Direct3D:
		Version:  Direct3D 11.0 [level 11.1]
		Renderer: NVIDIA GeForce RTX 2060 SUPER (ID=0x1f06)
		Vendor:   
		VRAM:     8031 MB
		Driver:   27.21.14.5206
	Begin MonoManager ReloadAssembly
	- Completed reload, in  0.049 seconds
	<RI> Initializing input.

	XInput1_3.dll not found. Trying XInput9_1_0.dll instead...
	<RI> Input initialized.

	<RI> Initialized touch support.

	UnloadTime: 0.322300 ms
	[Message:   BepInEx] BepInEx 5.4.4.0 - 7DaysToDie
	[Info   :   BepInEx] Running under Unity v2019.2.17.9330739
	[Info   :   BepInEx] CLR runtime version: 4.0.30319.42000
	[Info   :   BepInEx] Supports SRE: True
	[Info   :   BepInEx] System platform: Bits64, Windows
	[Message:   BepInEx] Preloader started
	[Info   :   BepInEx] 1 patcher plugin loaded
	[Info   :   BepInEx] Patching [UnityEngine.CoreModule] with [BepInEx.Chainloader]
	[Message:   BepInEx] Preloader finished
	[Message:   BepInEx] Chainloader ready
	[Message:   BepInEx] Chainloader started
	[Info   :   BepInEx] 1 plugins to load
	[Info   :   BepInEx] Loading [DMT Bridge 1.0.0.0]
	Initializing DMT Bridge Plugin
	Start harmony loading: C:/Program Files (x86)/Steam/steamapps/common/7 Days To Die/7DaysToDie_Data/../Mods
	DLL found: C:/Program Files (x86)/Steam/steamapps/common/7 Days To Die/7DaysToDie_Data/../Mods\SampleProject\SampleProject.dll
	 Loading Patch: SampleProjectHarmonyInit