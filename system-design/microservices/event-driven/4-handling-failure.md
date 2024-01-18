# Preserving order after failure
* lets say `customer-created` fails we can publish to retry queue 
* Now for this failed customer created if we get the `billing-detail` we can't process this either untill retry queue message is processed.
* Log the event into persistent data store the failed event with identifier and stare.
* Now when a new event comes it we can check the persistent store if any event regarding that we can't process and hold this new event in a holding queue.
* When we process the retried event and then we can publish all the holding table events in retry topic

Main consumer -- check if any event for the incoming customer is is present in the failing table ? If yes , put the incoming event to Holding table , If no , process it , If processed successfully , acknowledge the offset else put into failing table. 

Retry Producer - Polls the failing table , creates an event and pushes it to retry topic

Retry Consumer - check if any event in the retry topic , processes it , if successful , gets all the messages from holding table and pushes it to retry topic. What happens if three messages were in holding table for same customer id and all three got pushed to the retry topic and first message fails ? What does retry consumer do ?