# Data Structures and Algorithms implemented using C#
## Algorithms
> An algorithm is a finite sequence of well-defined, computer-implementable instructions, typically to solve a class of specific problems or to perform computation.

### Classification (_as per Wiki_)
1. Searching algorithms
	1. Binary search
	2. Fast search
	3. Jump search
	4. Linear search
2. Sorting algorithms
	1. Simple sorts
		1. [Insertion sort](#insertion-sort "Go to Insertion sort")
		2. [Selection sort](#selection-sort "Go to Selection sort")
	2. Efficient sorts
		1. [Merge sort](#merge-sort "Go to Merge sort")
		2. [Heap sort](#heap-sort "Go to Heap sort")
		3. [Quick sort](#quick-sort "Go to Quick sort")
		4. [Shell sort](#shell-sort "Go to Shell sort")
	3. Bubble sort and variants
		1. [Bubble sort](#bubble-sort "Go to Bubble sort")
		2. [Comb sort](#comb-sort "Go to Comb sort")
		3. [Exchange sort](#exchange-sort "Go to Exchange sort")
	5. Distribution sorts
		1. [Counting sort](#counting-sort "Go to Counting sort")
		2. [Bucket sort](#bucket-sort "Go to Bucket sort")
		3. [Radix sort](#radix-sort "Go to Radix sort")

#### Insertion sort
First go through [_Why is insertion sort Θ(n^2) in average cases?_](https://stackoverflow.com/questions/17055341/why-is-insertion-sort-%ce%98n2-in-the-average-case/17055342#17055342).
> The algorithm iterates, consuming one input element each repetition, and grows a sorted output list.<br>
> At each iteration, it removes one element from the input data, finds the location it belongs withing the sorted list, and inserts it there. It repeats until no input elements remain.<br>
> <br>
> **Best case&#8594; When an array is already sorted:** It has a linear running time (**_Θ(n)_**). During each iteration, the first remaining element of the input is only compared with the right-most element of the sorted subsection of the array.<br>
> **Worst case&#8594; When an array is sorted in reverse:** It has a quadratic running time (**_Θ(n^2)_**). During each iteration, the inner loop will compare and shift the entire sorted subsection of the array before inserting the next element.<br>
> **Average case&#8594;** It has a quadratic running time (**_Θ(n^2)_**).<br>
> <br>
> This makes the _InsertionSort_ impractical for sorting large arrays. However, it is one of the fastest algorithms for sorting very small arrays, even faster than _QuickSort_; indeed, good _QuickSort_ implementations use _InsertionSort_ for arrays smaller than a certain threshold, also when arising as subproblems; the exact threshold must be determined experimentally and depends on the machine, but is commonly around ten.

#### Selection sort
> Working of the algorithm&#8594;<br>
> 	1. Divides the input list into two parts:<br>
> 		1. A sorted sublist of items which is built up from left to right at the front (left) of the list.<br>
> 		2. A sublist of the remaining unsorted items that occupy the rest of the list.<br>
> 	2. Find the smallest element in the unsorted sublist.<br>
> 	3. Exchange/swap itwith left most unsorted element and moving the sublist boundaries one element to the right.<br>
> 
> **_One thing which distinguishes selection sort from other sorting algorithms is that it makes the minimum possible number of swaps, n − 1 in the worst case._**<br><br>
> **Best case&#8594; When an array is already sorted:** Quadratic running time (**_Θ(n^2)_**), because for every iteration, it will run **_n_** times to find the smallest element. Although, there will be no swaps.<br>
> **Worst case&#8594; When an array is sorted in reverse:** Quadratic running time (**_Θ(n^2)_**).<br>
> **Average case&#8594;** Quadratic running time (**_Θ(n^2)_**).<br>

#### Merge sort

#### Heap sort

#### Quick sort

#### Shell sort

#### Bubble sort

#### Comb sort

#### Exchange sort

#### Counting sort

#### Bucket sort

#### Radix sort
