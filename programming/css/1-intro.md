# Introduction
* **Syntax**: `selector { prop1: value1; prop2: value2}`
* selector: html element 
* declaration contains 1 or more elements separated by semicolons
<br/>
---

* **Selectors**: Used to find or select the HTML elements you want to style.
  * Element Selector: HTML elements based on their name. `p {text-align: center}`
  * Id Selector: Using id attribute of HTML element to select a specific element. `#para1 { text-align: center;}`
  * Class Selector: Select element with special class attribute `.center { text-align: center}`
  * Applying class selector to HTML elements: `p.center {text-align: center}`
  * Universal Selector: `* { text-align: center}`
  * Grouping Selector: Select all elements with same style `h1, h2, p {text-align: center}`
---

* **Adding stylesheet**
  * **External**: `<head><link rel="stylesheet" href="mysheet.css"></head>`
  * **Internal**: Declared within the `<style></style>`
  * **Inline**: using `style` attribute on HTML elements

> If some properties have been defined for the same selector in different style sheets, the value from the last read style sheet will be used. 

* **Priority**: InLine Stye > External & Internal > Browser
---

* **CSS Color**: defined using **Predefined color names, RGB, HEX, HSL, RGBA, HSLA**
* **Background Color**: `background-color: tomato`
* **Text Color**: `color: MediumSeaGreen`
* **Border Color**: `border:2px solid DodgerBlue`
---

* **Background**
  * background color of page `body {background-color: white}`
  * **Opacity/transparency**: `opacity` prop 0.0 to 1.0 Lower value is more transparent.
  * **Background Image**: `background-image: url("img_url")`
  * `background-repeat:`
    * `repeat-x`
    * `repeat-y`
    * `no-repeat`
  * `background-position`: Used to specify the position of background image. `background-position: right top`
  * `background-attachment`: Specifies whether the image should scroll or be fixed: `fixed` or `scroll`
----

* **Borders**:
  * **Border Style**: What kind of border to display `border-style`
    * dotted
    * dashed
    * solid
    * double
    * ....
  * **Border Width**: Specify the width of 4 borders.
    * Pre defined values: thin, medium or thick
    * Can be set in px, pt, cm , em
    * `  border-width: 2px;`
  * **Border Color**: Used to set the color of 4 borders
    * If no color is set then it is inherited from the element.
    * `border-color: blue`
  * **Border Individual sides**
    * border-top-style: dotted;
    * border-right-style: solid;
    * border-bottom-style: dotted;
    * border-left-style: solid;
  * **Rounded Border**
    * `border-radius: 5px`
---
* **Margins**
  * Used to create space around elements outside of any defined borders.
  * `margin`
  * To control individual sides: 
    * `margin-top`, `margin-bottom`, `margin-left` and `margin-right`
  * **Auto**: it is used to horizontally center the element within its container. `margin: auto`
  * **Inherit**: margins can be inherited from the parent value. `margin: inherit`
---

* **Padding**
  * Padding is used to create space around an element's content inside of any defined borders. 
  * `padding: 20px`
  * To control individual sides
    * `padding-top`, `padding-right`, `padding-bottom`, `padding-left`
    * Values: `length`, `%` and `inherit`
    * The CSS width property specifies the width of the element's content area. The content area is the portion inside the padding, border, and margin of an element
      * the <div> element is given a width of 300px. However, the actual width of the <div> element will be 350px (300px + 25px of left padding + 25px of right padding):
      * `div { width: 300px; padding 25px}`
      * to solve this we use `box-sizing`; this will cause element to maintain actual width so due to above padding content space will reduce. 