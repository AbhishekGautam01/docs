# Aggregation, Association and Composition

  * Inheritance: IS A (Parent and Child)
  * Using : HAS A

* **What are the different types of `USING/HAS A` relationship?**
  * **Composition**: 
  * **Association**
  * **Aggregation**
<br/>

* Understanding Part-Whole vocabulary: Sleeves is a part of shirt. Car is WHOLE and wheel is part of it. Letter is part of word and word is whole.
<br/>

* **What is a composition relationship?**
  * Composition and aggregation have PART WHOLE Relationship
  * Composition is a PART-WHOLE relationship where the lifetime of part object and the whole object is same. 
  * In Composition the whole(parent) is owner the part(child), he owns the object, he owns when the object is created and destroyed. This object is not shared with anyone else.
  * Eg if someone is a patient he should have problem else he is not patient hence this is a composition relationship. Problem and Patient are composition relationship. 
<br/>

* **Explain Aggregation?**
  * There is a PART_WHOLE but here lifetime of objects can be different. They can exist independently. Eg Doctor and Patient have aggregation as patient get go to another doctor and doctor can see another patient.
  * In aggregation the whole(part) does not own the child(part). The child object can be shared with other objects. There is no exclusive ownership.
  * The playlist and song and have aggregation as song can exist without playlist. 
<br/>

* **Explain Association?**
  * There is a link between objects.
  * Composition and aggregation are subset of Association. 
  * When we are not clear if it composition and aggregation then devs may call it association.
<br/>

* **UML symbols for composition, aggregation and association?**
  * Association: Simple Arrow
  * Aggregation: Empty Diamond
  * Composition: Filled Diamond