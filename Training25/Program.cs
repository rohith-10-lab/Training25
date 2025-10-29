// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on main branch.
// ------------------------------------------------------------------------------------------------
using System.Text;

namespace Training25;
internal class Program {
   static void Main () {
      int inp = 52;
      char[] chars = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S',
      'T','U','V','W', 'X','Y','Z'};
      int len = chars.Length;
      var res = new StringBuilder ();
      if (inp > len) {
         res.Append (chars [0]);
         int rem = inp / len;
         while (rem > len) {
            res.Append ((chars[0]));
            rem = rem / len;
         }
         res.Append (chars[rem - 1]);
         Console.WriteLine (res.ToString ());
      }
      else Console.WriteLine (chars[inp-1]);
   }
}
