// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to return the most frequent character in a string and its occurence.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () => WriteLine ($"{MostFrequentChar (GetInput (), out int cnt)},{cnt}");

   // Gets only string of letters from user as input
   static string GetInput () {
      while (true) {
         Write ("Enter a string of alphabets: ");
         string? inp = ReadLine ();
         if (string.IsNullOrEmpty (inp) || inp.Any (c => !char.IsLetter (c)))
            WriteLine ("Enter a valid input\n");
         else return inp;
      }
   }

   // Returns the most frequent character in the string and its count through out parameter
   static char MostFrequentChar (string inp, out int cnt) {
      var firstMax = inp.ToLower ().GroupBy (c => c).OrderByDescending (g => g.Count ()).First ();
      cnt = firstMax.Count ();
      return firstMax.Key;
   }
}
