// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to return the minimum steps to make all the digits of a number identical.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () => WriteLine ($"{SmallestTransform (Getinput ())} steps");

   // Gets only integer as input from the user
   static int Getinput () {
      while (true) {
         Write ("Enter the number to transform: ");
         if (int.TryParse (ReadLine (), out int inp) && inp > 0) return inp;
         else WriteLine ("Enter a valid input.\n");
      }
   }

   // Returns the minimum steps to make all the digits of a number identical
   static int SmallestTransform (int inp) {
      string inpStr = inp.ToString ();
      string sort = string.Concat (inpStr.OrderBy (c => c));
      int median = sort[inpStr.Length / 2] - '0', sum = 0;
      foreach (char c in inpStr) sum += Math.Abs (c - '0' - median);
      return sum;
   }
}
