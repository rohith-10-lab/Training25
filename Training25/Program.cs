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
      // Integer test
      WriteLine ("INTEGER TEST");
      var intList = new List<int> ();
      var intMyList = new MyList<int> ();
      TestAdd ([0, 1, 2, 3, 4], intList, intMyList);
      TestIndexing (3, 99, intList, intMyList);
      TestRemove (4, intList, intMyList);
      TestInsert (2, 50, intList, intMyList);
      TestRemoveAt (1, intList, intMyList);
      TestClear (intList, intMyList);
      // Tuple test
      WriteLine ("\nTUPLE TEST");
      var tupList = new List<(int, string)> ();
      var tupMyList = new MyList<(int, string)> ();
      TestAdd ([(1, "one"), (2, "two")], tupList, tupMyList);
      TestIndexing (1, (99, "changed"), tupList, tupMyList);
      TestRemove ((1, "one"), tupList, tupMyList);
      TestInsert (0, (5, "five"), tupList, tupMyList);
      TestRemoveAt (1, tupList, tupMyList);
      TestClear (tupList, tupMyList);
      // String test
      WriteLine ("\nSTRING TEST");
      var strList = new List<string> ();
      var strMyList = new MyList<string> ();
      TestAdd (["abc", "xyz"], strList, strMyList);
      TestIndexing (1, "updated", strList, strMyList);
      TestRemove ("abc", strList, strMyList);
      TestInsert (1, "new", strList, strMyList);
      TestRemoveAt (1, strList, strMyList);
      TestClear (strList, strMyList);

      // Adds the given elements to both lists and compares the results
      void TestAdd<T> (T[] values, List<T> l, MyList<T> m) {
         foreach (var v in values) {
            l.Add (v);
            m.Add (v);
         }
         PrintResult ("After Add", l, m);
      }

      // Sets the element at the given index in both lists and compares the results
      void TestIndexing<T> (int index, T value, List<T> l, MyList<T> m) {
         l[index] = value;
         m[index] = value;
         PrintResult ("After Indexing", l, m);
      }

      // Removes the given element from both lists and compares the results
      void TestRemove<T> (T value, List<T> l, MyList<T> m) {
         l.Remove (value);
         m.Remove (value);
         PrintResult ("After Remove", l, m);
      }

      // Inserts the element at the given index in both lists and compares the results
      void TestInsert<T> (int index, T value, List<T> l, MyList<T> m) {
         l.Insert (index, value);
         m.Insert (index, value);
         PrintResult ("After Insert", l, m);
      }

      // Removes the element at the given index in both lists and compares the results
      void TestRemoveAt<T> (int index, List<T> l, MyList<T> m) {
         l.RemoveAt (index);
         m.RemoveAt (index);
         PrintResult ("After RemoveAt", l, m);
      }

      // Clears both lists and compares the results
      void TestClear<T> (List<T> l, MyList<T> m) {
         l.Clear ();
         m.Clear ();
         PrintResult ("After Clear", l, m);
      }

      // Checks whether both lists have the same count, capacity, and elements
      bool IsEqual<T> (List<T> l, MyList<T> m) {
         if (l.Count != m.Count || l.Capacity != m.Capacity) return false;
         for (int i = 0; i < l.Count; i++)
            if (!EqualityComparer<T>.Default.Equals (l[i], m[i])) return false;
         return true;
      }

      // Prints PASS or FAIL based on whether the two lists are equal
      void PrintResult<T> (string msg, List<T> l, MyList<T> m)
         => WriteLine ($"{msg}: {(IsEqual (l, m) ? "PASS" : "FAIL")}");
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
         ValidateIndex (index);
         return mArray[index];
      }
      set { // executes when a value is written
         ValidateIndex (index);
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

   /// <summary>Removes the first occurrence of the given element</summary>
   public bool Remove (T a) {
      int idx = Array.IndexOf (mArray, a, 0, mCnt);
      if (idx < 0) return false;
      ValidateIndex (idx);
      RemoveAt (idx);
      return true;
   }

   /// <summary>Removes the element at the specified index</summary>
   public void RemoveAt (int index) {
      if (index < 0 || index >= mCnt) throw new ArgumentOutOfRangeException (nameof (index));
      mCnt--;
      Array.Copy (mArray, index + 1, mArray, index, mCnt - index);
      mArray[mCnt] = default!;
   }
   #endregion

   #region Implementation -------------------------------------------
   // Ensures there is enough capacity to add a new element, expanding when necessary
   void CheckCapacity () {
      if (mCnt < Capacity) return;
      Array.Resize (ref mArray, Capacity == 0 ? DEFCAP : Capacity * 2);
   }

   // Validates that the index refers to existing element in the list
   void ValidateIndex (int index) {
      if (index < 0 || index >= mCnt) throw new IndexOutOfRangeException ();
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] mArray;
   int mCnt;
   const int DEFCAP = 4;
   #endregion
}
#endregion
