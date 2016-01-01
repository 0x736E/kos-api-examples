
using kOS;
using kOS.AddOns;
using kOS.Safe.Encapsulation;
using kOS.Safe.Encapsulation.Suffixes;

namespace MyKspMod
{
	public class MyKspAddon : kOS.Suffixed.Addon
	{
		public MyKspAddon(SharedObjects shared) : base ("MY", shared)
		{
			Initialize();
		}

		private void Initialize()
		{
			// Add suffixes
			AddSuffix("LIST", new Suffix<ListValue>(GetList, "MY:LIST"));
		}

		private ListValue GetList()
		{
			var list = new ListValue();

			list.Add ("item one");

			return list;
		}

		public override bool Available()
		{
			return true;
		}

	}
}