namespace Platformer.Core
{
    public static partial class Simulation
    {
        
        /// <typeparam name="T"></typeparam>
        static class InstanceRegister<T> where T : class, new()
        {
            public static T instance = new T();
        }
    }
}