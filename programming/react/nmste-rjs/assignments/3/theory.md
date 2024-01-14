# Assignment 3

* **What is JSX**
  * JSX is Javascript Extension. It is kind of combination of JS & HTML but exactly it is not HTML , it is HTML like.
  * JSX is transpiled to React.createElement by using Babel 
<br/>

* **Superpowers of JSX**
  * We can write any JS in {}
  * It saves from Cross site scripting while rendering data between {}
<br/>

* **Passing attributes into the tag in JSX**
  * const elem = (<span className="span">This is span</span>). 
  * The attributes are written in pascal case
<br/>

* **Role of type Attribute in script tag? What options can I use there?**
  * The type tells the scripting language used in embedded code.
  * It informs the browser about the type of content within the script block. 
  * Common Values
    * Omitted or Blank: browser assumes default scripting language is javascript
    * text/javascript: This was used historically, in HTML5 JS has become default scripting language
    * module: With introduction of modules, you can use this to indicate that the script is a JS module. 
<br/>

* **{TitleComponent} vs {\<TitleComponent/>} vs {\<TitleComponent>\</TitleComponent>} in JSX**
  * {TitleComponent} - Will not render 
  * \<TitleComponent/> - This is one way to render a Component in JSX 
