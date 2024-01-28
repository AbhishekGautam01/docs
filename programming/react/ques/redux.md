# Implementing Redux in Project
* Creating new React App:
  * `npx create-react-app redux-fruit-app`
* Installing Redux and React Redux
  * `npm install redux react-redux`
* Setting up the store
  * Create a new folder name `redux` inside src and within this dir create `store.js`
    * **Store.js**
        ```js
        // src/redux/store.js
        import { createStore } from 'redux';
        import rootReducer from './reducers';

        const store = createStore(rootReducer);

        export default store;
        ```
    * Create a new folder named `reducer` inside this create a file `fruitReducer.js`
        ```js
        // src/redux/reducers/fruitReducer.js
        const initialState = {
        fruits: [],
        filterText: '',
        };

        const fruitReducer = (state = initialState, action) => {
        switch (action.type) {
            case 'SET_FRUITS':
            return { ...state, fruits: action.payload };
            case 'SET_FILTER_TEXT':
            return { ...state, filterText: action.payload };
            case 'FILTER_FRUITS':
            const filteredFruits = state.fruits.filter(
                (fruit) => fruit.name.toLowerCase().includes(action.payload.toLowerCase())
            );
            return { ...state, filteredFruits };
            default:
            return state;
        }
        };

        export default fruitReducer;
        ```
    * Create a root reducer within redux folder and name it index.js
        ```js
        // src/redux/index.js
        import { combineReducers } from 'redux';
        import fruitReducer from './reducers/fruitReducer';

        const rootReducer = combineReducers({
        fruits: fruitReducer,
        });

        export default rootReducer;
        ```
    * Connecting redux to the App
        ```js
        // src/index.js
        import React from 'react';
        import ReactDOM from 'react-dom';
        import { Provider } from 'react-redux';
        import store from './redux/store';
        import App from './App';
        import './index.css';

        ReactDOM.render(
        <Provider store={store}>
            <App />
        </Provider>,
        document.getElementById('root')
        );
        ```

    * Creating the component
        ```js
        // src/components/FruitList.js
        import React from 'react';
        import { useSelector, useDispatch } from 'react-redux';

        const FruitList = () => {
        const fruits = useSelector((state) => state.fruits.fruits);
        const filterText = useSelector((state) => state.fruits.filterText);
        const dispatch = useDispatch();

        const filteredFruits = filterText
            ? fruits.filter((fruit) => fruit.name.toLowerCase().includes(filterText.toLowerCase()))
            : fruits;

        return (
            <div>
            <input
                type="text"
                placeholder="Filter by name"
                value={filterText}
                onChange={(e) => dispatch({ type: 'SET_FILTER_TEXT', payload: e.target.value })}
            />
            <ul>
                {filteredFruits.map((fruit) => (
                <li key={fruit.id}>{fruit.name}</li>
                ))}
            </ul>
            </div>
        );
        };

        export default FruitList;
        ```