// --- Directions
// Implement classes Node and Linked Lists

class Node {
  constructor(data, next = null) {
    this.data = data;
    this.next = next;
  }
}

class LinkedList {
  constructor() {
    this.head = null;
  }

  insertFirst(data) {
    var node = new Node(data, this.head);
    this.head = node;
  }

  size() {
    let elemCount = 0;
    let currentPtr = this.head;
    while (currentPtr != null) {
      elemCount++;
      currentPtr = currentPtr.next;
    }
    return elemCount;
  }

  getFirst() {
    return this.head;
  }

  getLast() {
    if (this.head == null) {
      return null;
    }
    let currentPtr = this.head;
    while (currentPtr.next != null) {
      currentPtr = currentPtr.next;
    }
    return currentPtr;
  }

  clear() {
    this.head = null;
  }

  removeFirst() {
    if (this.head) {
      this.head = this.head.next;
    }
  }

  removeLast() {
    if (!this.head) return;
    else if (!this.head.next) {
      this.head = null;
      return;
    } else {
      let prev = this.head;
      let node = this.head.next;
      while (node.next) {
        prev = node;
        node = node.next;
      }
    }
  }

  insertLast(data) {
    if (!this.head) this.head = new Node(data, null);
    else {
      var lastNode = this.getLast();
      lastNode.next = new Node(data);
    }
  }

  getAt(index) {
    if (!this.head) return null;
    let counter = 0;
    let node = this.head;
    while (node) {
      if (counter > index) return;
      if (counter == index) return node;
      node = node.next;
      counter++;
    }
  }

  removeAt(index) {
    if (!this.head) return;
    if (index == 0) {
      this.head = this.head.next;
      return;
    }

    let previous = this.getAt(index - 1);
    if (previous.next.next) {
      previous.next = previous.next.next;
      return;
    } else {
      previous.next = null;
      return;
    }
  }

  InserAt(index, data) {
    if (!this.head) {
      this.head = new Node(data, null);
    } else if (index === 0) {
      let node = new Node(data, this.head);
      this.head = node;
    }
    let previous = this.getAt(index - 1) || this.getLast();
    const node = new Node(data, previous.next);
    previous.next = node;
  }

  forEach(fn) {
    let node = this.head;
    let counter = 0;
    while (node) {
      fn(node, counter);
      node = node.next;
      counter++;
    }
  }

  *[Symbol.iterator]() {
    let node = this.head;
    while (node) {
      yield node;
      node = node.next;
    }
  }
}

module.exports = { Node, LinkedList };
