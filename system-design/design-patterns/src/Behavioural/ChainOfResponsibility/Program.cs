using System;

namespace ChainOfResponsibility
{
    public class Program
    {
		public static void Main(string[] args)
		{
			LeaveApplication application = LeaveApplication.GetBuilder().withType(LeaveApplication.Type.Sick)
											  .From(DateTime.Now).To( new DateTime(2018, 2, 28))
											  .build();
			Console.WriteLine(application);
			Console.WriteLine("**************************************************");
			ILeaveApprover approver = createChain();
			approver.ProcessLeaveApplication(application);
			Console.WriteLine(application);
		}

		private static ILeaveApprover createChain()
		{
			Director director = new Director(null);
			Manager manager = new Manager(director);
			ProjectLead lead = new ProjectLead(manager);
			return lead;
		}
	}
}
