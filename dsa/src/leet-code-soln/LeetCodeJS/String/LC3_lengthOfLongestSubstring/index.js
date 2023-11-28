/* 
    Approach: Using Brute force:  use 3 nested loops;
    Approach: Sliding Window Approch: 
        - We can solve this in O(n) time using the "Sliding Window" approach problem solving 
        - The sliding window will represent the current substring of non repeating charecters we are working on 
        - we will not be working with sliding window of fixed size, the window will grow or shrink in size as we iterate thru the string 
        - current index and value in for loop will always be the end of the sliding window. as end of the window increases, we conditionally increase the start of window. 
        DETAIL EXPLATION:  Intially start and end of window we will be at start and then we will have a hashmap where key is a charecter and value is index of the last time that charecter appeared in our input string, if the charecter is repeated then the start of window will move to lastIndex+1
        Time Complexity: O(n)
        Space Complexity O(min(m, n)) - the number of keys in hash map is bounded by the size of the string n and the size of charset/aplhabet m
*/
/**
 * @param {string} s
 * @return {number}
 */
 var lengthOfLongestSubstring = function(s) {
    let windowCharsMap = {};
    let windowStart = 0;
    let maxLength = 0;
    for(let i = 0; i < s.length; i++){
        const endChar = s[i];

        if(windowCharsMap[endChar] >= windowStart){
            windowStart = windowCharsMap[endChar] + 1;
        }

        windowCharsMap[endChar] = i;
        maxLength = Math.max(maxLength, i - windowStart + 1);
    }
    return maxLength;
};

module.exports = lengthOfLongestSubstring;
