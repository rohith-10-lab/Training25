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
         switch (ReadKey ().Key) {
            case ConsoleKey.W: return (num, "words");
            case ConsoleKey.R: return (num, "roman");
            default: WriteLine ("\nInvalid mode. Press W for words or R for roman.\n"); break;
         }
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
      int unit = num % 10;
      var tenWord = tens[num / 10 - 2];
      if (num < 100) return unit > 0 ? $"{tenWord} {ones[unit - 1]}" : tenWord;
      string hundreds = $"{ones[num / 100 - 1]} Hundred";
      int rem = num % 100;
      return rem > 0 ? $"{hundreds} {ToWords (rem)}" : hundreds;
   }

   // Converts the given number to roman numbers
   static string ToRoman (int num) {
      var res = new StringBuilder ();
      foreach (var pair in sMap) {
         while (num >= pair.Key) {
            num -= pair.Key;
            res.Append (pair.Value);
         }
      }
      return res.ToString ();
   }
   static Dictionary<int, string> sMap = new () {
      [1000] = "M", [900] = "CM", [500] = "D", [400] = "CD", [100] = "C", [90] = "XC",
      [50] = "L", [40] = "XL", [10] = "X", [9] = "IX", [5] = "V", [4] = "IV", [1] = "I"
   };
}
