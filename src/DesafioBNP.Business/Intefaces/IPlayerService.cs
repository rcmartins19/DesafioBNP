using DesafioBNP.Business.Models;

namespace DesafioBNP.Business.Intefaces
{
    public interface IPlayerService : IDisposable
    {
        Task Add(Player player);
        Task Update(Player player);
        Task Remove(Guid id);
    }
}