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
      if (IsArmStrong (GetInput ())) PrintMessage ("It is an armstrong number", ConsoleColor.Green);
      else PrintMessage ("It is not an armstrong number", ConsoleColor.Red);
   }

   /// <summary>Gets only positive integer from the user </summary>
   static int GetInput () {
      while (true) {
         Console.Write ("Enter a positive integer: ");
         if (int.TryParse (Console.ReadLine (), out int number) && number >= 0) return number;
         PrintMessage ("Enter a valid input\n", ConsoleColor.Yellow);
         Console.Write ("Press any key to continue...");
         Console.ReadKey ();
         Console.Clear ();
      }
   }

   /// <summary>Checks whether the input is armstrong or not</summary>
   static bool IsArmStrong (int number) {
      string numStr = number.ToString ();
      int totalSum = 0;
      foreach (char index in numStr) {
         totalSum += (int)Math.Pow ((index - '0'), numStr.Length);
      }
      return totalSum == number;
   }

   /// <summary>Prints the message in the console with a specified color</summary>
   static void PrintMessage (string message, ConsoleColor color) {
      Console.ForegroundColor = color;
      Console.Write (message);
      Console.ResetColor ();
   }
}
