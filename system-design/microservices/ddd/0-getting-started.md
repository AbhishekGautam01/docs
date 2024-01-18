# DDD Domain Driven Design

## 📍Strategic Design
* We need to work out what the different subdomains are in the business. 
* subdomain in this case refers to the subject area. these are part of the application. 
* **Ubiquitous language**: Ensure words you use to describe objects in your app to be the same words that are used by business. 
* We need to understand each and every term and then map the terms. 

### Subdomains
* If we are building Netflix then domains would be 
  * **Video Streaming**: core domain
  * **Recommendations**: 
  * **Billing**
  * ...other domains
* This should be done as group exercise with the business.
* This is iterative process, if domains is huge and needs to be broken down further

### Bounded Context
* If we look at billing domain:
  * subscriber
  * accounts
  * payment details
  * subscription plans
* There will be parts common across multiple subdomains. eg. user will come up across the whole system
* Each domain will have its own preference as to what to call the users
  * billing domain may call them subscribers or customers
  * video streaming domain might call them viewers
* DDD copes by creating **bounded context**. It allows each subdomain to have different languages.
* We don't have to force whole business to agree on what to call `users` , we just need to agree on the language to use within sub domain.

### Relationships
* After identifying different subdomains we need to work out how they interact and what relationships exist between them. 
* **Context Map**: 
  * How sub domains communicate 
  * What is direction of communication. 
* Eg. Video Streaming domain will need to know what video quality to stream. Billing will have the subscription details but billing will not care about the video quality. So we need to have an **anti-corruption** layer sp we d not add additional information in either of domain. 

## Tactical Design
* We define our domain models here. Domain models are of type:

## Entities 
* These are domain object link to their real-world counter part. Eg. Subscriber. 
* Each entity should have an unique identifier
* Entities are **mutable** - you can change their properties over time. 

## Value Object
* Corresponds to value in your domain, 
* Each entity may have several value objects. 
* Value objects are are not unique. In C# or Java you will have to override the Equals and HasCode methods to make sure when you compare these value objects , objects with same value should be considered equal. 
* In C# you can also use the `record` type.
* Value objects should be **immutable** - you should not update them but if required you can make new ones.

## Aggregate 
* Next important thing to consider in DDD is an aggregate.
* It is used to group several entities and value objects. 
* Eg Customer order - As it is made up of customer and products.
* Like entities aggregates should also have unique identifiers. 