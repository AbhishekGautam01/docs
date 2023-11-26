// --- Directions
// Write a function that accepts a string.  The function should
// capitalize the first letter of each word in the string then
// return the capitalized string.
// --- Examples
//   capitalize('a short sentence') --> 'A Short Sentence'
//   capitalize('a lazy fox') --> 'A Lazy Fox'
//   capitalize('look, it is working!') --> 'Look, It Is Working!'

function capitalize(str) {
  let result = str.charAt(0).toUpperCase();
  for (let index = 1; index < str.length; index++) {
    if (str[index - 1] === ' ') {
      result += str[index].toUpperCase();
    }
  }
  return result;
}
module.exports = capitalize;

// function capitalize(str) {
//   const words = [];
//   for (let word of str.split(' ')) {
//     words.push(word.charAt(0).toUpperCase() + word.slice(1));
//   }
//   return words.join(' ');
// }
