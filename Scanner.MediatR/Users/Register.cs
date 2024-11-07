using MediatR;
using Scanner.Data;
using Scanner.Data.Entities;
using Scanner.Data.Enums;
using Scanner.Data.Model;
using Scanner.MediatR.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.MediatR.Users
{
    public class Register
    {
        public class Request : RegisterModel, IRequest<Response<bool>>
        {
             
        }

        public class Handler : IRequestHandler<Request , Response<bool>>
        {
            private readonly AdminDbContext adminDb;
            public Handler(AdminDbContext adminDb)
            {
                this.adminDb = adminDb;
            }

            public Task<Response<bool>> Handle(Request r, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    FullName = r.FullName,
                    Email = r.Email,
                    Phone = r.Phone,
                    AdminId = r.AdminId,
                    Created = DateTime.Now,
                    RoleId = r.RoleId,
                    Role = Enum.GetName(typeof(Role), r.RoleId).ToString(),
                    Updated = DateTime.Now,
                };

                return Task.FromResult(new Response<bool> { Data = true });
            }
        }
    }
}