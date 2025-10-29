// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on main branch.
// ------------------------------------------------------------------------------------------------
using System.Collections.Immutable;
using System.Text;

namespace Training25;
internal class Program {
   static void Main () {
      //EvenOdd ();
      string newEven = "";
      string evenRes = "42";
      for (int i = 0; i < evenRes.Length; i++) {
         for (int j = i + 1; j < evenRes.Length; j++) {
            if (evenRes[i] < evenRes[j]) {
               newEven += evenRes[i];
            }
            Console.WriteLine (newEven);
         }
      }
   }
   static void EvenOdd () {
      int inp = 4281357;
      string inpStr = inp.ToString ();
      var even = new StringBuilder ();
      var odd = new StringBuilder ();
      for (int i = 0; i < inpStr.Length; i++) {
         if (inpStr[i] % 2 == 0) even.Append (inpStr[i]);
         else odd.Append (inpStr[i]);
      }
      string evenRes = even.ToString ();
      Console.WriteLine (evenRes);
      string newEven = "";
      for (int i = 0; i < evenRes.Length; i++) {
         for ( int j = i+1; j < evenRes.Length; j++) {
            if (evenRes[i] < evenRes[j]) {
               newEven += evenRes[i];
            }
         }
      }
      string oddRes = odd.ToString ();
      Console.WriteLine (oddRes);
   }
}
