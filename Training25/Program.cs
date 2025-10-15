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
   static void Main () {
      WriteLine ($"The reversed string is: {ReverseStr (GetInput ())}");
   }

   // Gets only non-empty string from the user
   static string GetInput () {
      while (true) {
         Write ("Enter the string to be reversed: ");
         string? inp = ReadLine ();
         if (string.IsNullOrWhiteSpace (inp)) WriteLine ("Enter a valid input\n");
         else return inp;
      }
   }

   // Reverses a string, maintaining spaces and casing
   static string ReverseStr (string inp) {
      char[] chars = inp.Where (c => !char.IsWhiteSpace (c)).ToArray ();
      Array.Reverse (chars);
      var res = new StringBuilder ();
      int idx = 0;
      foreach (char c in inp) {
         if (c == ' ') res.Append (' ');
         else {
            char newChar = chars[idx];
            if (char.IsUpper (c)) res.Append (char.ToUpper (newChar));
            else res.Append (char.ToLower (newChar));
            idx++;
         }
      }
      return res.ToString ();
   }
}
