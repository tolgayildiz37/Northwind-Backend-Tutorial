using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper<JwtAccessToken> _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper<JwtAccessToken> tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<JwtAccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<JwtAccessToken>(accessToken, AuthMessages.CREATE_ACCESS_TOKEN_SUCCEED);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(AuthMessages.USER_NOT_FOUND);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(AuthMessages.PASSWORD_ERROR);
            }

            return new SuccessDataResult<User>(userToCheck, AuthMessages.SUCCESSFUL_LOGIN);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = UserExists(userForRegisterDto.Email);
            if (userExists.Success)
            {
                return new ErrorDataResult<User>(userExists.Message);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            return new SuccessDataResult<User>(user, AuthMessages.USER_REGISTERED);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new SuccessResult(AuthMessages.USER_ALREADY_EXISTS);
            }
            return new ErrorResult();
        }
    }
}
