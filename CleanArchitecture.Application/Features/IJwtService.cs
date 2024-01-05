using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features
{
    public interface IJwtService
    {
        public LoginResponse CreateToken(IdentityUser user);
    }
}
