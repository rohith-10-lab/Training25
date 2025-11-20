// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to display a chess board with all pieces.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      OutputEncoding = new UnicodeEncoding ();
      WriteLine (PrintBoard (Pieces ()));
   }

   // Returns 8x8 array with chess piece positions
   static string[,] Pieces () {
      string[,] board = new string[SIZE, SIZE];
      for (int row = 0; row < SIZE; row++) {
         for (int col = 0; col < SIZE; col++) {
            board[row, col] = row switch {
               0 => sBlackSpecial[col],
               1 => BLACKPAWN,
               6 => WHITEPAWN,
               7 => sWhiteSpecial[col],
               _ => " "
            };
         }
      }
      return board;
   }

   // Returns the chessboard with pieces
   static string PrintBoard (string[,] board) {
      var sb = new StringBuilder ();
      var segments = Enumerable.Repeat ("──────", SIZE);
      string mid = "├" + string.Join ("┼", segments) + "┤";
      // Top row
      sb.AppendLine ("┌" + string.Join ("┬", segments) + "┐");
      for (int row = 0; row < SIZE; row++) {
         // For each of the 3 sub-rows in a cell
         for (int sub = 0; sub < 3; sub++) {
            sb.Append (BORDER);
            for (int col = 0; col < SIZE; col++) {
               string cell = sub switch {
                  1 => "  " + board[row, col] + "   ",   // Piece row (centered)
                  _ => "      "                          // Padding row
               };
               sb.Append (cell + BORDER);
            }
            sb.AppendLine ();
         }
         if (row < SIZE - 1) sb.AppendLine (mid);
      }
      // Bottom row
      sb.AppendLine ("└" + string.Join ("┴", segments) + "┘");
      return sb.ToString ();
   }

   const int SIZE = 8;
   static readonly string[] sBlackSpecial = ["\u265C", "\u265E", "\u265D", "\u265B",
                                            "\u265A", "\u265D", "\u265E", "\u265C"];
   static readonly string[] sWhiteSpecial = ["\u2656", "\u2658", "\u2657", "\u2655",
                                            "\u2654", "\u2657", "\u2658", "\u2656"];
   const string BLACKPAWN = "\u265F", WHITEPAWN = "\u2659";
   const char BORDER = '\u2502';
}
