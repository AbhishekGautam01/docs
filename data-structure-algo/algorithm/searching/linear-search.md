# Linear Search 
* Start from left ost element of arr[] and one by one compare x with each element of arr[]
* If x matches with an element, return the index. 
* If x doesn't match with any elements, return -1.  

# Complexity
1. **Best case time**: O(1)
2. **Average Case time**: O(N)
3. **Worst Case time**: O(N)
4. **Space Complexity**: O(1)


# Pseudocode 
```
procedure linear_search(list, value)
    for each item in the list 
        if match item == value 
            return the item's location
        end if 
    end for
end procedure
```

# C# Implementation
````
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms.searching
{
    public static class Linear
    {
        public static int LinearSearch(int[] input , int value)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == value)
                    return i;
            }
            return -1;
        }

        public static void Main()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int x = 10;

            // Function call
            int result = LinearSearch(arr, x);
            if (result == -1)
                Console.WriteLine(
                    "Element is not present in array");
            else
                Console.WriteLine("Element is present at index "
                                  + result);
        }
    }
}
````