//Jay Johnson 9/03/2025 Lab2 - Merge Sort//

//NTS = Note To Self, for future studying//
//in a frenzy of Google-ing, I went down the rabbit hole of logical operations :) (logic is capitalized in the notes//
//|| = OR operator (returns true if one or more items does), && = AND operator (returns true iff all items do)//


//use packages -- only one is for TDD//
using System.Diagnostics;

//sort function, following pseudocode given!//
static int[] CombineSortedArrays(int[] a, int[] b)
{
    int[] combined = new int[a.Length + b.Length]; //NTS: new command gives a new array//
    
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

//merge function, takes one array and spits it out sorted, then shoves it into the combination//
//NTS: .. is the operator that pulls a chunk of range (i.e 0..middle pulls [0,middle])//
static int[] SortViaMergesort(int[] values)
{
    if (values.Length < 2)
    {
        return (int[])values.Clone(); //returns new array with same values -- no weird memory issues if changed!//
                                      //note, I did have to ChatGPT how to return a COPY of the values, for honesty's sake//
    }
    else
    {
        int middle = values.Length / 2;
        int[] firstHalf = values[0..middle];
        int[] secondHalf = values[middle..values.Length];

        int[] firstSorted = SortViaMergesort(firstHalf);
        int[] secondSorted = SortViaMergesort(secondHalf);

        return CombineSortedArrays(firstSorted, secondSorted);
    }
}

//tests//

//testing two different a,b (already sorted), should output last int[]//
Debug.Assert(Enumerable.SequenceEqual(
    CombineSortedArrays(new int[]{ -5, 2, 5, 8, 10 }, new int[]{ 1, 2, 5 }),
    new int[]{ -5, 1, 2, 2, 5, 5, 8, 10 })); //expected output//
Debug.Assert(Enumerable.SequenceEqual(
    CombineSortedArrays(new int[]{ 1, 3, 5 }, new int[]{ -5, 3, 6, 7 }),
    new int[]{ -5, 1, 3, 3, 5, 6, 7 })); //expected output//
Console.WriteLine("All combination tests passed!");

//testing a single array for merge sort//
Debug.Assert(Enumerable.SequenceEqual(
    SortViaMergesort(new int[]{7,1,-5,6,3,5,3}),
    new int[]{-5,1,3,3,5,6,7})); //expected output//
Debug.Assert(Enumerable.SequenceEqual(
    SortViaMergesort(new int[]{2,10,5,-5,1,2,8,5}),
    new int[]{-5,1,2,2,5,5,8,10})); //expected output//
Console.WriteLine("All merge sort tests passed!");