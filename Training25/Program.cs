// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T11 - Armstrong number.
// ------------------------------------------------------------------------------------------------
namespace Training25;

internal class Program {
   static void Main () {
      // GetInput returns a int, it is the parameter for the IsArmStrong.
      // IsArmStrong returns bool, if bool is true IF case executes
      if (IsArmStrong (GetInput ())) {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine ("It is an armstrong number");
      } else {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine ("It is not an armstrong number");
      }
      Console.ForegroundColor = ConsoleColor.White; // The rest of the output is white again
   }

   /// <summary>Gets only positive integer from the user </summary>
   static int GetInput () {
      while (true) {
         Console.ForegroundColor = ConsoleColor.White;
         Console.Write ("Enter a positive integer: ");
         if (int.TryParse (Console.ReadLine (), out int number) && number >= 0) {
            Console.Clear ();  // Clears all the invalid inputs
            Console.WriteLine ($"Enter a positive integer: {number}");
            return number;
         }
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine ("Enter a valid input");
      }
   }

   /// <summary>Checks whether the input is armstrong or not</summary>
   static bool IsArmStrong (int number) {
      string numberString = number.ToString ();
      double totalSum = 0;
      for (int index = 0; index < numberString.Length; index++) {
         /* Converts each index of numberString into int, then raises the power and adds
         it to totalSum*/
         totalSum += Math.Pow (int.Parse (numberString[index].ToString ()), numberString.Length);
      }
      if ((int)totalSum == int.Parse (numberString)) return true;
      else return false;
   }
}
