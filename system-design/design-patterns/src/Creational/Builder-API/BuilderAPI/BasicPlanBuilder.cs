using BuilderAPI.Models;

namespace BuilderAPI
{
    public class BasicPlanBuilder : IPlanBuilder
    {
        public Plan Plan { get; set; } = new Plan();

        public BasicPlanBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            Plan = new Plan() { Name = "Basic", Price = 19 };
        }
        public void BuildBandwidthFeature()
        {
            Plan.AddFeature(new Feature() { Title = "Bandwidth", Value = "10 GB " });
        }

        public void BuildDatabaseFeature()
        {
            Plan.AddFeature(new Feature() { Value = "5 GB", Title = "Database" }); 

        }

        public void BuildDiskSpaceFeature()
        {
            Plan.AddFeature(new Feature() { Value = "51 GB", Title = "Disk Space" });
        }

        public void BuildSslFeature()
        {
            Plan.AddFeature(new Feature() { Value = "Not Free", Title = "SSL" });
        }

        public Plan GetPlan()
        {
            Plan result = Plan;
            this.Reset();
            return result;
        }
    }
}
