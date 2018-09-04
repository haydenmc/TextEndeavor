using System.Threading.Tasks;

namespace TextEndeavor.Providers
{
    public interface IPlayerDataProvider<TPlayerId>
    {
        Task<bool> DataExistsForPlayerWithId(TPlayerId id);
    }
}