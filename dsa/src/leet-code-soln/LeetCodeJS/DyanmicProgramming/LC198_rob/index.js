/*
    As it is a DP problem we have to break it into sub problems and then continue to solve sub problems 
    Time Complexity: O(n)
    Space Complexity: O(n) because maxLootAtNth Array
*/

/**
 * @param {number[]} nums
 * @return {number}
 */
 var rob = function(nums) {
    if(nums.length === 0){
        return 0;
    }    
    if(nums.length === 1){
        return nums[0];
    }
    if(nums.length === 2){
        return Math.max(nums[0], nums[1])
    }

    let maxLootAtNth = [nums[0], Math.max(nums[0], nums[1])]
    for (let index = 2; index < nums.length; index++) {
        maxLootAtNth.push(Math.max(nums[index] + maxLootAtNth[index-2], maxLootAtNth[index-1]));
    }

    return maxLootAtNth.pop();
};

module.exports = rob;
