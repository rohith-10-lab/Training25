// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T05 - Multiplication tables. 
// ------------------------------------------------------------------------------------------------
namespace Training25;
internal class Program {
   static void Main (string[] args) => Multiply ();

   /// <summary> prints tables from 1 to 10</summary>
   static void Multiply () {
      for (int i = 1; i <= 10; i++) {
         for (int j = 1; j <= 10; j++) Console.WriteLine ($"{i} * {j,2} = {i * j}"); //{j,2} right aligns with width 2
         Console.WriteLine ();
      }
   }
}
