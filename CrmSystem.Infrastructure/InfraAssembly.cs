using System.Reflection;

namespace CrmSystem.Infrastructure;

public class InfraAssembly
{
    public static readonly Assembly Assembly = typeof(InfraAssembly).Assembly;
}