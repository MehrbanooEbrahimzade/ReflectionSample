using System.Reflection;

namespace ReflectionSample
{
    class Program
    {
        public static void Main()
        {
            var name = "FirstClass";
            IClass instance = CreateInstance<IClass>(name);
            instance.SomeMethod();
        }

        public static T CreateInstance<T>(string ClassName)
        {
            Type interfaceType = typeof(T);

            Type? implementingType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => string.Equals(t.Name, ClassName, StringComparison.OrdinalIgnoreCase)
                                    && t.IsClass
                                    && !t.IsAbstract
                                    && interfaceType.IsAssignableFrom(t));

            if (implementingType != null)
            {
                return (T)Activator.CreateInstance(implementingType);
            }

            return default;
        }
    }
}

