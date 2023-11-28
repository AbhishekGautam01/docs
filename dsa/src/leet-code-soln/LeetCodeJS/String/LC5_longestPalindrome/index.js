/*
    Approach: The left half should mirror the right half using technique __EXPAND AROUND THE CENTRE__ but this wont work for even letter string but this can be fixed by having our centre both be the char we are iterating on and the space in between each charecter 
    Time Complexity: O(n^2) since expanding the plaindrome around its centre could take O(n) and we do this for each char
    Space Complexity: O(1)
*/

/**
 * @param {string} s
 * @return {string}
 */
 var longestPalindrome = function(s) {
    let startIndex = 0;
    let maxLength = 1;
    
    function expandAroundMiddle(left, right){
        while(left >= 0 && right < s.length && s[left] == s[right]){
            const currentPalLength = right - left + 1;
            if(currentPalLength > maxLength){
                maxLength = currentPalLength;
                startIndex = left;
            }
            left -= 1;
            right += 1;
        }
    }

    for(let i = 0; i  < s.length; i++){
        expandAroundMiddle(i -1, i+1);
        expandAroundMiddle(i, i+1);
    }

    return s.slice(startIndex, startIndex + maxLength);
};

module.exports = longestPalindrome;
