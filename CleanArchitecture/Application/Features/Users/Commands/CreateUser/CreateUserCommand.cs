using Application.Features.Users.Models;
using Domain.Enums;
using MediatR;
using System;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Gender { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string Blood { get; set; }
    }
}
