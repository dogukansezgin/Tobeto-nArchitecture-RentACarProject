using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthServices.UserService;

public interface IUserService
{
    public Task<User?> GetByEmail(string email);
    public Task<User> GetById(Guid id);
    public Task<User> Update(User user);
}
