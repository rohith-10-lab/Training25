// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to print Pascal's triangle.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () => WriteLine (PascalTriangle (GetInput ()));

   // Gets only integer as input from the user
   static int GetInput () {
      while (true) {
         Write ("Enter the number of rows (1-20): ");
         if (int.TryParse (ReadLine (), out int rows) && rows <= 20 && rows > 0) return rows;
         else WriteLine ("Enter a valid input.\n");
      }
   }

   // Returns Pascal's triangle as a string
   static string PascalTriangle (int rows) {
      var res = new StringBuilder ();
      int[] previous = [1];
      const int COLWIDTH = 6;
      for (int row = 0; row < rows; row++) {
         int[] current = new int[row + 1];
         res.Append (new string (' ', (rows - row) * COLWIDTH / 2)); // Leading spaces
         for (int col = 0; col <= row; col++) {
            current[col] = (col == 0 || col == row) ? 1 : previous[col - 1] + previous[col];
            res.Append ($"{current[col], COLWIDTH}");
         }
         res.AppendLine ();
         previous = current;
      }
      return res.ToString ();
   }
}
