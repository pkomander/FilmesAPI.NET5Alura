using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _signInManager
                    .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            //buscando pelo email do usuario no banco
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                string codigoRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefinicao de senha");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            //buscando pelo email do usuario no banco
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (resultadoIdentity.Succeeded)
            {
                return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            }

            return Result.Fail("Erro ao tentar recuperar senha!");
        }

        private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedEmail == email.ToUpper());
        }
    }
}
