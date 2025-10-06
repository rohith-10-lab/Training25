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
      int cnt = GetInput ("Enter how many numbers you want to calculate GCD for: ", 2);
      int[] nums = new int[cnt];
      for (int i = 0; i < cnt; i++) nums[i] = GetInput ($"Enter number {i + 1}: ");
      int gcd = nums[0], lcm = nums[0];
      for (int i = 1; i < cnt; i++) {
         gcd = GCD (gcd, nums[i]);
         lcm = LCM (lcm, nums[i]);
      }
      WriteLine ($"The GCD of the given numbers is {gcd}");
      WriteLine ($"The LCM of the given numbers is {lcm}");
   }

   // Gets only positive number from the user
   static int GetInput (string prompt, int min = 0) {
      while (true) {
         Write (prompt);
         if (int.TryParse (ReadLine (), out int num) && num >= min) return num;
         WarningMsg ("Enter a valid input");
      }
   }

   // Calculates GCD using Euclidean algorithm
   static int GCD (int num1, int num2) => (num2 == 0) ? num1 : GCD (num2, num1 % num2);

   // Calculates LCM using GCD
   static int LCM (int num1, int num2)
      => num1 == 0 || num2 == 0 ? 0 : num1 / GCD (num1, num2) * num2;

   // Prints the warning prompt
   static void WarningMsg (string msg) {
      ForegroundColor = ConsoleColor.Yellow;
      WriteLine (msg);
      ResetColor ();
      WriteLine ("Press any key to continue...");
      ReadKey ();
      WriteLine ();
   }
}
