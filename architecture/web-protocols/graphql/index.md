# Graph QL 
* A query language to construct & retrieve data from APIs
* Invented by Facebook in 2012 and open sourced in 2015.
* Language and platform independent. Works with any language which supports json. 

## GQL vs REST
* graphQL has solved the data fetching problems like **over fetching & under fetching**.
* **Example of Over fetching**: We want to get all the posts of a user, comments on user posts and likes on user post. For this we would typically build
    1. `api/users/id/posts` : Returns all the posts of a user. 
    2. `api/users/id/posts/postId/comments`: Returns all the comments on a single post.
    3. `api/users/id/posts/podtId/likes`: Returns all the likes on a single post. 
* The need of 3 endpoints to get this data is called *under fetching*. 
* **Example of Over fetching**
    1. Post Endpoint Returns : Desc, UserId, UserImage, Id, CreationTime, Location, etc
    2. Comments Endpoint Returns : Desc, UserName, UserImage, Id, CreationTime, UserId, UserEmail UserLocation, UserIpAddress, UserDoB, etc
* We will get data which is not of use in our scenario - so they are use less and increase json data size which is *over fetching*

* **GQL Approach**: In GQL we will user Query as . Just we need to add the fields. This majorly solves **over fetching & under fetching**. 

```gql
{
    user(id:12345){
        username
        userimage
        postdescription
        comments(postId:3){
            username
            userimage
            commentdescription
        }
        likes(postId:3){
            username
            userimage
        }
        userId
    }
}
```
* GQL is alternative of REST. When project is not so big REST is right choice else GQL is a good choice. 

## Pre requisites & Requirements
* Visual Studio
* Github Account
* Working knowledge of REST Api

## Exploring GraphiQL with Github
* [Github GraphQL Explorer](https://docs.github.com/en/graphql/overview/explorer)
