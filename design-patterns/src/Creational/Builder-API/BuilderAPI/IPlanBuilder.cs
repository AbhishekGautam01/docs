using BuilderAPI.Models;

namespace BuilderAPI
{
    public interface IPlanBuilder
    {
        void BuildDiskSpaceFeature();
        void BuildDatabaseFeature();
        void BuildBandwidthFeature();
        void BuildSslFeature();

        Plan GetPlan();
    }
}
