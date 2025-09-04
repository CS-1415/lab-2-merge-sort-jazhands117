//Jay Johnson 9/03/2025 Lab2 - Merge Sort//

//NTS = Note To Self, for future studying//
//in a frenzy of Google-ing, I went down the rabbit hole of logical operations :) (logic is capitalized in the notes//
//|| = OR operator (returns true if one or more items does), && = AND operator (returns true iff all items do)//


//use packages -- only one is for TDD//
using System.Diagnostics;

//sort function, following pseudocode given!//
static int[] CombineSortedArrays(int[] a, int[] b)
{
    int[] combined = new int[a.Length + b.Length];
    //NTS: new command gives a new array//
    int aIndex = 0;
    int bIndex = 0;

    //NTS: same regular for loop code as i but i=combinedIndex//
    for (int combinedIndex = 0; combinedIndex < combined.Length; combinedIndex++)
    {
        //if b.i is at the end of b OR (a is smaller than b AND a.i is not at the end of a)//
        if (bIndex == b.Length || (aIndex < a.Length && a[aIndex] < b[bIndex]))
        {
            combined[combinedIndex] = a[aIndex];
            aIndex++;
        }
        else
        {
            combined[combinedIndex] = b[bIndex];
            bIndex++;
        }
    }
    return combined;
}

//tests//

//testing two different a,b (already sorted), should output last int[]//
Debug.Assert(Enumerable.SequenceEqual(
    CombineSortedArrays(new int[]{ -5, 2, 5, 8, 10 }, new int[]{ 1, 2, 5 }),
    new int[]{ -5, 1, 2, 2, 5, 5, 8, 10 }));
Debug.Assert(Enumerable.SequenceEqual(
    CombineSortedArrays(new int[]{ 1, 3, 5 }, new int[]{ -5, 3, 6, 7 }),
    new int[]{ -5, 1, 3, 3, 5, 6, 7 }));
Console.WriteLine("All tests passed!");