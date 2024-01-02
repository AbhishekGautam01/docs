# Querying Data with GraphQL 
* GQL Query is like REST GET.
* Github QL Example
* 
```graphql
query myFirstQueryName{
  viewer {
    id
    name
    avatarUrl
    login
    createdAt
  }
}
```

* **Arguments in GQL Query**
* Here name and owner are arguments to be passed to query
* Arguments marked with ! in schema marks them mandatory.
```graphql
query {
  repository(name: "graphql", owner:"facebook"){
    createdAt
    id
    description
  }
}
```

* **GQL Schema**
* it doesn't allow random fields to be queried. 
```graphql
query {
  repository(name: "graphql", owner:"facebook"){
    createdAt
    facebookImage <- radom param hence throws error.
  }
}
```
* Queries are used for Retrieving 
* Mutations are used for modification of the data.

* **Aliases**
* Allows to retrieve data by using human friendly name.
* Here DotnetRepository & WPFRepository are aliases
* Running below query without aliases will give you an error . The error will be because
  * Your query requests two repository fields with the same owner ("dotnet") but different names ("core" and "wpf"). This creates an ambiguity for the server as it cannot determine which repository you're referring to based on the owner alone. It needs the name to identify the specific repository.
```graphql
query {
 DotNetCoreRepository : repository(name: "core", owner:"dotnet"){
    createdAt
    id
    description
  }
  WPFRepository : repository(name: "wpf", owner:"dotnet"){
    createdAt
    id
    description
  }
}   
```

## N + 1 Problem
* Data Loaders solve the N + 1 Problems.
* The problem is lets say we load all courses in 1 query, now each course have 1 instructor so for N Courses we need to do N more queries to get the Instructors hence N + 1 queries are involved. 
* What we want here is that we should do 1 Query to get all courses and 1 more to get all required instructors. 
* Data loaders can be useful when while returning the data we have data split across different APIs or data sources. 
* Sometimes data loaders may be slower like the course and instructor example when we want to load just the course then we will have a better performance with data loader but when we want to fetch both then join would be better instead of running two queries. 
