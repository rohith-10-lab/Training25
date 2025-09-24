// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T11 - Armstrong number.
// ------------------------------------------------------------------------------------------------
namespace Training25;

internal class Program {
   static void Main (string[] args) {
      string input = GetInput ();
      ArmStrong (input);
   }
   /// <summary> Gets only postive integer from the user </summary>
   static string GetInput () {
      int n = 0;
      while (true) {
         Console.Write ("Enter a positive integer: ");
         string? input = Console.ReadLine (); //Can accept null value
         if (string.IsNullOrWhiteSpace (input)) {
            Console.WriteLine ("Input cannot be empty");
            continue; //Asks user again for input
         }
         bool isValid = int.TryParse (input, out n); //Checks whether the input is int
         if (!isValid || n < 0) {
            Console.WriteLine ("Enter a valid integer");
            continue;
         }
         break;
      }
      string tempString = n.ToString ();
      return tempString;
   }
   /// <summary> Checks whether a number is armstrong number or not </summary>
   static void ArmStrong (string tempString) {
      double totalsum = 0;
      for (int i = 0; i < tempString.Length; i++) {
         int digit = int.Parse (tempString[i].ToString ()); //Store each index of the string as int
         double sum = Math.Pow (digit, tempString.Length);
         totalsum += sum;
      }
      if (totalsum == double.Parse (tempString)) Console.WriteLine ("It is an armstrong number");
      else Console.WriteLine ("It is not an armstrong number");
   }
}