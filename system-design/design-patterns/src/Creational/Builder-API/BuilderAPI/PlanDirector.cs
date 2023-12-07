namespace BuilderAPI
{
    public class PlanDirector : IPlanDirector
    {
        private IPlanBuilder _builder; 
        public void BuildBasicPlan()
        {
            _builder.BuildDiskSpaceFeature();
            _builder.BuildDatabaseFeature();
            _builder.BuildBandwidthFeature();
        }

        public void BuildEnterprisePlan()
        {
            _builder.BuildDiskSpaceFeature();
            _builder.BuildDatabaseFeature();
            _builder.BuildBandwidthFeature();
            _builder.BuildSslFeature();
        }

        public void SetPlanBuilder(IPlanBuilder planBuilder)
        {
            _builder = planBuilder; 
        }
    }
}
