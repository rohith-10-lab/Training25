// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T06 - Digital Root.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training25;

internal class Program {
   static void Main () {
      int input = GetInput ();
      WriteLine ($"The digital root of {input} is {DigitalRoot (input)} ");
   }

   /// <summary>Gets only positive integer from the user</summary>
   static int GetInput () {
      while (true) {
         Write ("Enter a positive integer: ");
         if (int.TryParse (ReadLine (), out int number) && number >= 0) return number;
         ForegroundColor = ConsoleColor.Yellow;
         WriteLine ("Enter a valid input");
         ResetColor ();
         Write ("Press any key to continue...");
         ReadKey ();
         Clear ();
      }
   }

   /// <summary>Returns the digital root of the input</summary>
   static int DigitalRoot (int number) => number == 0 ? 0 : 1 + ((number - 1) % 9);
}
