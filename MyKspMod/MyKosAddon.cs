using System;

using kOS;
using kOS.AddOns;
using kOS.Safe.Encapsulation;
using kOS.Safe.Encapsulation.Suffixes;

using UnityEngine;
using kOS.Safe.Exceptions;
using kOS.Safe.Utilities;


namespace MyKspMod
{
	public class MyKosAddon : kOS.Suffixed.Addon
	{

		public MyKosAddon(SharedObjects shared) : base ("MY", shared) {
			
			Initialize();
		}

		private void Initialize() {
			
			/*
			 * Some sample kOS interfaces
			 */

			// ADDONS:MY:LIST
			AddSuffix("LIST", new Suffix<ListValue>(GetList, "A List"));

			AddSuffix("EXPT", new OneArgsSuffix<string>(Except, "Suffix, no argument, throws kOS exception"));

			AddSuffix("RASP", new NoArgsSuffix(Raspberry, "Suffix, no argument"));
			AddSuffix("APPLE", new NoArgsSuffix<float>(Apple, "Suffix, no argument, return float"));

			AddSuffix("HELLO", new OneArgsSuffix<string>(Hello, "Suffix, single argument"));
			AddSuffix("BOOL", new OneArgsSuffix<bool, bool>(George, "Suffix, single argument, return bool"));

			AddSuffix("VIP", new TwoArgsSuffix<int, int>(Viper, "Add two items together"));
			AddSuffix("ADD", new TwoArgsSuffix<int, int, int>(Adder, "Add two items together, return int"));

		}

		/*
		 * Called to determine whether this addon is available
		 */ 
		public override bool Available() {
			
			return true;
		}

		/*
		 * Called when terminal attempts to print to screen
		 */
		public override string ToString()
		{
			return string.Format("MyKosAddon");
		}


		public void Except(string msg) {

			throw new KOSInvalidFieldValueException("Invalid message : " + msg);
		}

		private ListValue GetList() {
			
			var list = new ListValue();

			list.Add ("item one");

			return list;
		}

		private void Raspberry() {

			//UnityEngine.Debug.Log("MyKosAddon: Raspberry " + Mathf.PI);
		}

		private float Apple() {
			
			return Mathf.PI;
		}

		private void Hello(string world) {

			//UnityEngine.Debug.Log("MyKosAddon: Hello " + world);
		}

		private bool George(bool b) {
			
			return !b;
		}

		private void Viper(int a, int b) {

			int c = a + b;

			//UnityEngine.Debug.Log("MyKosAddon: Viper " + c);
		}

		private int Adder(int a, int b) {
			
			return a + b;
		}

	}
}