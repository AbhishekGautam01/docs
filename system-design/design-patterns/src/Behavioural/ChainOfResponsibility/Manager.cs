namespace ChainOfResponsibility
{
    public class Manager: Employee
    {
		public Manager(ILeaveApprover nextApprover): base("Manager", nextApprover)
		{
		}

		
	protected override bool processRequest(LeaveApplication application)
		{
			switch (application.getType().ToString())
			{
				case "Sick":
					application.approve(GetApproverRole());
					return true;
				case "PTO":
					if (application.getNoOfDays() <= 5) 
					{
						application.approve(GetApproverRole());
					}
					break;
			}
			return false;
		}
	}
}
