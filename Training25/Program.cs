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
   const int SIZE = 8;
   static readonly string[] sBlackSpecial = ["\u265C", "\u265E", "\u265D", "\u265B",
                                            "\u265A", "\u265D", "\u265E", "\u265C"];
   static readonly string[] sWhiteSpecial = ["\u2656", "\u2658", "\u2657", "\u2655",
                                            "\u2654", "\u2657", "\u2658", "\u2656"];
   static readonly string sBlackPawn = "\u265F";
   static readonly string sWhitePawn = "\u2659";

   // Returns 8x8 array with chess piece positions
   static string[,] Pieces () {
      string[,] board = new string[SIZE, SIZE];
      for (int row = 0; row < SIZE; row++) {
         for (int col = 0; col < SIZE; col++) {
            if (row == 0) board[row, col] = sBlackSpecial[col];
            else if (row == 1) board[row, col] = sBlackPawn;
            else if (row >= 2 && row <= 5) board[row, col] = " ";
            else if (row == 6) board[row, col] = sWhitePawn;
            else board[row, col] = sWhiteSpecial[col];
         }
      }
      return board;
   }

   // Returns the chessboard with pieces
   static string PrintBoard (string[,] board) {
      var sb = new StringBuilder ();
      var segments = Enumerable.Repeat ("\u2500\u2500\u2500\u2500", SIZE);
      string top = "\u250C" + string.Join ("\u252C", segments) + "\u2510";
      string mid = "\u251C" + string.Join ("\u253C", segments) + "\u2524";
      string bottom = "\u2514" + string.Join ("\u2534", segments) + "\u2518";
      sb.AppendLine (top);
      for (int row = 0; row < SIZE; row++) {
         sb.Append ('\u2502');
         for (int col = 0; col < SIZE; col++) sb.Append ($" {board[row, col]}  \u2502");
         sb.AppendLine ();
         if (row < SIZE - 1) sb.AppendLine (mid);
      }
      sb.AppendLine (bottom);
      return sb.ToString ();
   }
}
