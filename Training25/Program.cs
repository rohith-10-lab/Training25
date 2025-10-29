// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to check if it is a magic square.
// ------------------------------------------------------------------------------------------------
namespace Training25;
internal class Program {
   // To store 9 values in a array
   static void Main () {
      int[] arr = new int[9];
      for (int i = 1; i <= 9; i++) {
         Console.Write ($"Number {i}: ");
         if (int.TryParse (Console.ReadLine (), out int cnt))
         arr[i - 1] = cnt;
      }
      Console.WriteLine (arr);
   }

   // To check the conditions and return true or false
   static bool Checktrue (int[] b) {
      if (b[0] + b[1] + b[2] == b[3] + b[4] + b[5] == b[6] + b[7] + b[8] // rows
         == b[0] + b[3] + b[6] == b[1] + b[4] + b[7] == b[2] + b[5] + b[8] // columns
         == b[0] + b[4] + b[8] == b[2] + b[4] + b[6]) // diagonals
         return true;
      else return false;
   }
}
