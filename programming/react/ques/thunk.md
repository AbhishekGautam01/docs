# Redux Thunk
* it is a middleware that allows you to return functions rather then just actions within redux. 
* Installation: `npm install redux-thunk`
* Now while configuring the redux store we need to apply this middleware
  ```js
    import { createStore, applyMiddleware } from 'redux';
    import thunk from 'redux-thunk';
    import rootReducer from './reducers/index';

    const store = createStore(
    rootReducer,
    applyMiddleware(thunk)
    );
  ```