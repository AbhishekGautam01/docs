using System;
 
namespace ChainOfResponsibility
{
    public abstract class Employee : ILeaveApprover
    {

        private string role;

        private ILeaveApprover successor;

        public Employee(string role, ILeaveApprover successor)
        {
            this.role = role;
            this.successor = successor;
        }


        public void ProcessLeaveApplication(LeaveApplication application)
        {
            if (!processRequest(application) && successor != null)
            {
                successor.ProcessLeaveApplication(application);
            }
        }

        protected abstract bool processRequest(LeaveApplication application);

        public String GetApproverRole()
        {
            return role;
        }
    }
}
