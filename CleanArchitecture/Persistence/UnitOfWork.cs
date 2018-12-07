using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context, IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
        }

        public IUserRepository Users { get; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CompleteAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
