// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to convert given decimal number to its specified base
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      int inp = GetInput ();
      WriteLine ($"Binary: {Conversion (inp, 2)}");
      WriteLine ($"Hex: {Conversion (inp, 16)}");
   }

   // Converts given decimal to its specified base
   static string Conversion (int num, uint type) {
      if (num == 0) return "0";
      string defValues = "0123456789ABCDEF", res = "";
      uint n = (uint)num;
      while (n > 0) {
         res = defValues[(int)(n % type)] + res;
         n /= type;
      }
      if (num < 0) {
         if (type == 2) {
            // Trim leading 1s but keep the last 1 before first 0
            int firstZero = res.IndexOf ('0');
            res = res.Substring (firstZero - 1);
         } else if (type == 16) {
            // Trim leading F's but keep the last F before first non-F
            int firstNonF = res.IndexOfAny ("0123456789ABCDE".ToCharArray ());
            res = res.Substring (firstNonF - 1);
         }
      }
      return res;
   }

   // Gets only integer as input from user
   static int GetInput () {
      while (true) {
         Write ("Enter an integer: ");
         if (int.TryParse (ReadLine (), out int num)) return num;
         ForegroundColor = ConsoleColor.Yellow;
         WriteLine ("Enter a valid input\n");
         ResetColor ();
      }
   }
}
