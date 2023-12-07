namespace ChainOfResponsibility
{
    public class Director: Employee
    {
		public Director(ILeaveApprover nextApprover): base("Director", nextApprover)
		{
		}

	protected override bool processRequest(LeaveApplication application)
		{
			if (application.getType() == LeaveApplication.Type.PTO)
			{
				application.approve(GetApproverRole());
				return true;
			}
			return false;
		}

	}
}
