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
      Write ("Default List after Add: ");
      PrintList (list);
      Write ("MyList after Add:       ");
      myList.Print ();
      // Indexing
      list[3] = 99;
      myList[3] = 99;
      Write ("\nDefault List after (list[3] = 99): ");
      PrintList (list);
      Write ("MyList after (myList[3] = 99):     ");
      myList.Print ();
      // Remove value
      list.Remove (4);
      myList.Remove (4);
      Write ("\nDefault List after Remove(4): ");
      PrintList (list);
      Write ("MyList after Remove(4):       ");
      myList.Print ();
      // Insert
      list.Insert (2, 50);
      myList.Insert (2, 50);
      Write ("\nDefault List after Insert(2, 50): ");
      PrintList (list);
      Write ("MyList after Insert(2, 50):       ");
      myList.Print ();
      // Remove at
      list.RemoveAt (1);
      myList.RemoveAt (1);
      Write ("\nDefault List after RemoveAt(1): ");
      PrintList (list);
      Write ("MyList after RemoveAt(1):       ");
      myList.Print ();
      // Count and capacity
      WriteLine ($"\nDefault List -> Count: {list.Count}, Capacity: {list.Capacity}");
      WriteLine ($"MyList ->       Count: {myList.Count}, Capacity: {myList.Capacity}");

      // Helper method for default List<T> to print the elements in the list
      static void PrintList (List<int> list) {
         foreach (int item in list) Write ($"{item} ");
         WriteLine ();
      }
   }
}
#endregion

#region class MyList<T> ---------------------------------------------------------------------------
class MyList<T> {

   #region Constructor ----------------------------------------------
   /// <summary>Constructor that initializes a new list with the default capacity</summary>
   public MyList () {
      mArray = new T[4];
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
      mCnt--;
      mArray[mCnt] = default!;
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
      int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
      T[] newArr = new T[newCapacity];
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
   #endregion
}
#endregion
