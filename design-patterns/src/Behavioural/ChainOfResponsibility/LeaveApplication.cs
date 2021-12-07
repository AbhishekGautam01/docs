using System;

namespace ChainOfResponsibility
{
	public class LeaveApplication
	{

		public enum Type { Sick, PTO, LOP };

		public enum Status { Pending, Approved, Rejecetd };

		private Type type;

		private DateTime from;

		private DateTime to;

		private String processedBy;

		private Status status;

		public LeaveApplication(Type type, DateTime from, DateTime to)
		{
			this.type = type;
			this.from = from;
			this.to = to;
			this.status = Status.Pending;
		}

		public Type getType()
		{
			return type;
		}

		public DateTime getFrom()
		{
			return from;
		}

		public DateTime getTo()
		{
			return to;
		}

		public double getNoOfDays()
		{
			return (from - to).TotalDays;
		}

		public String getProcessedBy()
		{
			return processedBy;
		}

		public Status getStatus()
		{
			return status;
		}

		public void approve(String approverName)
		{
			this.status = Status.Approved;
			this.processedBy = approverName;
		}

		public void reject(String approverName)
		{
			this.status = Status.Rejecetd;
			this.processedBy = approverName;
		}

		public static Builder GetBuilder()
		{
			return new Builder();
		}

	
		public override String ToString()
		{
			return type + " leave for " + getNoOfDays() + " day(s) " + status
					+ " by " + processedBy;
		}
		public class Builder
		{
			private Type type;
			private DateTime from;
			private DateTime to;
			private LeaveApplication application;

			public Builder()
			{

			}

			public Builder withType(Type type)
			{
				this.type = type;
				return this;
			}

			public Builder From(DateTime from)
			{
				this.from = from;
				return this;
			}

			public Builder To(DateTime to)
			{
				this.to = to;
				return this;
			}

			public LeaveApplication build()
			{
				this.application = new LeaveApplication(type, from, to);
				return this.application;
			}

			public LeaveApplication getApplication()
			{
				return application;
			}
		}
	}

}
