using System.Threading.Tasks;

namespace projekt.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}