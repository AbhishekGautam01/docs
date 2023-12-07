namespace ChainOfResponsibility
{
    public class ProjectLead: Employee
    {
		public ProjectLead(ILeaveApprover successor): base("Project Lead", successor)
		{
		}

	protected override bool processRequest(LeaveApplication application)
		{
			//type is sick leave & duration is less than or equal to 2 days
			if (application.getType() == LeaveApplication.Type.Sick)
			{
				if (application.getNoOfDays() <= 2)
				{
					application.approve(GetApproverRole());
					return true;
				}
			}
			return false;
		}
	}
}
