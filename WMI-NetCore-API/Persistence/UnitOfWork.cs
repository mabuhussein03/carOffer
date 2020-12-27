using WMI_NetCore_API.Core;
using System.Threading.Tasks;
namespace WMI_NetCore_API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WMIDbContext context;

        public UnitOfWork(WMIDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}