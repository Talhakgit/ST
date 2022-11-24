
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResults<User> Register(UserforRegisterDTO userforRegisterDTO, string password);
        IDataResults<User> Login(UserforLoginDTO userforLoginDTO);
        IResult UserExists(string e_mail);
        IDataResults<AccessToken> CreateAccessToken(User user);
        

        

    }
}
