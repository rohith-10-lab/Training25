// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to convert given decimal number to its specified base
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      int inp = GetInput ();
      WriteLine ($"Binary: {Conversion (inp, 2)}");
      WriteLine ($"Hex: {Conversion (inp, 16)}");
   }

   // Converts given decimal number to binary or hexadecimal using bitwise operators
   static string Conversion (int num, int baseVal) {
      const string DIGITS = "0123456789ABCDEF";
      if (baseVal is not (2 or 16)) throw new ArgumentException ("Base must be 2 or 16.");
      if (num == 0) return "0";
      int bitsPerDigit = baseVal == 2 ? 1 : 4;
      // Mask to extract the lowest 'bitsPerDigit' bits from the number
      int mask = (1 << bitsPerDigit) - 1;
      var res = new StringBuilder ();
      // Extract digits one by one from least significant to most significant
      while (num != 0) {
         res.Insert (0, DIGITS[num & mask]);
         // Performs logical right shift to move to the next group of bits and clears the top bits
         num = (num >> bitsPerDigit) & ~(-1 << (32 - bitsPerDigit));
      }
      return res.ToString ();
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
