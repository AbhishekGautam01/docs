/*
    Time Complexity: O(n)
    Space Complexity: O(1) as in this problem states only alphabets will be passed so at max the 26 keys will only be stored
*/
/**
 * @param {string} s
 * @param {string} t
 * @return {boolean}
 */
 var isAnagram = function(s, t) {
    if(s.length !== t.length){
        return false;
    }

    const sCharCounts = {};
    for(let i = 0; i < s.length; i++){
        const sChar = s[i];
        sCharCounts[sChar] = sCharCounts[sChar] + 1 || 1;
    }
    for(let i = 0; i < t.length; i++){
        const tChar = t[i];
        if(!sCharCounts[tChar]){
            return false;
        }

        if(sCharCounts[t[i]] === 0){
            return false;
        }

        sCharCounts[tChar] = sCharCounts[tChar] - 1;
    }
    return true;
};

module.exports = isAnagram;
