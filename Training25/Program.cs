// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T11 - Armstrong number.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training25;

internal class Program {
   static void Main () {
      int input = GetInput ();
      bool result = IsArmStrong (input);
      PrintMessage (result ? $"{input} is an armstrong number"
         : $"{input} is not an armstrong number", result ? ConsoleColor.Green : ConsoleColor.Red);
   }

   // Gets only positive integer from the user
   static int GetInput () {
      while (true) {
         Write ("Enter a positive integer: ");
         if (int.TryParse (ReadLine (), out int number) && number >= 0) return number;
         PrintMessage ("Enter a valid input\n", ConsoleColor.Yellow);
         Write ("Press any key to continue...");
         ReadKey ();
         Clear ();
      }
   }

   // Checks whether the input is armstrong or not
   static bool IsArmStrong (int number) {
      string numStr = number.ToString ();
      int sum = 0;
      foreach (char index in numStr) sum += (int)Math.Pow (index - '0', numStr.Length);
      return sum == number;
   }

   // Prints the message in the console with a specified color
   static void PrintMessage (string message, ConsoleColor color) {
      ForegroundColor = color;
      Write (message);
      ResetColor ();
   }
}
