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
      MyList<int> list = new ();
      for (int i = 0; i <= 4; i++) list.Add (i);
      Write ("Elements in the list: ");
      list.Print ();
      WriteLine ($"Element at index 1: {list[1]}");
      Write ("After removing 4: ");
      list.Remove (4);
      list.Print ();
      Write ("After inserting 4 at index 4: ");
      list.Insert (4, 4);
      list.Print ();
      WriteLine ($"Current Count: {list.Count}");
      WriteLine ($"Current Capacity: {list.Capacity}");
      Write ("After removing element from index 4: ");
      list.RemoveAt (4);
      list.Print ();
      list.Clear ();
      Write ("Elements after clearing the list: ");
      list.Print ();
      WriteLine ($"Current Count: {list.Count}");
      WriteLine ($"Current Capacity: {list.Capacity}");
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
      for (int i = mCnt; i > index; i--) mArray[i] = mArray[i - 1];
      mArray[index] = a;
      mCnt++;
   }

   /// <summary>Removes the element at the specified index</summary>
   public void RemoveAt (int index) {
      ValidateIndex (index);
      for (int i = index; i < mCnt - 1; i++) mArray[i] = mArray[i + 1];
      mCnt--;
      mArray[mCnt] = default!;
   }

   /// <summary>Prints the elements in the list</summary>
   public void Print () {
      for (int i = 0; i < mCnt; i++) Write (mArray[i] + " ");
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
      for (int i = 0; i < mCnt; i++) if (Equals (mArray[i], a)) return i;
      return -1;
   }

   // Validates that the index is within the range of existing elements
   void ValidateIndex (int index) {
      if (index < 0 || index >= mCnt) throw new ArgumentOutOfRangeException (nameof (index));
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] mArray;
   int mCnt;
   #endregion
}
#endregion
