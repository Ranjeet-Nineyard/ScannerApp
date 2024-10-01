using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.MediatR.Users
{
    public class UpdateUser
    {
        public class Request : IRequest<string>
        {
        }
        public class Handler : IRequestHandler<Request, string>
        {
            public Handler()
            {
            }

            public Task<string> Handle(Request request, CancellationToken cancellationToken)
            {
                return Task.FromResult(" Update User ");
            }
        }
    }
}
