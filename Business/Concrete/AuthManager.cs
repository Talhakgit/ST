using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager (IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResults<AccessToken> CreateAccessToken(User user)
        {
            
        }

        public IDataResults<User> Register(UserforRegisterDTO userforRegisterDTO, string password)
        {
            throw new NotImplementedException();
        }

        public IDataResults<User> Login(UserforLoginDTO userforLoginDTO)
        {
            var userToCheck = _userService.GetByMail(userforLoginDTO.e_mail);
            if(userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

        }

        public IResult UserExists(string e_mail)
        {
            throw new NotImplementedException();
        }
    }
}
