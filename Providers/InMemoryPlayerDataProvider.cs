using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TextEndeavor.Models;

namespace TextEndeavor.Providers
{
    public class InMemoryPlayerDataProvider<TPlayerId> : IPlayerDataProvider<TPlayerId>
    {
        private Dictionary<TPlayerId, PlayerData> playerData;

        public InMemoryPlayerDataProvider()
        {
            playerData = new Dictionary<TPlayerId, PlayerData>();
        }

        public Task<bool> DataExistsForPlayerWithId(TPlayerId id)
        {
            return Task.FromResult<bool>(playerData.ContainsKey(id));
        }
    }

    public static class InMemoryPlayerDataProviderExtensionMethods
    {
        public static void AddInMemoryPlayerDataProvider<TPlayerId>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IPlayerDataProvider<TPlayerId>>(new InMemoryPlayerDataProvider<TPlayerId>());
        }
    }
}