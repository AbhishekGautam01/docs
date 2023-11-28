// --- Directions
// Given a string, return the character that is most
// commonly used in the string.
// --- Examples
// maxChar("abcccccccd") === "c"
// maxChar("apple 1231111") === "1"

// //SIMILAR TYPES OF QUESTION
//   1. what is the most common char in string?
//   2. does str A have the same char as B (anagrams)?
//   3. does the given string have any repeated charecters in it?

function maxChar(str) {
  const charMAP = {};
  let max = 0;
  let maxChar = '';
  for (let char of str) {
    if (charMAP[char]) charMAP[char]++;
    else charMAP[char] = 1;
  }
  for (let char in charMAP) {
    if (charMAP[char] > max) {
      max = charMAP[char];
      maxChar = char;
    }
  }
  return maxChar;
}

module.exports = maxChar;
