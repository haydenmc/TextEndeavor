using System;
using Microsoft.AspNetCore.SignalR;
using TextEndeavor.Hubs;
using TextEndeavor.Providers;

namespace TextEndeavor.Game.State
{
    public class PlayerDataState<TPlayerId> : State<TPlayerId>
    {
        public PlayerDataState(
            IServiceProvider serviceProvider,
            IPlayerDataProvider<TPlayerId> playerDataProvider,
            IHubContext<GameHub> gameHubContext) : base(serviceProvider, playerDataProvider, gameHubContext)
        {

        }

        public override void EnterState(TPlayerId playerId)
        {
            gameHubContext.Clients.User(playerId)
        }
    }
}