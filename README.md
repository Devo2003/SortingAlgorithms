# SortingAlgorithms

Note: I used a diffrent timer to calculate the times. I used the System.Diagnostics stopwatch for a simple time display.

BubbleSort Algorithm

The algorithm sorts an array of items going from left to right in an ascending order. To be more specific it compares the two adjacent elements from the array's starting point and moves the least number between the two up front. The other number is inserted into a temporary variable. After it's finished moving the element upfront we move the temp variable value to the empty spot. Then it repeats this process until everything is in order.

O(n^2) average and worst case

Bubblesort(Data: values[])
    // Repeat until the array is sorted.
    Boolean: not_sorted = True
    While (not_sorted)
        // Assume we won't find a pair to swap.
        not_sorted = False
        // Search the array for adjacent items that are out of order.
        For i = 0 To <length of values> - 1
// See if items i and i - 1 are out of order.
            If (values[i] < values[i - 1]) Then
                // Swap them.
                Data: temp = values[i]
                values[i] = values[i - 1]
                values[i - 1] = temp
 
                // The array isn't sorted after all.
                not_sorted = True
            End If
        Next i
    End While
End Bubblesort  



It took 66 milliseconds to complete


InsertionSort Algorithm
The algorithm sorts an array of items going from left to right in an ascending order. To be more specific it first locates the value at index 1 and stores that value inside a variable like temp. Then it compares the value inside temp with the value at index 0. If the temp variable is bigger it compares the number with the next index with a value. Now if it's smaller it then replaces the value at index 0 and moves that value to the next spot that is empty. It repeats this until everything is in order. 


 best case: O(n) and worst case: O(n^2)

Insertionsort(Data: values[])
   For i = 0 To <length of values> - 1
       // Move item i into position 
       //in the sorted part of the array
       < Find  the first index j where
         j < i and values[j] > values[i].>
       <Move the item into position j.>
   Next i
End Insertionsort


It took 97 milliseconds to complete. 


SelectionSort Algorithm
The algorithm sorts an array of items going from left to right in an ascending order. To be more specific it takes the first index in the array and stores it into a minimum variable where it compares all the numbers inside the array with itself. Once it finds a smaller number compared to the one in the minimum variable it swaps the number. If the number in the minimum value is the least number from the whole array it should place that number all the way to the start at index 0 and put the number that was at that location into the temp variable after that is complete the temp value should go right after the now replaced index 0. And repeats that whole process again.

O(n^2) average and worst case

Selectionsort(Data: values[])
    For i = 0 To <length of values> - 1
        // Find the item that belongs in position i.
        <Find the smallest item with index j >= i.>
        <Swap values[i] and values[j].>
    Next i
End Selectionsort  

It took 77 milliseconds to complete. 

HeapSort Algorithm

We call max heap to figure out the highest number and put it to index 0 and after you swap the 0 index with the very last index. The algorithm considers that to be sorted out for the last index being the last. So when it repeats it no longer checks the very last index it checks the second to last index. It's like it's working backwards from right to left instead of left to right. This is also sometimes displayed as a tree instead of a linear array.

O(n log n)

Heapsort(Data: values)
    <Turn the array into a heap.>
 
    For i = <length of values> - 1 To 0 Step -1
        // Swap the root item and the last item.
        Data: temp = values[0]
        values[0] = values[i]
        values[i] = temp
 
        <Consider the item in position i to be removed from the heap,
         so the heap now holds i - 1 items. Push the new root value
         down into the heap to restore the heap property.>
    Next i
End Heapsort  

It took 83 milliseconds to complete. 

QuickSort Algorithm

You need to pass the array as an argument to the function. Here you decide a pivot which can be at the start, middle and end. From what I heard most times the pivot starts at the end. Here we have two variables named j and i. I start at index 0 and j is at index minus i. Here we just compare the values i and the pivot to see if they are lower than the value set on the pivot. If it's equal, or greater we ignore it and move on to the next index so we add i. J now takes place at index o and i at index 1. The algorithm takes the value at j and copies it to a temp variable and also swaps the values of I and J and the temp value is put to the i variable. In the terms I understand is that I and j swap values if the i is greater than j. Once J reaches the pivot(end) we swap the values with I and the pivot should be in the middle telling us that numbers on the left(partition1) should be less than the pivot and numbers on the right(Partition 2) should be greater. Here we repeat the same process like the first time, but just with the first partition and 2 second partition the pivot is not counted here for either.

O(n log n) on average
Worst case is O(n^2).

algorithm quicksort(A, lo, hi) is
    if lo < hi then
        p := pivot(A, lo, hi)
        left, right := partition(A, p, lo, hi)  // note: multiple return values
        quicksort(A, lo, left - 1)
        quicksort(A, right + 1, hi)

It took 5852 milliseconds to complete. 



MergeSort Algorithm

This algorithm has the divide and conquer strategy. This means the function divides the array into two sub arrays. You keep dividing until the array size is one. We then start merging the values into twos one set on the left and another on the right and comparing them which is the least and greatest. The left is the least value and right is the largest value. Once sorted in one set we move on to the right set to repeat the process before this. Then we compare both sets with each other to reorder and continue that process until everything is reorder. 

average and worst-case performance of O(n log n).

Mergesort(Data: values[], Data: scratch[], Integer: start, Integer: end)
    // If the array contains only one item, it is already sorted.

If (start == end) Then Return
 
    // Break the array into left and right halves.
    Integer: midpoint = (start + end) / 2
 
    // Call Mergesort to sort the two halves.
    Mergesort(values, scratch, start, midpoint)
    Mergesort(values, scratch, midpoint + 1, end)
 
    // Merge the two sorted halves.
    Integer: left_index = start
    Integer: right_index = midpoint + 1
    Integer: scratch_index = left_index
    While ((left_index <= midpoint) And (right_index <= end))
        If (values[left_index] <= values[right_index]) Then
            scratch[scratch_index] = values[left_index]
            left_index = left_index + 1
        Else
            scratch[scratch_index] = values[right_index]
            right_index = right_index + 1
        End If
        scratch_index = scratch_index + 1    End While
 
    // Finish copying whichever half is not empty.
    For i = left_index To midpoint
        scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    For i = right_index To end

scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    // Copy the values back into the original values array.
    For i = start To end
        values[i] = scratch[i]
    Next i
End Mergesort


It took 6514 milliseconds to complete. 

