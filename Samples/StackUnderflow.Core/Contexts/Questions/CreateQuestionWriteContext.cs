using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static LanguageExt.Prelude;
using Access.Primitives.IO;
using LanguageExt;
using System.Linq;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class CreateQuestionWriteContext
    {
        public ICollection<Tenant> Tenants { get; }
        public ICollection<TenantUser> TenantUsers { get; }
        public ICollection<User> Users { get; }
        public ICollection<Post> Posts { get; }

        public CreateQuestionWriteContext (ICollection<Tenant> tenants, ICollection<TenantUser> tenantUsers ,ICollection<User> users, ICollection<Post> posts)
        {
            Tenants = tenants ?? new List<Tenant>(0);
            TenantUsers = tenantUsers ?? new List<TenantUser>(0);
            Users = users ?? new List<User>(0);
            Posts = posts ?? new List<Post>(0); ;
        }

    }
}
