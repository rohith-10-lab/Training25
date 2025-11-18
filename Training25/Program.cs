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
   static readonly string[] blackSpecial = ["\u265C", "\u265E", "\u265D", "\u265B",
                                            "\u265A", "\u265D", "\u265E", "\u265C"];
   static readonly string[] whiteSpecial = ["\u2656", "\u2658", "\u2657", "\u2655",
                                            "\u2654", "\u2657", "\u2658", "\u2656"];
   static readonly string BlackPawn = "\u265F";
   static readonly string WhitePawn = "\u2659";

   // Returns 8x8 array with chess piece positions
   static string[,] Pieces () {
      string[,] board = new string[SIZE, SIZE];
      // Row 0 – Black’s special pieces
      for (int col = 0; col < SIZE; col++) board[0, col] = blackSpecial[col];
      // Row 1 – Black pawns
      for (int col = 0; col < SIZE; col++) board[1, col] = BlackPawn;
      // Rows 2–5 – empty squares
      for (int row = 2; row <= 5; row++)
         for (int col = 0; col < SIZE; col++) board[row, col] = " ";
      // Row 6 – White pawns
      for (int col = 0; col < SIZE; col++) board[6, col] = WhitePawn;
      // Row 7 – White’s special pieces
      for (int col = 0; col < SIZE; col++) board[7, col] = whiteSpecial[col];
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
