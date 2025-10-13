// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to find the Nth armstrong number
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main (string[] args) {
      if (args.Length == 0) {
         WriteLine ("Usage: Training25.exe <number>");
         return;
      }
      if (!int.TryParse (args[0], out int inp) || inp <= 0 || inp > 25) {
         WriteLine ("Enter a valid integer between 1 and 25.");
         return;
      }
      WriteLine (NthArmstrong (inp));
   }

   // Returns the Nth armstrong number
   static int NthArmstrong (int inp) {
      int cnt = 0, num = 0;
      while (true) {
         if (IsArmstrong (num)) {
            cnt++;
            if (cnt == inp) return num;
         }
         num++;
      }
   }

   // Checks whether a given number is armstrong or not
   static bool IsArmstrong (int num) {
      string numStr = num.ToString ();
      int sum = 0;
      foreach (char index in numStr) sum += IntPow (index - '0', numStr.Length);
      return sum == num;
   }

   // Computes the power of a number in int
   static int IntPow (int num, int exp) {
      int res = 1;
      for (int i = 0; i < exp; i++) res *= num;
      return res;
   }
}
