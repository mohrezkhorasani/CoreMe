
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence.Interceptor
{
    public class TimestampInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            UpdateTimestamps(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            UpdateTimestamps(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void UpdateTimestamps(DbContext? context)
        {
            if (context == null) return;

            var now = DateTime.UtcNow;

            foreach (var entry in context.ChangeTracker.Entries<IHasTimestamps>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateInsert = now;
                        entry.Entity.DateUpdate = now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.DateUpdate = now;
                        break;
                }
            }
        }
    }
}
