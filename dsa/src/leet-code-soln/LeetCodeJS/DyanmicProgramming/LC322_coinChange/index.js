/* 
    Time Complexity: 
    Space Complexity: 
*/
/**
 * @param {number[]} coins
 * @param {number} amount
 * @return {number}
 */
 var coinChange = function(coins, amount) {
    let dpMinCoins = new Array(amount + 1).fill(Infinity);
    dpMinCoins[0] = 0;

    for(let i =1; i < dpMinCoins.length; i++){
        for(let j = 0; j < coins.length; j++){
            const coinValue = coins[j];
            if(coinValue <= i){
                dpMinCoins[i] = Math.min(dpMinCoins[i - coinValue] + 1, dpMinCoins[i])
            }
        }
    }

    const answer = dpMinCoins[dpMinCoins.length - 1];
    return answer === Infinity ? -1 : answer;
};

module.exports = coinChange;
