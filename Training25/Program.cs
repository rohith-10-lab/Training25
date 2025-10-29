// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to sort digit by even and odd.
// ------------------------------------------------------------------------------------------------
using System.Collections.Immutable;
using System.Text;

namespace Training25;
internal class Program {
   static void Main () {
      EvenOdd ();
   }
   static void EvenOdd () {
      int inp = 987654;
      string inpStr = inp.ToString ();
      var even = new StringBuilder ();
      var odd = new StringBuilder ();
      for (int i = 0; i < inpStr.Length; i++) {
         if (inpStr[i] % 2 == 0) even.Append (inpStr[i]);
         else odd.Append (inpStr[i]);
      }
      string res = even.ToString() + odd.ToString();
      Console.WriteLine (res);
      // initially tried orderbydecending the even string and then reversing it, which didn't work
      // so, tried this to rearrange the even number in ascending order

      //string newEven = "";
      //string evenRes = even.ToString();
      //for (int i = 0; i < evenRes.Length; i++) {
      //   for (int j = i + 1; j < evenRes.Length; j++) {
      //      if (evenRes[i] < evenRes[j]) {
      //         newEven += evenRes[i];
      //      }
      //   }
      //}
      //Console.WriteLine (newEven);
   }
}
