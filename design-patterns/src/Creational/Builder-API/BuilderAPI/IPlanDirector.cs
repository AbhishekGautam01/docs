namespace BuilderAPI
{
    public interface IPlanDirector
    {
        void SetPlanBuilder(IPlanBuilder planBuilder);
        void BuildBasicPlan();
        void BuildEnterprisePlan();
    }
}
