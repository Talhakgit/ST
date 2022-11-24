using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
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
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);

        }

        public IDataResults<User> Register(UserforRegisterDTO userforRegisterDTO, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordSalt, out passwordHash);
            var user = new User
            {
                e_mail = userforRegisterDTO.e_mail,
                first_name = userforRegisterDTO.first_name,
                last_name = userforRegisterDTO.last_name,
                password_hash = passwordHash,
                password_salt = passwordSalt
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResults<User> Login(UserforLoginDTO userforLoginDTO)
        {
            var userToCheck = _userService.GetByMail(userforLoginDTO.e_mail);
            if(userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if(!HashingHelper.VerifyPasswordHash(userforLoginDTO.password,userToCheck.password_hash,userToCheck.password_salt))
            {
                return new ErrorDataResult<User>(Messages.PasswordNotFound);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessLogin);
        }
         
        public IResult UserExists(string e_mail)
        {
            if(_userService.GetByMail(e_mail) != null)      
            {
                return new ErrorResult(Messages.ExistingUser);
            }
            return new SuccessResult(Messages.NotExists);
        }
    }
}
