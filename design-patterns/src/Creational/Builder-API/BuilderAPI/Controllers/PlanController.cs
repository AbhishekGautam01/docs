using BuilderAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuilderAPI.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanDirector _director;
        public PlanController(IPlanDirector planDirector)
        {
            _director = planDirector;   
        }
        public IActionResult Index()
        {
            PricingPlanModel model = new PricingPlanModel();

            // Build Basic Plan

            var basicPlanBuilder = new BasicPlanBuilder();
            _director.SetPlanBuilder(basicPlanBuilder);
            _director.BuildBasicPlan();
            model.BasicPlan = basicPlanBuilder.GetPlan();

            // Build Enterprise Plan 

            var enterprisePlanBuilder = new EnterprisePlanBuilder();
            _director.SetPlanBuilder(enterprisePlanBuilder);
            _director.BuildEnterprisePlan();
            model.EnterPrisePlan = enterprisePlanBuilder.GetPlan();


            var customPlanBuilder = new BasicPlanBuilder();
            customPlanBuilder.BuildDiskSpaceFeature();
            customPlanBuilder.BuildBandwidthFeature();
            model.CustomPlan = customPlanBuilder.GetPlan();

            return View(model);
        }
    }
}
