// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T11 - Armstrong number.
// ------------------------------------------------------------------------------------------------
namespace Training25;

internal class Program {
   static void Main () => ArmStrong (GetInput ());

   /// <summary>Gets only postive integer from the user</summary>
   static int GetInput () {
      while (true) {
         Console.Write ("Enter a positive integer: ");
         if (int.TryParse (Console.ReadLine (), out int n) && n >= 0) return n;
            Console.WriteLine ("Enter a valid input");
      }
   }

   /// <summary>Checks whether a number is armstrong number or not</summary>
   static void ArmStrong (string tempString) {
      double totalsum = 0;
      for (int i = 0; i < tempString.Length; i++) {
         int digit = int.Parse (tempString[i].ToString ()); // Store each index of string as int
         totalsum += Math.Pow (digit, tempString.Length); ;
      }
      if (totalsum == double.Parse (tempString)) Console.WriteLine ("It is an armstrong number");
      else Console.WriteLine ("It is not an armstrong number");
   }
}