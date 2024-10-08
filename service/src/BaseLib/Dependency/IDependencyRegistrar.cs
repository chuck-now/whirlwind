namespace BaseLib.Dependency
{
    /// <summary>
    /// IDependencyRegistrar
    /// </summary>
    public interface IDependencyRegistrar
    {
        void RegisterAssembly(IRegistrationContext context);
    }
}