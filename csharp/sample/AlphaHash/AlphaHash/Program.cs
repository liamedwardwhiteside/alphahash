using System;
using System.IO;
namespace AlphaHash
{
	class SampleProgram
	{
		public static void Main (string[] args)
		{
			string d = "";
			if (System.Console.IsInputRedirected) {
				var ts = Console.In;
				d = ts.ReadToEnd ();
				ts.Close ();
			} else if (args.Length > 0) {
				foreach (string a in args) {
					d += a;
				}
			} else {
				return;
			}

			if (d != "") {
				Console.Write(AlphaHash.AlphaHashIt (d));
			}
			return;
		}
	}
}
