using System.Reflection;

namespace ValidationUtility
{
    public class ObjectValidationHelper
    {
        public static object GetValidUser(string userName, Object[] objects)
        {
            foreach (var obj in objects)
            {
                Type objType = obj.GetType();
                MethodInfo[] methods = objType.GetMethods();

                foreach (MethodInfo method in methods)
                {
                    ParameterInfo[] parameters = method.GetParameters();

                    if (parameters.Length == 1 && parameters[0].ParameterType == typeof(string))
                    {
                        object result = method.Invoke(obj, new object[] { userName });

                        if (result.GetType().IsEnum && result == "Exist")
                        {
                            return result;
                        }
                    }
                }
            }

            return default;
        }
    }
}
