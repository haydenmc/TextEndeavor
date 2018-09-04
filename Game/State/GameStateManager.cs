using System;
using System.Collections.Generic;
using TextEndeavor.Providers;

namespace TextEndeavor.Game.State
{
    public class GameStateManager<TPlayerId>
    {
        protected IEnumerable<Type> commands;
        protected IPlayerDataProvider<TPlayerId> playerDataProvider;

        public GameStateManager(IPlayerDataProvider<TPlayerId> playerDataProvider)
        {
            this.playerDataProvider = playerDataProvider;
        }
    }
}