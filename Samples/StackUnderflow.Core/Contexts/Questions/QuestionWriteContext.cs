using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Access.Primitives.IO;
using LanguageExt;


namespace StackUnderflow.Domain.Core.Contexts.Questions
{
   public  class QuestionWriteContext 
    {
        public ICollection<Tenant> Tenants { get; }
        public ICollection<TenantUser> TenantUsers { get; }
        public ICollection<User> Users { get; }

        public QuestionWriteContext(ICollection<Tenant> tenants, ICollection<TenantUser> tenantUsers, ICollection<User> users, ICollection<Post> posts)
        {
            Tenants = tenants ?? new List<Tenant>(0);
            TenantUsers = tenantUsers ?? new List<TenantUser>(0);
            Users = users ?? new List<User>(0);
        }

        public ICollection<Post> Posts { get; }
    }
}
