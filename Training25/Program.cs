// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T01 - Number conversion game.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      int input = GetInput ();
      WriteLine ($"The Binary value {input} is {Conversion (input, 2)}");
      WriteLine ($"The hexadecimal value of {input} is {Conversion (input, 16)}");
   }

   // Gets only positive number from the user
   static int GetInput () {
      while (true) {
         Write ("Enter a positive integer: ");
         if (int.TryParse (ReadLine (), out int num) && num >= 0) return num;
         ForegroundColor = ConsoleColor.Yellow;
         WriteLine ("Enter a valid input");
         ResetColor ();
         Write ("Press any key to continue...");
         ReadKey ();
         Clear ();
      }
   }

   // Converts given decimal number to its specified base
   static string Conversion (int num, int type) {
      if (num == 0) return "0";
      string defaultValues = "0123456789ABCDEF";
      string values = "";
      while (num > 0) {
         values = defaultValues[num % type] + values;
         num /= type;
      }
      return values;
   }
}
