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
      var (array, spclChar, order) = GetInput ();
      WriteLine ($"\n\nResult: {ProcessInput (array, spclChar, order)}");
   }

   // Gets and validates the character array, special character and sort order from user
   static (char[] a, char s, char o) GetInput () {
      char[] array;
      char spclChar, order;
      for (; ; ) {
         Write ("Enter letters separated by commas (e.g., a,b,c): ");
         string? inp1 = ReadLine ()?.ToLower ().Replace (" ", "");
         if (string.IsNullOrEmpty (inp1)) { WriteLine ("Input cannot be empty.\n"); continue; }
         var parts = inp1.Split (',', StringSplitOptions.RemoveEmptyEntries);
         if (parts.Any (p => p.Length != 1 || !char.IsLetter (p[0]))) {
            WriteLine ("Use only single letters separated by commas.\n"); continue;
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
         Write ("Press (A)scending / (D)escending / Enter for default: ");
         ConsoleKey key = ReadKey (true).Key;
         if (key == ConsoleKey.A || key == ConsoleKey.Enter) { order = 'a'; break; }
         if (key == ConsoleKey.D) { order = 'd'; break; }
         WriteLine ("Press only A, D or Enter.\n");
      }
      return (array, spclChar, order);
   }

   // Sorts the array based on order and adds the special character at the end
   static string ProcessInput (char[] A, char S, char order) =>
       string.Join (", ", (order == 'a' ? A.Where (ch => ch != S).OrderBy (ch => ch)
                                        : A.Where (ch => ch != S).OrderByDescending (ch => ch))
                                        .Concat (A.Where (ch => ch == S)));
}
