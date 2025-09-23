// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on main branch.
// ------------------------------------------------------------------------------------------------
int n1;
while (true) {
   Console.Write ("Enter a number: ");
   string input = Console.ReadLine ();
   if (int.TryParse (input, out n1)) break;
   else Console.WriteLine ("Please enter a valid integer");
}
for (int i = 1; i <= 10; i++) {
   Console.WriteLine ($"{n1} * {i,2} = {n1 * i}"); //{i,2} right aligns with width 2
}
Console.ReadKey ();
