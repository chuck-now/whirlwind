namespace BaseLib.Dependency
{
    /// <summary>
    /// IConventionalDependencyRegistrar
    /// </summary>
    public interface IConventionalDependencyRegistrar
    {
        void RegisterAssembly(IConventionalRegistrationContext context);
    }
}