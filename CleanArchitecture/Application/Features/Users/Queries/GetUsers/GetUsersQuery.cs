using MediatR;
using Application.Features.Users.Models;
using System.Collections.Generic;

namespace Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {}
}
