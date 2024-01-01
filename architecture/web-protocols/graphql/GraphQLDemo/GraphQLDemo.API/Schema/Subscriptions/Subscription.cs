using GraphQLDemo.API.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Subscriptions
{
    public class Subscription
    {
        //Clients can subscribe to updates on our APIs and recieve the updates
        /*
         subscription{
            courseCreated{
                id
                name
                subject
               }
            }
        */
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        /*
         subscription{
          courseUpdate(courseId: "653e42c2-75bf-4c55-aea0-aa43ebbc5535"){
            name,
            subject
          }
        }
         */
        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdate(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{courseId}_{nameof(Subscription.CourseUpdate)}";
            var subscriptionStream = topicEventReceiver.SubscribeAsync<CourseResult>(topicName);
            return subscriptionStream;
        }
    }
}
