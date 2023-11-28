// --- Directions
// Given the root node of a tree, return
// an array where each element is the width
// of the tree at each level.
// --- Example
// Given:
//     0
//   / |  \
// 1   2   3
// |       |
// 4       5
// Answer: [1, 3, 2]

function levelWidth(root) {
  let widhts = [0];
  let array = [root, 'stopper'];
  while (array.length > 1) {
    const node = arr.shift();
    if (node === 'stopper') {
      widhts.push(0);
      arr.push('stopper');
    } else {
      arr.push(...node.children);
      widhts[widhts.length - 1]++;
    }
  }
  return widths;
}

module.exports = levelWidth;
