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
      var (array, spclChar, isOrderChosen, isAscending) = GetInput ();
      if (isOrderChosen) WriteLine ($"\nResult: {ProcessInput (array, spclChar, isAscending)}");
      else WriteLine ($"\nResult: {ProcessInput (array, spclChar)}");
   }

   // Gets and validates the character array, special character and sort order from user
   static (char[] a, char s, bool isOrderChosen, bool isAscending) GetInput () {
      char[] array;
      char spclChar;
      bool isAscending = true, isOrderChosen;
      for (; ; ) {
         Write ("Enter letters separated by commas without spaces (e.g., a,b,c): ");
         string? inp1 = ReadLine ()?.ToLower ();
         if (string.IsNullOrEmpty (inp1)) { WriteLine ("Input cannot be empty.\n"); continue; }
         var parts = inp1.Split (',');
         if (parts.Any (p => string.IsNullOrWhiteSpace (p) || p.Length != 1
                                                           || !char.IsLetter (p[0]))) {
            WriteLine ("Enter only single letters separated by commas.\n"); continue;
         }
         array = [.. parts.Select (p => p[0])];
         break;
      }
      for (; ; ) {
         Write ("Enter special character: ");
         string? inp2 = ReadLine ()?.Trim ().ToLower ();
         if (string.IsNullOrEmpty (inp2) || inp2.Length != 1 || !char.IsLetter (inp2[0])) {
            WriteLine ("Enter exactly one valid letter.\n"); continue;
         }
         spclChar = inp2[0];
         break;
      }
      for (; ; ) {
         Write ("Press (A)scending / (D)escending / Any key for default: ");
         ConsoleKey key = ReadKey ().Key;
         if (key == ConsoleKey.A) {
            isAscending = true;
            isOrderChosen = true;
            break;
         }
         if (key == ConsoleKey.D) {
            isAscending = false;
            isOrderChosen = true;
            break;
         }
         isOrderChosen = false;
         break;
      }
      return (array, spclChar, isOrderChosen, isAscending);
   }

   // Sorts the array based on order and adds the special character at the end
   static string ProcessInput (char[] a, char s, bool isAscending = true) =>
       string.Join (", ", (isAscending ? a.Where (ch => ch != s).OrderBy (ch => ch)
                                       : a.Where (ch => ch != s).OrderByDescending (ch => ch))
                                       .Concat (a.Where (ch => ch == s)));
}
