# Inner Working

## Journey of a Command
* User wants to do `UpdateUserAddressCommand`
* The command is validated checking data format, permissions, and other business rules. 
* Now it goes to command handler, it is responsible for updating state of system. 
* Generating events like `UserAddressUpdated` 
* This event is stored in a event store - a historical record of all changes in the system. 

## The query
* Now user request `ViewUpdatedAddress`
* Unlike command queries dont need validation or event generation. 
* They are simply handled by query handler. 

## Synchronizing Commands and Queries
* Here event sourcing comes into play. 
* The `UserAddressUpdated` event is replayed on the query side to update it's state. 