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
      int num = GetInput ();
      WriteLine ($"Words : {ToWords (num)}");
      WriteLine ($"Roman : {ToRoman (num)}");
   }

   // Gets a number between 1 and 999 from user input
   static int GetInput () {
      while (true) {
         Write ("Enter a number between 1 and 999: ");
         if (int.TryParse (ReadLine (), out int num) && num is > 0 and <= 999) return num;
         WriteLine ("Enter a valid input.\n");
      }
   }

   // Converts the given number to words
   static string ToWords (int num) {
      if (num < 20) return sOnes[num - 1];
      if (num < 100) {
         int unit = num % 10;
         var tenWord = sTens[num / 10 - 2];
         return unit > 0 ? $"{tenWord} {sOnes[unit - 1]}" : tenWord;
      }
      string hundreds = $"{sOnes[num / 100 - 1]} Hundred";
      int rem = num % 100;
      return rem > 0 ? $"{hundreds} {ToWords (rem)}" : hundreds;
   }
   static string[] sOnes = [ "One", "Two", "Three", "Four", "Five", "Six", "Seven","Eight", "Nine",
                             "Ten", "Eleven", "Twelve", "Thirteen","Fourteen", "Fifteen",
                             "Sixteen", "Seventeen","Eighteen", "Nineteen" ];

   static string[] sTens = [ "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
                             "Eighty", "Ninety" ];

   // Converts the given number to roman numerals
   static string ToRoman (int num) {
      var res = new StringBuilder ();
      foreach (var pair in sMap)
         while (num >= pair.Key) {
            num -= pair.Key;
            res.Append (pair.Value);
         }
      return res.ToString ();
   }
   static Dictionary<int, string> sMap = new () {
      [1000] = "M", [900] = "CM", [500] = "D", [400] = "CD", [100] = "C", [90] = "XC",
      [50] = "L", [40] = "XL", [10] = "X", [9] = "IX", [5] = "V", [4] = "IV", [1] = "I"
   };
}
