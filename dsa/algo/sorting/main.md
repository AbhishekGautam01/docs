# Sorting
* it is used to rearrange a given array or list elements according to a comparison operator on elements. 

# Terminologies
1. **In Place Sorting**: It uses constant space for producing output( modifies the given array only.). Eg. **Selection Sort, Insertion Sort** 
2. **Internal & External Sorting**: When all data needed to be sorted cannot be placed in-memory at a time, the sorting is called **external sort**. It uses **massive amount of data**. Eg. **merge sort** . When all data is placed in memory, then sorting is called **internal sorting**
3. **Stable Sorting**: [Here](https://www.geeksforgeeks.org/stability-in-sorting-algorithms/)

# Time Complexities
| Algorithm | Best | Average | Worst | Space| 
| :---: | :---: | :---: | :---: | :---: | 
| [Selection Sort](http://geeksquiz.com/selection-sort/) | O(N^2) | O(N^2) | O(N^2) | O(1) | 
| [Bubble Sort](http://geeksquiz.com/bubble-sort/) | O(N) | O(N^2) | O(N^2) |
| [Insertion Sort](http://geeksquiz.com/insertion-sort/) | O(N) | O(N^2) |O(N^2) |
| [Heap Sort] | O(NLogN)|O(NLogN) |O(NLogN) |
| [Quick Sort] | O(NLogN) | O(NLogN) | O(N^2) |
| [Merge Sort] | O(NLogN) | O(NLogN) | O(NLogN) |
| [Bucket Sort] | Ω(n+k) | θ(n+k) | 	O(n^2) |
| [Radix Sort] | | | | 
| [Count Sort] | | | | 

# Index
[Coding Problems](https://www.geeksforgeeks.org/sorting-algorithms/#problems)