// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to guess a number.
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

namespace Training25;

internal class Program {
   static void Main () {
      string playAgain;
      do {
         Clear ();
         int targetNum = new Random ().Next (1, 101);
         for (int tries = 1; tries <= 7; tries++) {
            int inp = GetInput (tries);
            var (msg, color) = CheckGuess (inp, targetNum, tries);
            PrintMsg (msg, color);
            if (inp == targetNum) break;
         }
         PrintMsg ("GAME OVER!\n", Red);
         Write ("Play again? (y/n): ");
         playAgain = ReadLine ()?.Trim ().ToLower () ?? "n";
      } while (playAgain == "y");
   }

   // Comapres the input with the target number and returns a feedback message with a color
   static (string, ConsoleColor) CheckGuess (int inp, int targetNum, int cnt) {
      if (inp < targetNum) return ("Your guess is too low\n", Yellow);
      if (inp > targetNum) return ("Your guess is too high\n", Yellow);
      return ($"You guessed correctly in {cnt} attempts\n", Green);
   }

   // Gets only integer as input from the user
   static int GetInput (int cnt) {
      for (; ; ) {
         Write ($"Attempt {cnt}! Guess a number between 1 and 100: ");
         if (int.TryParse (ReadLine (), out int inp) && inp is not < 1 or > 100) return inp;
         else PrintMsg ("Enter a valid input.\n", Yellow);
      }
   }

   // Prints the message in given color
   static void PrintMsg (string msg, ConsoleColor color) {
      ForegroundColor = color;
      WriteLine (msg);
      ResetColor ();
   }
}
