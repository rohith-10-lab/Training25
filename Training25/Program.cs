// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to display a given number in words/roman numbers.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      var (num, mode) = GetInput ();
      WriteLine ($"\n{num} -> {(mode == "words" ? ToWords (num) : ToRoman (num))}");
   }

   // Gets a number and mode (words/roman) as user input
   static (int Num, string Mode) GetInput () {
      int num;
      while (true) {
         Write ("Enter a number between 1 and 999: ");
         if (int.TryParse (ReadLine (), out num) && num is > 0 and <= 999) break;
         WriteLine ("Enter a valid input.\n");
      }
      while (true) {
         Write ("Enter mode (W)ords/(R)oman: ");
         var mode = ReadKey ().Key;
         if (mode == ConsoleKey.W) return (num, "words");
         if (mode == ConsoleKey.R) return (num, "roman");
         WriteLine ("\nInvalid mode. Press W for words or R for roman.\n");
      }
   }

   // Converts the given number to words
   static string ToWords (int num) {
      string[] ones = [ "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                     "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                     "Seventeen","Eighteen", "Nineteen" ];
      if (num < 20) return ones[num - 1];
      string[] tens = [ "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty",
                     "Ninety" ];
      if (num < 100) return num % 10 > 0 ? $"{tens[num / 10 - 2]} {ones[num % 10 - 1]}" :
                            $"{tens[num / 10 - 2]}";
      string hundreds = $"{ones[num / 100 - 1]} Hundred";
      return num % 100 > 0 ? $"{hundreds} {ToWords (num % 100)}" : hundreds;
   }

   // Converts the given number to roman numbers
   static string ToRoman (int num) {
      int[] values = [900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];
      string[] symbols = ["CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];
      var res = new StringBuilder ();
      for (int i = 0; i < values.Length; i++) {
         while (num >= values[i]) {
            num -= values[i];
            res.Append (symbols[i]);
         }
      }
      return res.ToString ();
   }
}
