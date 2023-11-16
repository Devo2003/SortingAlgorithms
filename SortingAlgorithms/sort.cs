using System;
namespace SortingAlgorithms
{
	public class sort
	{
		public int[] Nums;
		public string[] fileLines;
		public string fileDirectory;
		public sort()
		{
			//Nums = new int[] {1,4,2,3 };
			//this line gives in the path of the file into a string
			fileDirectory = "/Users/devinsalgado35/Desktop/SortingAlgorithms/SortingAlgorithms/scores.txt";
			Nums = fileCovertToArray(fileDirectory);

        }

		public int[] fileCovertToArray(string fileDirectory)
		{
            fileLines = File.ReadAllLines(fileDirectory);

            Nums = new int[fileLines.Length];
            //int value;
            for (int i = 0; i < fileLines.Length; i++)
            {
                if (int.TryParse(fileLines[i], out int value))
                {
                    Nums[i] = value;
                }
            }
            return Nums;
        }

        public void printArray(int[] Nums)
		{
			foreach (var item in Nums)
			{
				Console.WriteLine(item);
			}
		}

		

        // Name: BubbleSort Algorithm
        // Description:
        // O(n^2) average and worst case

        public void BubbleSort(int[] data)
		{
			for (int i = 0; i < Nums.Length; i++)
			{
				for (int j = 0; j < Nums.Length - 1; j++)
				{
					if (Nums[j] > Nums[j+1])
					{
						int temp = Nums[j];
						Nums[j] = Nums[j + 1];
						Nums[j + 1] = temp;
                        //printArray(Nums);
						
                    }
				}
			}
            printArray(Nums);
        }


        public void InsertionSort(int[] data)
        {
            for (int i = 1; i < Nums.Length; i++)
            {
				int j = 0;
				j = i - 1;

                int temp = Nums[i];

				while (j>= 0 && Nums[j] > temp)
				{
					Nums[j + 1] = Nums[j];
					j--;
				}
				Nums[j + 1] = temp;
               
				
            }
            printArray(Nums);
        }
        public void SelectionSort(int[] data)
        {
			for (int i = 0; i < Nums.Length - 1; i++)
			{
				int minIndex = i;
				for (int j = i +1; j < Nums.Length; j++)
				{
					if (Nums[j] < Nums[minIndex])
					{
						minIndex = j;
					}

				}
				//Similar to insertion
                int temp = Nums[minIndex];
                Nums[minIndex] = Nums[i];
                Nums[i] = temp;

            }
			printArray(Nums);
        }
		
		public void HeapSort(int[] data)
		{
			//the creation of the Max heap from the array Nums
			for (int i = Nums.Length/2 - 1; i >= 0; i--)
			{
				Heapify(Nums, Nums.Length, i);
			}
			//Extracts the elements one by one
			for (int i = Nums.Length - 1; i > 0; i--)
			{
				//similar to insertion sort
                int temp = Nums[0];
                Nums[0] = Nums[i];
                Nums[i] = temp;
				//reduces heap
				Heapify(Nums, i, 0);
            }
            printArray(Nums);
        }

        private void Heapify(int[] Nums, int n , int i)
        {
			int largestRoot = i;
			int l = 2 * i + 1;
			int r = 2 * i + 2;

			if (l < n && Nums[l] > Nums[largestRoot])
			{
				largestRoot = l;
			}

			if (r < n && Nums[r] > Nums[largestRoot])
			{
				largestRoot = r;
			}

			if (largestRoot != i)
			{
                int temp = Nums[i];
                Nums[i] = Nums[largestRoot];
                Nums[largestRoot] = temp;

				Heapify(Nums, n, largestRoot);
            }
			
        }

        public void QuickSort(int[] data, int low, int high)
        {
			if (low<high)
			{
				int partitionIndex = Partitionn(Nums, low, high);

				QuickSort(Nums, low, partitionIndex - 1);
				QuickSort(Nums, partitionIndex + 1, high);
			}
			printArray(Nums);
        }

        private int Partitionn(int[] Nums, int low, int high)
        {
			int pivot = Nums[high];

			int i = low - 1;

			for (int j = low; j < high; j++)
			{
				if (Nums[j] <= pivot)
				{
					i++;

                    int temp = Nums[i];
                    Nums[i] = Nums[j];
                    Nums[j] = temp;

                }
            }

            int tempPivot = Nums[i + 1];
            Nums[i + 1] = Nums[high];
            Nums[high] = tempPivot;

			return i + 1;
        }



        public void MergeSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                // Find the middle point of the array
                int middle = left + (right - left) / 2;

                // Recursively sort the first and second halves
                MergeSort(data, left, middle);
                MergeSort(data, middle + 1, right);

                // Merge the sorted halves
                Merge(data, left, middle, right);
            }
            printArray(Nums);
        }

        public void Merge(int[] data, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temporary arrays
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // move data to temporary arrays
            for (int i = 0; i < n1; i++)
            {
                leftArray[i] = data[left + i];
            }
            for (int j = 0; j < n2; j++)
            {
                rightArray[j] = data[middle + 1 + j];
            }

            // Merge the temporary arrays

            // create indexes for the merged subarray
            int LeftIndx = 0, RightIndx = 0;

            // create index for the merged subarray
            int k = left;
            while (LeftIndx < n1 && RightIndx < n2)
            {
                if (leftArray[LeftIndx] <= rightArray[RightIndx])
                {
                    data[k] = leftArray[LeftIndx];
                    LeftIndx++;
                }
                else
                {
                    data[k] = rightArray[RightIndx];
                    RightIndx++;
                }
                k++;
            }

            // Copy remaining elements of leftArray[], if there are any
            while (LeftIndx < n1)
            {
                data[k] = leftArray[LeftIndx];
                LeftIndx++;
                k++;
            }

            // Copy remaining elements of rightArray[], if there are any available
            while (RightIndx < n2)
            {
                data[k] = rightArray[RightIndx];
                RightIndx++;
                k++;
            }
        }
    }
}
//Summary:
/* So when comparing all of these the first three algorithms we 
 * read about and is done in this project are the most similar compared to the 
 * other last three. All these algorithms have diffeence of how to they sort through the 
 * array some just swap by comparing two values and just moving on from left to right 
 * then the others contain and compare with a value temp and others like the last two 
 * algorithms tend to search in a more complex way where they start searching and swaping values in other starting locations of the 
 * array other than the first index in the array like looking in the middle or the end for an examples
 * (I don't like these they make my head hurt). Also the first 3 algothrims are used more for a smaller size collections of arrays 
 * while the more complex more is more built to search for giants collections of data.
 * 
 */ 
  
  
  
  
  
  
 
  
  
  


