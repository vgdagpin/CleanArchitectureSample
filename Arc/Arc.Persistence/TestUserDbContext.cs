using Arc.Application.Common.Interfaces;
using Arc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arc.Persistence
{
    public class TestUserDbContext : DbContext, ITestUserDbContext
    {
        public TestUserDbContext()
            : base("name=ArcUserDbContext")
        {
            Database.SetInitializer<TestUserDbContext>(null);
        }

        public DbSet<Employee> Employees { get; set; }



    }
}
