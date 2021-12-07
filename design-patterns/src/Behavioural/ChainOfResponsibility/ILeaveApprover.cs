namespace ChainOfResponsibility
{
	public interface ILeaveApprover
	{
		void ProcessLeaveApplication(LeaveApplication application);
		string GetApproverRole();
	}
}
