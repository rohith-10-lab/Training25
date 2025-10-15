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
      WriteLine ($"Reduced string: {(string.IsNullOrEmpty (output) ? "Empty String" : output)}");
   }

   // Removes adjacent lowercase letters in a string and returns the resultant string
   static string RemoveAdjacent (string inp) {
      if (inp.Length < 2) return inp;
      string res = "";
      int len = inp.Length;
      for (int i = 0; i < len; i++) {
         if (i < len - 1 && inp[i] == inp[i + 1]) i++;
         else res += inp[i];
      }
      return (res == inp) ? res : RemoveAdjacent (res);
   }

   // Gets only letters as input
   static string GetInput () {
      while (true) {
         Write ("Enter a string containing only letters to be reduced: ");
         string inp = (ReadLine () ?? string.Empty).ToLower ();
         if (string.IsNullOrWhiteSpace (inp) || inp.Any (c => !char.IsLetter (c)))
            WriteLine ("Enter a valid input\n");
         else return inp;
      }
   }
}
