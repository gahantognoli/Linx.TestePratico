using System.Threading.Tasks;

namespace Linx.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
