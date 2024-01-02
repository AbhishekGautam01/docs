using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Queries;
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

        /*
         subscription{
            instructorCreated{
                id
                firstName
                lastName
                salary
            }
            }
         */
        [Subscribe]
        public InstructorResult InstructorCreated([EventMessage] InstructorResult instructor) => instructor;

        /*
         subscription{
            instructorUpdate(instructorId: "f38f474b-627c-4ce6-b86c-62f34a0045a5"){
                id
                firstName
                lastName
                salary
            }
            }
         */
        [SubscribeAndResolve]
        public ValueTask<ISourceStream<InstructorResult>> InstructorUpdate(Guid instructorId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{instructorId}_{nameof(Subscription.InstructorUpdate)}";
            var subscriptionStream = topicEventReceiver.SubscribeAsync<InstructorResult>(topicName);
            return subscriptionStream;
        }

        /*
         subscription{
            studentCreated{
                id
                firstName
                lastName
                gpa
            }
        }
         */
        [Subscribe]
        public StudentResult StudentCreated([EventMessage] StudentResult student) => student;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<StudentResult>> StudentUpdate(Guid studentId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            var topicName = $"{studentId}_{nameof(Subscription.StudentUpdate)}";
            var subscriptionStream = topicEventReceiver.SubscribeAsync<StudentResult>(topicName);
            return subscriptionStream;
        }
    }
}
