// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T03 - LCM and GCD generator.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training25;

internal class Program {
   static void Main () {
      int num1 = GetInput ("Enter the first positive integer: ");
      int num2 = GetInput ("Enter the second positive integer: ");
      int gcd = Gcd (num1, num2);
      WriteLine ($"The Gcd of {num1} and {num2} is {gcd}");
      WriteLine ($"The Lcm of {num1} and {num2} is {num1 * num2 / gcd}");
   }

   // Gets only positive number from the user
   static int GetInput (string prompt) {
      while (true) {
         Write (prompt);
         if (int.TryParse (ReadLine (), out int num) && num >= 0) return num;
         ForegroundColor = ConsoleColor.Yellow;
         WriteLine ("Enter a valid input");
         ResetColor ();
         Write ("Press any key to continue...");
         ReadKey ();
         Clear ();
      }
   }

   // Calculates gcd using Euclidean algorithm
   static int Gcd (int num1, int num2) {
      while (num2 != 0) {
         int temp = num2;
         num2 = num1 % num2;
         num1 = temp;
      }
      return num1;
   }
}
