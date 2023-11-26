/*
    Approach1: Naiave : Create Temp string in memory which is reversed version of original string, but this would have O(n) space complexity 
    Approach2: O(1) : Palindrome is where each word mirrors each other. This mirroring concept will work for odd and even words. We will have left and right pointers and keep moving them inwards. 
    Time Compl: O(N)
    Space Compl: O(1) - Left and right pointers take a constant space
*/

/**
 * @param {string} s
 * @return {boolean}
 */
 var isPalindrome = function(s) {
    //sanitize the input string
    s = s.toLocaleLowerCase().replace(/[\W_]/g, "");

    let left = 0;
    let right = s.length - 1;
    while(left < right){
        if(s[left] != s[right]){
            return false;
        }
        left++;
        right--;
    }
    return true;
};

module.exports = isPalindrome;
