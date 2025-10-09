// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to check whether a password is strong or not.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;
using static System.ConsoleColor;

namespace Training25;

internal class Program {
   static void Main () {
      while (true) {
         Write ("Enter a password: ");
         string? pwd = ReadLine ();
         if (string.IsNullOrEmpty (pwd)) { Msg ("Enter a valid input\n"); continue; }
         bool isPwdStrong = TryParsePwd (pwd, out string error);
         Msg (isPwdStrong ? "Password is strong" : "Password is weak",
            isPwdStrong ? Green : Red);
         if (isPwdStrong) break;
         Msg (error);
      }
   }

   // Checks password rules and returns error messages for violations
   static bool TryParsePwd (string pwd, out string error) {
      var sb = new StringBuilder ();
      if (pwd.Length < 6) sb.AppendLine ("Password should have length of at least 6");
      if (pwd.Any (char.IsWhiteSpace)) sb.AppendLine ("Password shouldn't have space");
      if (!pwd.Any (char.IsDigit)) sb.AppendLine ("Password should have at least one digit");
      if (!pwd.Any (char.IsLower))
         sb.AppendLine ("Password should have at least one lowercase letter");
      if (!pwd.Any (char.IsUpper))
         sb.AppendLine ("Password should have at least one Uppercase letter");
      if (!pwd.Any (c => !char.IsLetterOrDigit (c)))
         sb.AppendLine ("Password should have at least one special character");
      error = sb.ToString ();
      return string.IsNullOrEmpty (error);
   }

   // Prints the message in the given colour
   static void Msg (string msg, ConsoleColor color = Yellow) {
      ForegroundColor = color;
      WriteLine (msg);
      ResetColor ();
   }
}
