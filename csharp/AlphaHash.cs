using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace AlphaHash
{
	public class AlphaHash
	{
			
		public static IEnumerable<byte> ByteSequence(byte min, byte max)
		{
			while (min <= max)
			{
				yield return  min++;
			}
		}

		public static byte[] JoinByteArrays(byte[] b1, byte[] b2)
		{
			List<byte> l1 = b1.ToList ();
			List<byte> l2 = b2.ToList ();
			List<byte> l3 = new List<byte>();
			l3.AddRange (l1);
			l3.AddRange (l2);
			return l3.ToArray ();
		}

		public static string AlphaHashIt(string data)
		{
			byte[] alphabet = JoinByteArrays (ByteSequence (65, 90).ToArray (), ByteSequence (97, 122).ToArray ());
			Dictionary<byte, byte> table = new Dictionary<byte, byte> ();

			for (int i = 1; i <= 95; i++)
			{
				int x = (i - 1) + 32;
				string s = x.ToString();

				s = s.PadLeft (3, '0');

				int num1 = Convert.ToInt32 (s.Substring(0, 1));
				int num2 = Convert.ToInt32 (s.Substring(1, 1));
				int num3 = Convert.ToInt32 (s.Substring(2, 1));
				int f = num1 + num2 + num3;
				f = f * 3;
				if (f > 52) {
					f = 52; // lazily cap it at 52 (it goes to 54 otherwise)
				}

				table.Add (Convert.ToByte(i - 1), alphabet[f - 1]);
			}
			//string data = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
			byte[] bytes = Encoding.ASCII.GetBytes (data);
			List<byte> output = new List<byte>();
			foreach (byte b in bytes) {
				byte n = b;
				if (n < 32 || n > 126) {
						n = 33; // '!'
				}
				int v = (n - 32);
				output.Add(table[Convert.ToByte(v)]);
			}
			return Encoding.ASCII.GetString(output.ToArray());
		}
			
	}		
}
