/*
    Till three steps the numbers of ways to climb is number of steps but post that this will form a fibbonacci sequence as if we have to find number of ways to step 4 we can go 2 steps from step 2 : [1,1, *2*], [2, *2*] and also we can go one step from step 3: [1, 1, 1, *1*],  [1, 2, *1*], [2, 1, *1*]
    Time Complexity: O(n)
    Space Complexity: O(n) - array of size n is used. in Soln 1 is is order one
*/

/**
 * @param {number} n
 * @return {number}
 */
var climbStairs = function(n) {
    if( n <= 3){
        return n;
    }

    let first =1;
    let second = 2;

    for (let index = 3; index <= n; index++) {
        const third = first + second;
        first = second;
        second = third;
    }

    return second;
};


//  var climbStairs = function(n) {
//     if( n <= 3){
//         return n;
//     }

//     let ways = [0, 1, 2, 3]
//     for (let index = 4; index <= n; index++) {
//         ways.push(ways[index-1] + ways[index-2]); // As it follows the fibbonaci sequence
//     }

//     return ways.pop();
// };

module.exports = climbStairs;
