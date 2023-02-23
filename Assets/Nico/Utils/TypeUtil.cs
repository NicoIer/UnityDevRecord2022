using System;

namespace Nico
{
    public static class TypeUtil
    {
        public static Type GetTypeByString(string fullClassName)
        {
            Type dataType = Type.GetType(fullClassName);
            if (dataType == null)
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    dataType = assembly.GetType(fullClassName);
                    if (dataType != null) break;
                }
            }

            return dataType;
        }

    }
}