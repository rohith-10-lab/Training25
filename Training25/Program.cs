// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to check whether a password is strong or not.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

internal class Program {
   static void Main () {
      while (true) {
         Write ("Enter a password: ");
         string? pwd = ReadLine ();
         if (string.IsNullOrEmpty (pwd)) {
            Msg ("Enter a valid input\n");
            continue;
         }
         string result = PwdParse (pwd);
         if (string.IsNullOrEmpty (result)) {
            Msg ("Password is strong", ConsoleColor.Green);
            break;
         } else Msg (result);
      }
   }

   // Checks password rules and returns error messages for violations
   static string PwdParse (string pwd) {
      string errors = "";
      bool hasDigit = false, hasLower = false, hasUpper = false, hasSpecial = false,
          hasSpace = false;
      foreach (char c in pwd) {
         if (char.IsWhiteSpace (c)) hasSpace = true;
         if (char.IsDigit (c)) hasDigit = true;
         if (char.IsLower (c)) hasLower = true;
         if (char.IsUpper (c)) hasUpper = true;
         if (!char.IsLetterOrDigit (c)) hasSpecial = true;
      }
      if (pwd.Length < 6) errors += "Enter password with length of at least 6\n";
      if (hasSpace) errors += "Enter password without space\n";
      if (!hasDigit) errors += "Enter at least one digit\n";
      if (!hasLower) errors += "Enter at least one lowercase letter\n";
      if (!hasUpper) errors += "Enter at least one Uppercase letter\n";
      if (!hasSpecial) errors += "Enter at least one special character\n";
      return errors;
   }

   // Prints the message in the given colour
   static void Msg (string msg, ConsoleColor color = ConsoleColor.Yellow) {
      ForegroundColor = color;
      WriteLine (msg);
      ResetColor ();
   }
}
