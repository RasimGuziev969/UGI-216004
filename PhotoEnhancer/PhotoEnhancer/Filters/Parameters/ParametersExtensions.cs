using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public static class ParametersExtensions
    {
        public static ParameterInfo[] GetDecription(this IParameters parameters) =>
            parameters
            .GetType()
            .GetProperties()
            .Select(p => p.GetCustomAttributes<ParameterInfo>())
            .Where(a => a.Count() > 0)
            .SelectMany(a => a)
            .Cast<ParameterInfo>()
            .ToArray();


        public static void SetValues(this IParameters parameters, double[] values)
        {
            var properties = parameters
                .GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttributes<ParameterInfo>().Count() > 0)
                .ToArray();

            if (properties.Length != values.Length)
                throw new ArgumentException();

            for (var i = 0; i < properties.Length; i++)
                properties[i].SetValue(parameters, values[i]);
        }
    }
}
