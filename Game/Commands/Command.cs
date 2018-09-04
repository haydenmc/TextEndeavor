using TextEndeavor.Game.State;

namespace TextEndeavor.Game.Commands
{
    public abstract class Command<TPlayerId>
    {
        public abstract bool ProcessMessage(TPlayerId playerId, State<TPlayerId> state, string message);
    }
}