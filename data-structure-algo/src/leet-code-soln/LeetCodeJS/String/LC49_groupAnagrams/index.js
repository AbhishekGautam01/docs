/*
    Words that are anagrams to each other will be the same word if their letters are sorted alphabetically 
    Time complexity: O(N K log K ) where N is number of string and k is length of string
    Space Complexity: O(N * K) data stored in our grouped hash table
*/

/**
 * @param {string[]} strs
 * @return {string[][]}
 */
var groupAnagrams = function (strs) {
    let grouped = {};
    for (let index = 0; index < strs.length; index++) {
        const word = strs[index];
        const key = word.split("").sort().join("");
        if (!grouped[key]) {
            grouped[key] = [];
        }
        grouped[key].push(word);
    }

    return Object.values(grouped);
};

module.exports = groupAnagrams;