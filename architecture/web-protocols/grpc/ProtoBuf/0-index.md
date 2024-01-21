# ProtoBuf
* Evolution of Data:
  * CSV - Easy to Read & Parse, Type Inferred is a challenge
  * Relational DBs: Types Supports, Focus on Schema CONS:Flat Data, ORM for mapping which is extra overhead
  * JSON: Easy Shareable, Arrays, High Support, Dynamic Schema CONS: Backward & Forward compatibility while changing due to no schema referencing, Redundancy, No Comments
  * ProtoBuf: Typed, Generate code, Schema Evolution rules for backward, Comments, Binary, CONS: Not Human Readable, Less Support

* 3-10x Smaller, 20-100x faster than XML
* 34% smaller, 21% less time to be available(JS)
* 9% smaller, 4% less time to be available(JS)

* **Features of Protobuf**
  * Language Independent
  * Efficient Data Compaction
  * Efficient Serialization & deserialization
  * Simple to use
<br/>

* A protocol buffer "definition file" contains the schema of message we want to serialize.
```protobuf
syntax = "proto3";
package tutorial;

message Greet {
   string greeting = 1;
   string username = 2;
}
```
* **Syntax**: represents the version of protobuf we are using. 
* **Package**: It is used for grouping various `.proto` file logically.
* **message <name>**: name of the base class of which object will be created.
* Then we define type and name of attribute and each attribute should be assigned a unique numbering. If we were to add a new property in this message it would get number 3.

## Types
1. **Scalar Types**
   1. double
   2. float
   3. int32, int64 - signed int
   4. uint32, uint64 - unsigned int
   5. sint32, sint64 - Signed int with variable encoding that is more efficient
   6. fixed32, fixed64 - represent fixed-width signed and unsigned integers in the binary encoding.  How fixed differs from int or uint is they use a fixed number of bytes for encoding or decoding. 
   7. sfixed32, sfixed64
   8. bool
   9. string
   10. bytes - binary data
2.  **Enums**: Allow you to define a set of named integer values. 
  ```protobuf
  syntax = "proto3";

  message MyMessage {
    enum Color {
      RED = 0;
      GREEN = 1;
      BLUE = 2;
    }

    Color color = 1;
  }
  ```
3. **Sub messages(Nested Messages)**
  ```protobuf
  syntax = "proto3";

  message Address {
    string street = 1;
    string city = 2;
  }

  message Person {
    string name = 1;
    int32 age = 2;
    Address address = 3;
  }
  ```
4. **Repeated fields**: Fields can be marked as repeated to indicate a list or array of values.
   ```protobuf
   syntax = "proto3";

  message MyMessage {
    repeated int32 numbers = 1;
  }
   ```
5. A field can also be marked as `optional` and `required`.

## Services 

* are defined using `.service` keywords. 
* A service is a collection of rpc(remote procedure calls) methods that can be called by clients. 
* **Types of Methods**
  1. **Unary RPC Method**: Like a HTTP Rest API call, Client calls the endpoint and the waits for server to send a single response back.
  ```protobuf
  syntax = "proto3";

  // Service definition for a simple calculator
  service Calculator {
    // Unary RPC method: Takes a single request and returns a single response
    rpc Add (AddRequest) returns (AddResponse);
  }

  // Message definitions for input and output types
  message AddRequest {
    int32 operand1 = 1;
    int32 operand2 = 2;
  }

  message AddResponse {
    int32 sum = 1;
  }
  ```
  <br/>
  2. **Server Streaming RPC Method**: Takes a single request from client and returns a stream of response. 
     1.  A server streaming RPC method can be used to provide real-time updates to clients. 
  ```protobuf
  syntax = "proto3";

  // Service definition for a simple calculator
  service Calculator {
     // Server streaming RPC method: Takes a single request and returns a stream of responses
    rpc Multiply (MultiplyRequest) returns (stream MultiplyResponse);
  }

  message MultiplyRequest {
  int32 factor1 = 1;
  int32 factor2 = 2;
  }

  message MultiplyResponse {
    int32 product = 1;
  }
  ```
  <br/>
  3. **Client side streaming request**: Takes a stream of request and returns a single response - `rpc Average (stream AverageRequest) returns (AverageResponse)`
    1. A client streaming RPC method can be used for scenarios where the client needs to send a large set of data to the server for aggregation. For instance, a data analytics service may accept a stream of data points from a client and return aggregated results.
  <br/>
  4. **Server side streaming request**: Takes a stream of requests and returns a stream of responses. `  rpc Divide (stream DivideRequest) returns (stream DivideResponse);`
    1.  A bidirectional streaming RPC method is suitable for real-time chat applications. Clients can send messages to the server, and the server can broadcast those messages to other clients in real time.
  <br/>

# Further Reading: https://www.codemag.com/Article/2212071/A-Deep-Dive-into-Working-with-gRPC-in-.NET-6