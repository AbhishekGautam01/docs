# Issues, Special Considerations and Performance Implications
* Understanding the complexity
  * Maintaining separate models for command and query adds complexity. 
* Managing data consistency
  * Command model changes but query model hasn;t been updated yet - a big challenge
  * Data inconsistencies are major considerations 
* Performance Implications
  * On the brighter side, one of the compelling reasons to use CQRS is its potential to improve performance.
* Handling transactions
* 