
using UnityEngine;

using kOS.AddOns;

namespace MyKspMod
{
	public class MyKspModPart : PartModule
	{

		/// <summary>
		/// Called when the part is started by Unity.
		/// </summary>
		public override void OnStart(StartState state)
		{
			Initialize ();
		}

		private void Initialize() 
		{
			print("MyKspModPart: Initializing...");
			AddonManager.install ("MY", typeof(MyKspAddon));
			print("MyKspModPart: Done!");
		}
			
	}
}

