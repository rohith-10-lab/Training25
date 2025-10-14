// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to reduce a string of lowercase letters.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      string output = RemoveAdjacent (GetInput ());
      WriteLine ($"Reduced string: {(output == "" ? "Empty String" : output)}");
   }

   // Removes adjacent lowercase letters in a string and returns the resultatnt string
   static string RemoveAdjacent (string inp) {
      string res = "";
      int len = inp.Length;
      for (int i = 0; i < len; i++) {
         if (i < len - 1 && char.IsLower (inp[i]) && inp[i] == inp[i + 1]) i++;
         else res += inp[i];
      }
      return (res == inp) ? res : RemoveAdjacent (res);
   }

   // Returns valid string input, null or empty input is rejected
   static string GetInput () {
      while (true) {
         Write ("Enter a string of lowercase characters: ");
         string? inp = ReadLine ();
         if (string.IsNullOrEmpty (inp)) WriteLine ("Enter a valid input\n");
         else return inp;
      }
   }
}
