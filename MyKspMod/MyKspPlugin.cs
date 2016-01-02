using System;

using UnityEngine;

using kOS.AddOns;

namespace MyKspMod
{
	/*
		A KSP Plugin may be started in different areas:

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

	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	public class MyKspPlugin : MonoBehaviour
	{
		/*
		 * For More on MonoBehaviour, see Unity documentation:
		 * 
		 * http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
		 */

		public MyKspPlugin() {

			/*
			 * use Awake instead of the constructor for initialization,
			 * as the serialized state of the component is undefined at 
			 * construction time. Awake is called once, just like the 
			 * constructor.
			 * 
			 * For More:
			 * 
			 * http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.Awake.htm
			 * 
			 */

		}

		/*
         * 	Called when the script instance is being loaded.
         * 
         * 	http://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
         */
		void Awake() {}

		/*
         * Called on the frame when a script is enabled just before any of the 
         * Update methods is called the first time.
         * 
         * http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
         */
		void Start()
		{
			print("MyKspPlugin: START");

			/*
			 * For partless plugins, or plugins which start outside of
			 * scenes where kOS operates (flight) we need to wait until 
			 * kOS is ready as the plugin may be started before kOS is
			 * either loaded or ready.
			 * 
			 * This means we probably want to know when the addon was
			 * installed. To know this we can (optionally) include a 
			 * callback of type Action<Boolean> to the installWhenReady
			 * method. The callback will be executed whenever the addon
			 * is 'installed' in kOS.
			 * 
			 * Alternatively, if you don't care about this information 
			 * you can go ahead and igore it like so:
			 * 
			 * AddonManager.installWhenReady ("MY", typeof(MyKosAddon));
			 */

			Action<Boolean> callback = s => onInstallAddon (s);

			AddonManager.installWhenReady ("MY", typeof(MyKosAddon), callback);

		}

		/*
		 * Called when our kOS addon is installed
		 */
		private void onInstallAddon(Boolean wasInstalled) {
			
			if (wasInstalled) {
				
				print ("MyKspPlugin: Addon installed, ready.");

			} else {

				print ("MyKspPlugin: Addon was not installed :(");

			}

		}

		/*
         * Called every frame, if the MonoBehaviour is enabled.
         * 
         * http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
         */
		void Update() {}

		/*
         * Called every fixed framerate frame (interval determined by the physics time step).
         * 
         * http://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
         */
		void FixedUpdate() {}

		/*
         * Called when the MonoBehaviour will be destroyed such as when the game is leaving
         * the scene (or exiting). Perform any clean up work here.
         * 
         * http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDestroy.html
         */
		void OnDestroy() {}
			
	}
}

