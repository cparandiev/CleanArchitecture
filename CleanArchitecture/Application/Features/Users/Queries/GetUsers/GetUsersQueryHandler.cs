using Application.Features.Users.Models;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetUsersQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Users.ListAllAsync();

            return _autoMapper.Map<List<UserDto>>(entities);
        }
    }
}
