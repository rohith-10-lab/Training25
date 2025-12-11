// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement a custom MyList<T> class using arrays as underlying data structure.
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Training25;

#region class Program -----------------------------------------------------------------------------
internal class Program {
   static void Main () {
      List<int> list = [];
      MyList<int> myList = new ();
      // Add
      for (int i = 0; i <= 4; i++) {
         list.Add (i);
         myList.Add (i);
      }
      Compare ("After Add", list, myList);
      // Indexing
      list[3] = 99;
      myList[3] = 99;
      Compare ("After (list[3] = 99)", list, myList);
      // Remove value
      list.Remove (4);
      myList.Remove (4);
      Compare ("After Remove(4)", list, myList);
      // Insert
      list.Insert (2, 50);
      myList.Insert (2, 50);
      Compare ("After Insert(2, 50)", list, myList);
      // RemoveAt
      list.RemoveAt (1);
      myList.RemoveAt (1);
      Compare ("After RemoveAt(1)", list, myList);
      // Count and capacity
      WriteLine ($"\nDefault List -> Count: {list.Count}, Capacity: {list.Capacity}");
      WriteLine ($"MyList       -> Count: {myList.Count}, Capacity: {myList.Capacity}");
      // Exception test
      WriteLine ("\nException test");
      // Default List – index get
      try {
         WriteLine ("Default List index 100 get:");
         WriteLine (list[100]);
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // MyList – index get
      try {
         WriteLine ("MyList index 100 get:");
         WriteLine (myList[100]);
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // Default List – index set
      try {
         WriteLine ("\nDefault List index 100 set:");
         list[100] = 1;
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // MyList – index set
      try {
         WriteLine ("MyList index 100 set:");
         myList[100] = 1;
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // Default List – Insert invalid
      try {
         WriteLine ("\nDefault List Insert(100, 1):");
         list.Insert (100, 1);
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // MyList – Insert invalid
      try {
         WriteLine ("MyList Insert(100, 1):");
         myList.Insert (100, 1);
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // Default List – RemoveAt invalid
      try {
         WriteLine ("\nDefault List RemoveAt(100):");
         list.RemoveAt (100);
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // MyList – RemoveAt invalid
      try {
         WriteLine ("MyList RemoveAt(100):");
         myList.RemoveAt (100);
      } catch (Exception ex) { WriteLine (ex.GetType ().Name); }
      // Other Data type tests
      WriteLine ("\nTest with tuple");
      List<(int, string)> tup1 = [(1, "one"), (2, "two")];
      MyList<(int, string)> tup2 = new ();
      tup2.Add ((1, "one"));
      tup2.Add ((2, "two"));
      Compare ("Tuple test", tup1, tup2);
      // Test with string
      WriteLine ("\nTest with string");
      List<string> str3 = ["xyz", "abc"];
      MyList<string> str4 = new ();
      str4.Add ("xyz");
      str4.Add ("abc");
      Compare ("String test", str3, str4);

      // Checks whether List<T> and MyList<T> contain identical elements and prints PASS/FAIL
      static void Compare<T> (string msg, List<T> l, MyList<T> m) {
         bool equal = l.Count == m.Count;
         for (int i = 0; equal && i < l.Count; i++)
            equal = EqualityComparer<T>.Default.Equals (l[i], m[i]);
         WriteLine (equal ? $"{msg}: PASS" : $"{msg}: FAIL");
      }
   }
}
#endregion

#region class MyList<T> ---------------------------------------------------------------------------
class MyList<T> {

   #region Constructor ----------------------------------------------
   /// <summary>Constructor that initializes a new list with the default capacity</summary>
   public MyList () {
      mArray = new T[DEFCAP];
      mCnt = 0;
   }
   #endregion

   #region Properties -----------------------------------------------
   /// <summary>Gets the number of elements currently stored in the list</summary>
   public int Count => mCnt;

   /// <summary>Gets the current capacity of the list</summary>
   public int Capacity => mArray.Length;

   /// <summary>Gets or sets the element at the specified index</summary>
   public T this[int index] {
      get { // executes when a value is read
         if (index < 0 || index >= mCnt) throw new IndexOutOfRangeException ();
         return mArray[index];
      }
      set { // executes when a value is written
         if (index < 0 || index >= mCnt) throw new IndexOutOfRangeException ();
         mArray[index] = value;
      }
   }
   #endregion

   #region Methods --------------------------------------------------
   /// <summary>Adds the element at the end of the list</summary>
   public void Add (T a) {
      CheckCapacity ();
      mArray[mCnt++] = a;
   }

   /// <summary>Removes the first occurrence of the given element</summary>
   public bool Remove (T a) {
      int idx = IndexOf (a);
      if (idx == -1) return false;
      RemoveAt (idx);
      return true;
   }

   /// <summary>Clears all stored elements while keeping the current capacity unchanged</summary>
   public void Clear () {
      Array.Clear (mArray, 0, mCnt);
      mCnt = 0;
   }

   /// <summary>Inserts the element at the specified index</summary>
   public void Insert (int index, T a) {
      if (index < 0 || index > mCnt) throw new ArgumentOutOfRangeException (nameof (index));
      CheckCapacity ();
      Array.Copy (mArray, index, mArray, index + 1, mCnt - index);
      mArray[index] = a;
      mCnt++;
   }

   /// <summary>Removes the element at the specified index</summary>
   public void RemoveAt (int index) {
      if (index < 0 || index >= mCnt) throw new ArgumentOutOfRangeException (nameof (index));
      Array.Copy (mArray, index + 1, mArray, index, mCnt - index - 1);
      mArray[mCnt--] = default!;
   }

   /// <summary>Prints the elements in the list</summary>
   public void Print () {
      for (int i = 0; i < mCnt; i++) Write ($"{mArray[i]} ");
      WriteLine ();
   }
   #endregion

   #region Implementation -------------------------------------------
   // Ensures there is enough capacity to add a new element, expanding when necessary
   void CheckCapacity () {
      if (mCnt < Capacity) return;
      T[] newArr = new T[Capacity == 0 ? DEFCAP : Capacity * 2];
      Array.Copy (mArray, newArr, mCnt);
      mArray = newArr;
   }

   // Returns the index of the first matching element
   int IndexOf (T a) {
      for (int i = 0; i < mCnt; i++)
         if (EqualityComparer<T>.Default.Equals (mArray[i], a)) return i;
      return -1;
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] mArray;
   int mCnt;
   const int DEFCAP = 4;
   #endregion
}
#endregion
