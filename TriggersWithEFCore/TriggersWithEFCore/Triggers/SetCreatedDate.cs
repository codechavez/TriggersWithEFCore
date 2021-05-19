using EntityFrameworkCore.Triggered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TriggersWithEFCore.Models;

namespace TriggersWithEFCore
{
    public class SetCreatedDate : IBeforeSaveTrigger<User>
    {
        public Task BeforeSave(ITriggerContext<User> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
                context.Entity.CreatedDate = DateTime.Now;

            return Task.CompletedTask;
        }
    }
}
