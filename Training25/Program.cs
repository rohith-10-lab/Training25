// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to reverse a string while maintaining spaces and casing
// ------------------------------------------------------------------------------------------------
using static System.Console;
using System.Text;

namespace Training25;

internal class Program {
   static void Main () => WriteLine ($"The reversed string is: {ReverseStr (GetInput ())}");

   // Gets only non-empty string from user
   static string GetInput () {
      while (true) {
         Write ("Enter the string to be reversed: ");
         string? inp = ReadLine ();
         if (string.IsNullOrWhiteSpace (inp)) WriteLine ("Enter a valid input\n");
         else return inp;
      }
   }

   // Reverses a string, maintaining spaces and original casing
   static string ReverseStr (string inp) {
      char[] chars = [.. inp.Where (c => !char.IsWhiteSpace (c)).Reverse ()];
      var res = new StringBuilder ();
      int idx = 0;
      foreach (char c in inp) {
         char nxtChar = ' ';
         if (!char.IsWhiteSpace (c)) {
            nxtChar = chars[idx++];
            nxtChar = char.IsUpper (c) ? char.ToUpper (nxtChar) : char.ToLower (nxtChar);
         }
         res.Append (nxtChar);
      }
      return res.ToString ();
   }
}
