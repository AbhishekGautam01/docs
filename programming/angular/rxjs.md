# RxJS (Reactive Programming)
* Programming with asynchronous data streams. 
* A data stream is the data that arrives over some time. 
* Stream can be anything like `variables, user inputs, props,caches, data structures or even failure`
* Stream can emit:
  * Value: the next value
  * Complete: the stream has ended
  * Error: The error has stopped the stream.

## Observables
* Observable emits the value from the stream asynchronously. It emits the complete signals when the stream completes or an error signal if the stream errors out.
* The observable starts to emit values only when someone subscribes to it.
* The observers communicate with the Observable using callbacks
* While subscribing observers pass `next(), error() & complete()`
* **Steps to implement observables**
  * Import: `import { Observable } from 'rxjs';`
  * Subscribing
    ```ts
    observable1.subscribe(
    value => console.log(value),
    error => console.error(error),
    () => console.log('Observable complete')
    );
    ```

## Subjects
* A subject is a type of observable that allows value to be multi casted to multi observers. 
* It acts as both observer and observable
* Key characteristics:
  * **Multi Cast Subjects**: 
    * Subjects can have multiple subscribers and when value changes it can be sent to multiple subscribers
  * **Hot Observables**: They start emitting value as soon as they are created. It doesn't matter if they have a subscriber or not. 
  * **State Management**: They can be used to maintain state in angular apps. 

## Subject
* It does not have an initial value and only emits the value which are assigned to it using next. 
```ts
import { Subject } from 'rxjs';

// Create a Subject
const subject = new Subject<number>();

// Subscribe to the Subject
subject.subscribe((value) => {
  console.log(`Received value: ${value}`);
});

// Emit values
subject.next(1);
subject.next(2);
```

* A subject can be used to : 
  * Event Handling: You can use a Subject to emit events when a button is clicked, an input field changes, or any other user-triggered action occurs.
  * Communication between components: 
  * Async Data streams

## Behavior Subject
* it is more advance than subject and also it has an initial value,
* It emits the most recent value. 
```ts
import { BehaviorSubject } from 'rxjs';

// Create a BehaviorSubject with an initial value
const behaviorSubject = new BehaviorSubject<number>(0);

// Subscribe to the BehaviorSubject
behaviorSubject.subscribe((value) => {
  console.log(`Received value: ${value}`);
});

// Emit values
behaviorSubject.next(1);
behaviorSubject.next(2);

// New subscriber
behaviorSubject.subscribe((value) => {
  console.log(`New subscriber received value: ${value}`);
});
```

* A Behavior subject can be used to 
  * Managing component State
  * Default value
  * Form Control
