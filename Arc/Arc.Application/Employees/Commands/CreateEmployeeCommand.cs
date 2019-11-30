using Arc.Application.Common.Interfaces;
using Arc.Domain.Entities;
using Arc.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arc.Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }


        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly ITestUserDbContext dbContext;

            public CreateEmployeeCommandHandler(ITestUserDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee _newUser = new Employee
                {
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    Gender = request.Gender
                };

                dbContext.Employees.Add(_newUser);
                await dbContext.SaveChangesAsync(cancellationToken);

                return _newUser.ID;
            }
        }
    }
}
