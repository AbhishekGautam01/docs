# How Strongly typed IDs can make your code more expressive?
* **Primitive Obsession**: Its an anti pattern where we use primitive type to represent complex values in our entities. 
* To solve this we can use strongly typed IDs.
* Strongly typed Ids do not directly work with EF Core, We will have to write conversions for it to work. 
* But strongly typed ids make our method signatures more clear. 
* Also the strongly typed ids can remove the actual dependency on the object
