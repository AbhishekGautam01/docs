# Reusable Components:
* [Source Code](../src/pda-demo-1/)
* Components Hierarchy helps us understand the relationship between our components. 
* App is parent & ProfileCards are Children and ProfileCard are siblings to each other.

## Props
* Props are used to pass down information from parent component to child component. 
* Allows a parent to configure each child differently
* One way flow of data. Child can't push props back up. 
```html
    <ProfileCard title= "Alexa" handle="@alexa99"/>
```
```js
function ProfileCard({title, handle}) {
    //const {title, handle} = props;
  return (
    <div>
      <div> Title is {title}</div>
      <div> Handle is {handle}</div>
    </div>
  );
}

export default ProfileCard;

```

### Argument Destructuring
* This is a JS feature.
```js
function ProfileCard({title, handle}) {
  return (
    <div>
      <div> Title is {title}</div>
      <div> Handle is {handle}</div>
    </div>
  );
}

export default ProfileCard;

```

### React Developer Tools Extensions in Browser
* this will help inspects the components in inspect menu

### Importing Images
* The dev server serves images differently, if image is <9.7KB then image base64 string is placed in js file then it is treated as separate file and will be served separately. 

```js
import AlexaImage from "./images/alexa.png";
import GoogleImage from "./images/cortana.png";
import SiriImage from "./images/siri.png";
```

### Bulma.io CSS Library
* Installation: `npm install bulma`