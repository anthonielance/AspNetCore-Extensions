using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;
using System.Reflection;

namespace All.AspNetCore.Mvc.Extensions
{
    public class FeatureConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var featureName = GetFeatureName(controller.ControllerType);
            controller.Properties.Add("feature", featureName);
        }

        private object GetFeatureName(TypeInfo controllerType)
        {
            string[] tokens = controllerType.FullName.Split('.');
            string featureName = tokens
                .SkipWhile(t => !t.Equals("features", StringComparison.CurrentCultureIgnoreCase))
                .Skip(1)
                .Take(1)
                .FirstOrDefault();

            return featureName != null ? featureName : "";
        }
    }
}
