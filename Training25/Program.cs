// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on sorting characters while moving a special character to the end.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      var (array, spclChar, isAscending) = GetInput ();
      WriteLine ($"\nResult: {ProcessInput (array, spclChar, isAscending)}");
   }

   // Gets and validates the character array, special character and sort order from user
   static (char[] A, char S, bool IsAscending) GetInput () {
      char[] array;
      char spclChar;
      // Gets and validates the comma separated characters
      while (true) {
         Write ("Enter letters separated by commas without spaces (e.g., a,b,c): ");
         string? inp1 = ReadLine ()?.ToLower ();
         if (string.IsNullOrEmpty (inp1)) { WriteLine ("Input cannot be empty.\n"); continue; }
         var parts = inp1.Split (',');
         if (parts.Any (IsInValidChar)) {
            WriteLine ("Enter only single letters separated by commas.\n"); continue;
         }
         array = [.. parts.Select (p => p[0])];
         break;
      }
      // Gets and validates the special character
      while (true) {
         Write ("Enter special character: ");
         string? inp2 = ReadLine ()?.Trim ().ToLower ();
         if (IsInValidChar (inp2)) { WriteLine ("Enter exactly one valid letter.\n"); continue; }
         spclChar = inp2![0];
         break;
      }
      // Determine sort order with a single key press
      Write ("Press (A)scending / (D)escending: ");
      return (array, spclChar, ReadKey ().Key != ConsoleKey.D);
   }

   // Checks whether the input is invalid (null, wrong length, or non-letter).
   static bool IsInValidChar (string? str)
      => string.IsNullOrWhiteSpace (str) || str.Length != 1 || !char.IsLetter (str[0]);

   // Sorts the array based on order and adds the special character at the end
   static string ProcessInput (char[] a, char s, bool isAscending = true) {
      var filtered = a.Where (ch => ch != s);
      var sorted = isAscending ? filtered.Order ()
                               : filtered.OrderByDescending (ch => ch);
      return string.Join (", ", sorted.Concat (a.Where (ch => ch == s)));
   }
}
