// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T05 - Multiplication tables.
// ------------------------------------------------------------------------------------------------
namespace Training25;

internal class Program {
   static void Main () => Multiply ();

   /// <summary>Prints multiplication tables from 1 to 10</summary>
   static void Multiply () {
      int start = 1, end = 10;
      for (int i = start; i <= end; i++) {
         for (int j = start; j <= end; j++)
            Console.WriteLine ($"{i} * {j,2} = {i * j}"); // {j,2} right aligns with width 2
         Console.WriteLine ();
      }
   }
}
