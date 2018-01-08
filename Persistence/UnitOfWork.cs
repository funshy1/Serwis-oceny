using System.Threading.Tasks;

namespace projekt.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceDbContext context;

        public UnitOfWork(ServiceDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}