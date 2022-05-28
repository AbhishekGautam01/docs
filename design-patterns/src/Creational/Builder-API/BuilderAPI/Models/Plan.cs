using System.Collections.Generic;

namespace BuilderAPI.Models
{
    /// <summary>
    /// Reporesents hosting plan with features collection
    /// </summary>
    public class Plan
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Feature> Features { get; set; } = new List<Feature>();

        public void AddFeature(Feature feature)
        {
            Features.Add(feature);  
        }
    }
}
