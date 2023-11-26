/* 
    Using a stack we will be implementing the problem 
    Time COmplexity:  O(n)
    Space Complexity: O(n) in worst case, stack is same length as input string
*/

/**
 * @param {string} s
 * @return {boolean}
 */
 var isValid = function(s) {
    let stack = [];
    const pairsHashMap = {"(": ")", "{": "}", "[": "]"}
    for (let index = 0; index < s.length; index++) {
        const element = s[index];
        if(pairsHashMap[element]){
            stack.push(element);
        } else if(pairsHashMap[stack.pop()] !== element){
            return false;
        }
    }
    return stack.length === 0 ? true : false;
};

module.exports = isValid;
