using System;

using UnityEngine;

using kOS.AddOns;

namespace MyKspMod
{
	/*

		A KSP Plugin may be started in different scenes:

		[KSPAddon(KSPAddon.Startup.EditorAny, false)]
		[KSPAddon(KSPAddon.Startup.Flight, false)]
		[KSPAddon(KSPAddon.Startup.Instantly, false)]
		[KSPAddon(KSPAddon.Startup.MainMenu, true)]
		[KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
		[KSPAddon(KSPAddon.Startup.EveryScene, false)]
		[KSPAddon(KSPAddon.Startup.TrackingStation, false)]
		[KSPAddon(KSPAddon.Startup.Editor, false)]
		[KSPAddon(KSPAddon.Startup.SPH, false)]

	*/

	[KSPAddon(KSPAddon.Startup.EveryScene, false)]
	public class MyKspPlugin : MonoBehaviour
	{

		/*
         * Caution: as it says here: http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.Awake.html,
         * use the Awake() method instead of the constructor for initializing data because Unity uses
         * Serialization a lot.
         */
		public MyKspPlugin() {}

		/*
         * Called after the scene is loa_queuedAddonsded.
         */
		void Awake() {}

		/*
         * Called next.
         */
		void Start()
		{
			print("MyKspPlugin: START");

			/*
			 * For partless plugins, we need to wait until kOS is ready
			 * as this plugin may be activated before kOS is even loaded.
			 */
			AddonManager.installWhenReady ("MY", typeof(MyKosAddon));
		}

		/*
         * Called every frame
         */
		void Update() {}

		/*
         * Called at a fixed time interval determined by the physics time step.
         */
		void FixedUpdate() {}

		/*
         * Called when the game is leaving the scene (or exiting). Perform any clean up work here.
         */
		void OnDestroy() {}
			
	}
}

