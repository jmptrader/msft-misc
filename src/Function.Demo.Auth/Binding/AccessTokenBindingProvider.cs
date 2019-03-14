//Credit https://github.com/BenMorris/FunctionsCustomSercuity
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

/// <summary>
/// Provides a new binding instance for the function host.
/// </summary>
namespace Function.Demo.Auth
{
    public class AccessTokenBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new AccessTokenBinding();
            return Task.FromResult(binding);
        }
    }

}