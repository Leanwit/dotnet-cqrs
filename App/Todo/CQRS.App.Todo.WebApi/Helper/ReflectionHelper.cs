using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CQRS.App.WebApi.Helper
{
    public static class ReflectionHelper
    {
        public static Assembly GetAssemblyByName(string name)
        {
            if (name == null) return null;

            name = name.ToUpper(CultureInfo.InvariantCulture);
            return AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.FullName.ToUpper(CultureInfo.InvariantCulture)
                    .Contains(name, StringComparison.InvariantCulture));
        }
    }
}