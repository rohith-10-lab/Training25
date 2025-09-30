// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on T03 - LCM and GCD generator.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training25;

internal class Program {
   static void Main () {
      int count = GetInput ("Enter how many numbers you want to calculate GCD for: ", 2);
      int[] numbers = new int[count];
      long product = 1;
      for (int index = 0; index < count; index++) {
         // Checks for the last number
         if (index == count - 1) {
            bool zero = true;
            // Checks if the previous indices have 0
            for (int prevIndex = 0; prevIndex < index; prevIndex++)
               if (numbers[prevIndex] != 0) zero = false;
            if (zero) {
               do {
                  numbers[index] = GetInput ($"Enter number {index + 1} greater than zero: ");
                  if (numbers[index] == 0) WarningMsg ("Last number can't be zero, " +
                         "if the rest of the numbers are zero");
               } while (numbers[index] == 0);
               product *= numbers[index];
               continue;
            }
         }
         numbers[index] = GetInput ($"Enter number {index + 1}: ");
         product *= numbers[index];
      }
      int result = numbers[0];
      for (int index = 1; index < count; index++) result = Gcd (result, numbers[index]);
      WriteLine ($"The GCD of the given numbers is {result}");
      WriteLine ($"The LCM of the given numbers is {product / result}");
   }

   // Gets only positive number from the user
   static int GetInput (string prompt, int min = 0) {
      while (true) {
         Write (prompt);
         if (int.TryParse (ReadLine (), out int num) && num >= min) return num;
         WarningMsg ("Enter a valid input");
      }
   }

   // Calculates GCD using Euclidean algorithm
   static int Gcd (int num1, int num2) => (num2 == 0) ? num1 : Gcd (num2, num1 % num2);

   // Prints the warning prompt
   static void WarningMsg (string msg) {
      ForegroundColor = ConsoleColor.Yellow;
      WriteLine (msg);
      ResetColor ();
      Write ("Press any key to continue...");
      ReadKey ();
      Clear ();
   }
}
