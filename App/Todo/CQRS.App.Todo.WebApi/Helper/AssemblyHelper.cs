using System.Reflection;

namespace CQRS.App.WebApi.Helper
{
    public static class AssemblyHelper
    {
        private const string AssemblyName = "CQRS.CQRS.CQRS.Test.Src.Todo";
        private static Assembly _instance;

        public static Assembly Instance()
        {
            if (_instance == null)
                _instance = ReflectionHelper.GetAssemblyByName(AssemblyName);

            return _instance;
        }
    }
}