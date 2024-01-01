# ProtoBuf
* Evolution of Data:
  * CSV - Easy to Read & Parse, Type Inferred is a challenge
  * Relational DBs: Types Supports, Focus on Schema CONS:Flat Data, ORM for mapping which is extra overhead
  * JSON: Easy Shareable, Arrays, High Support, Dynamic Schema CONS: Backward & Forward compatibility while changing due to no schema referencing, Redundancy, No Comments
  * ProtoBuf: Typed, Generate code, Schema Evolution rules for backward, Comments, Binary, CONS: Not Human Readable, Less Support

* 3-10x Smaller, 20-100x faster than XML
* 34% smaller, 21% less time to be available(JS)
* 9% smaller, 4% less time to be available(JS)

```js
syntax = "proto3";

message MyMessage {
    uint32 id = 1;
}
```



