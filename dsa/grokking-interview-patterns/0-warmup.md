# Warmup

### Problem 1: Contains Duplicate

```csharp
using System;
using System.Collections.Generic;

public class Solution {

  public bool containsDuplicate(int[] nums) {
    HashSet<int> uniqueNums = new HashSet<int>();
    for(int i = 0; i < nums.Length; i++){
      if(uniqueNums.Contains(nums[i]))
        return true;
      uniqueNums.Add(nums[i]);
    }
    return false;
  }
}
```