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

* **Creating Fragments**
* 