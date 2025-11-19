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
               >= 2 and <= 5 => " ",
               6 => WHITEPAWN,
               _ => sWhiteSpecial[col]
            };
         }
      }
      return board;
   }

   // Returns the chessboard with pieces
   static string PrintBoard (string[,] board) {
      var sb = new StringBuilder ();
      var segments = Enumerable.Repeat ("\u2500\u2500\u2500", SIZE);
      string mid = "\u251C" + string.Join ("\u253C", segments) + "\u2524";
      // Top part of board
      sb.AppendLine ("\u250C" + string.Join ("\u252C", segments) + "\u2510");
      for (int row = 0; row < SIZE; row++) {
         sb.Append (BORDER);
         for (int col = 0; col < SIZE; col++) sb.Append ($" {board[row, col]} {BORDER}");
         sb.AppendLine ();
         // Middle part of board
         if (row < SIZE - 1) sb.AppendLine (mid);
      }
      // Bottom part of board
      sb.AppendLine ("\u2514" + string.Join ("\u2534", segments) + "\u2518");
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
