using Arc.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arc.Application.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeVM>>
    {
        private readonly string LastNameFilter;

        public GetEmployeesQuery()
        {

        }

        public GetEmployeesQuery(string lastNameFilter)
        {
            LastNameFilter = lastNameFilter;
        }

        public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeVM>>
        {
            private readonly ITestUserDbContext dbContext;

            public GetEmployeesQueryHandler(ITestUserDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<IEnumerable<EmployeeVM>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
            {
                return await dbContext.Employees.Where(a => request.LastNameFilter != null && a.LastName.Contains(request.LastNameFilter))
                    .Select(a => new EmployeeVM
                    {
                        ID = a.ID,
                        LastName = a.LastName,
                        FirstName = a.FirstName,
                        Gender = a.Gender,
                        MiddleName = a.MiddleName
                    })
                    .ToListAsync(cancellationToken);
            }
        }
    }
}