// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to find the minimum steps and final number with identical digits.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () => WriteLine ($"{SmallestTransform (GetInput (), out string num)} " +
      $"steps -> {num}");

   // Gets only integer as input from the user
   static int GetInput () {
      while (true) {
         Write ("Enter the number to transform: ");
         if (int.TryParse (ReadLine (), out int inp) && inp > 0) return inp;
         else WriteLine ("Enter a valid input.\n");
      }
   }

   // Returns the minimum steps and resulting number to make all the digits of a number identical
   static int SmallestTransform (int inp, out string transformed) {
      List<int> digits = new (10);
      for (int n = inp; n > 0; n /= 10) digits.Add (n % 10);
      digits.Sort ();
      int len = digits.Count, median = digits[len / 2];
      int sum = digits.Sum (d => Math.Abs (d - median));
      transformed = new ((char)(median + '0'), len);
      return sum;
   }
}
