using EntityFrameworkCore.Triggered;
using System.Threading;
using System.Threading.Tasks;
using TriggersWithEFCore.Models;
using TriggersWithEFCore.Persistence;

namespace TriggersWithEFCore
{
    public class AfterCreateUserBirthday : IAfterSaveTrigger<User>
    {
        readonly TriggersEFCoreContext _triggeredDbContext;

        public AfterCreateUserBirthday(TriggersEFCoreContext context)
        {
            _triggeredDbContext = context;
        }

        public Task AfterSave(ITriggerContext<User> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                _triggeredDbContext.UserBirthdays.Add(new UserBirthday
                {
                    UserId = context.Entity.UserId,
                    Email = context.Entity.Email,
                    Birthday = context.Entity.Birthday,
                    Username = context.Entity.Username
                });

                _triggeredDbContext.SaveChangesAsync();
            }

            return Task.CompletedTask;
        }
    }
}
