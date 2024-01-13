# Java Script
* 1995 by Brenden Eich. It is an agreement - tc39 discuss the feature for JS. 100% Backward Compatible
* [Can I Use](caniuse.com) -> to check which JS features is supported in which browser version
* [Node Green](node.green) -> which does exactly same for node 
* Supports OOPS by object prototyping and not classes. 
* Functional programming - functions may be stored in variable & passed around as any variable. 

## Compilation vs Polyfill
*	As a developer we should be using new features without worry but by this we will be limiting browser and node versions.
* But we use compilers which allows us to write latest feature. Compiler compiles the code to older version of JS. 
* `Babel` – Allows to write in one version of JS and compile to another version. Eg Let is new feature babel convert it to var. https://babeljs.io   
>	**NOTE**: We can’t add feature by compiling, but if new feature can be achieved using some old feature then it will work. For brand new feature it will not work.  For this we will use Polyfill e.g., Promise Polyfill – if we include them then those features will also run, with same Syntax as new version 

## Strict Mode
* It put program in **strict mode executing context**. It makes debugging easier, it will alert to problem sooner. 
* Put `“use strict”` at top of your JS file. This is a string because when it was proposed older browser didn’t supported it so it would break in them so it is made string. 
* Why we need Strict Mode?
  * Using a variable before declared gives an error. Otherwise without it would create a global variable.
  * Stops from using words reserved from future version of JS. Eg var let = 1 will throw error in strict mode 
  * You cannot delete function variable in strict mode. 
  * It doesn’t let you delete arguments to functions
  * Eval keyword becomes safer. Variable can’t leak eval block eval (“var a = 1”) a is not accessible from outside in strict mode. 

## Does JS Pass params by value or by reference?
* Object is passed by reference and primitive is passed by value. 
  * **Pass By Value**: If you change a value of primitive type(numbers, string boolean) inside a function then it will not effect outside function block. – Copy of argument is passed. 
  ```js
  function updateValue(value) {
   value = 42;
   }

   let num = 10;
   updateValue(num);
   console.log(num); // Output: 10 (unchanged)

  ```
  * **Pass By Reference(Objects & Arrays)**:  When we change a property the change will be reflected in outer scope. We can’t change what variable points to , but only change property value . 
  ```js
  function updateArray(arr) {
   arr.push(4);
   }

   let myArray = [1, 2, 3];
   updateArray(myArray);
   console.log(myArray); // Output: [1, 2, 3, 4] (changed)

   function updateObject(obj) {
   obj.property = "new value";
   }

   let myObject = { property: "old value" };
   updateObject(myObject);
   console.log(myObject.property); // Output: "new value" (changed)

  ```
## Types
* we can use `typeof()` to check.
* **Dynamically Typed Language vs Statically Types Language**
  *  In STL, while coding we have to define what the type var will hold. 
  *  In DTL, the type of variable is determined at run time. It’s quicker to get up and running fast but we can get runtime errors, which might be caught at compile time in STL 
*  

1. **Number**
   1. double-precision 64-bit format IEEE 754 values
   2. There is no concept of integer except BigInt
   3. Everything is implicitly float so following things may happen: 0.1 + 0.2 == 0.
   4. You can use `parseInt` to convert str to int. which also takes base, fo bin numbers you can pass as 2, `parseInt(‘10234’, 10)`
   5. `parseFloat` can be used for floating number
   6. The parseInt() and parseFloat() functions parse a string until they reach a character that isn't valid for the specified number format, then return the number parsed up to that point.
   7. `NaN` is returned if the string is not a number
   8. NaN can be tested using built in function `isNaN`
   9. Js has special values `Infitnity`, `-Infinity` & `NaN`
2.  **String**
    1.  Sequence of Unicode characters. By default supports Internationalization
    2.  They also have built in methods on string type like charAt(0), replace, toUpperCase
3. **Boolean**
   1. False, 0, empty strings (""), NaN, null, and undefined all become false.
   2. All other values become True.
4. **Symbol (ES2015)**
5. **Object**
   1. Function
   2. Array
   3. Date
   4. RegEx
6. **Null**
   1. Null represents non defined value and undefined represents not initialized variable
7. **Undefined**
   1. Undefined is actually a constant value , a variable which is declared but not initialized belongs tot the undefined type.

## Scopes and Variables
* **Scope**: How long a variable life before a variable die
* **Different Scopes:**
  * Any variable defined outside any block is global, another way to define is to add it to `global property (window.moo = 1)` -> moo becomes a global variable. 
  * In `NODE` , the global is `global`  not window
   *	**Function Scope**: Variable declared with var defined within a function will only live in that function. 
   * **Block Scope**: In ES6 let and const came to create block scope; var is not block scoped it is global scope. 
      ```js
      //BLOCK SCOPE 
      {
      var a = "block"
      let b = "block 2"
      }
      console.log(a); //block
      console.log(b); //undefined
      ```

<br/>

* Variables are defined using : `let`, `const` and `var`
* `Let` is used to defined `block level variable` and is only present in block it is defined. 
* `Const` allows to declare variable whose value never change. It is available in the `block` from which is declared in. 
* `Var` It doesn’t have any restriction like the above two have.
  
> NOTE: Like other programming language js variables don’t have a block scope they have function scope which means they are available in the function which they are defined in. But in ECMA2015 – let & const allows us to define the block scoped variable 

* **Variable Hoisting**: Variable and functions will get hoisted to top of scope.
```js
console.log(someVar);
var someVar = 1; // JS will split it into 2 line as shown below 
---------------------------------------------
var someVar; //moved to top of scope // top of file || or top of function
console.log(someVar); //undefined
someVar = 1;
```

* **Scope Chain**
   * When a function need a variable then it will look into it’s own scope to get it if can’t get it then it will keep going outer and outer till it reach global scope. 
  * A function scope can live within nested function scope
  ```js
      function outerFunction() {
      // Outer function scope
      let outerVariable = 'I am from outer function';

      function innerFunction() {
         // Inner function scope
         let innerVariable = 'I am from inner function';
         console.log(innerVariable);  // Output: I am from inner function
         console.log(outerVariable);  // Output: I am from outer function
      }

      innerFunction();
      }

      outerFunction();
  ```
  * outerFunction has its own scope, which includes the variable outerVariable.
   * innerFunction is declared inside outerFunction, creating a nested scope. It has access to both its own variables (like innerVariable) and variables from its containing scope (like outerVariable).

## IIFE
* Immediately Invoked Function Expression
* JS will execute as soon as line is read.
  ```js
  (function(){
  some operations
   })();
  ```