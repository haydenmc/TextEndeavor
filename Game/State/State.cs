using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using TextEndeavor.Game.Commands;
using TextEndeavor.Hubs;
using TextEndeavor.Providers;

namespace TextEndeavor.Game.State
{
    public abstract class State<TPlayerId>
    {
        protected IServiceProvider serviceProvider;

        protected IPlayerDataProvider<TPlayerId> playerDataProvider;

        protected IHubContext<GameHub> gameHubContext;

        protected IEnumerable<Type> validCommandTypes;

        protected IEnumerable<Command<TPlayerId>> validCommands
        {
            get
            {
                return validCommandTypes?
                    .Select(ct => 
                        serviceProvider.GetService(ct) as Command<TPlayerId>);
            }
        }

        public State(
            IServiceProvider serviceProvider,
            IPlayerDataProvider<TPlayerId> playerDataProvider,
            IHubContext<GameHub> gameHubContext)
        {
            this.serviceProvider = serviceProvider;
            this.playerDataProvider = playerDataProvider;
            this.gameHubContext = gameHubContext;
        }

        public virtual void EnterState(TPlayerId playerId)
        { }

        public bool ProcessMessage(TPlayerId playerId, string message)
        {
            if (validCommands != null)
            {
                foreach (var command in validCommands)
                {
                    if (command.ProcessMessage(playerId, this, message))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}