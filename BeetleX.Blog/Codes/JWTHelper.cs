using BeetleX.FastHttpApi;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BeetleX.Blog
{
    public class JWTHelper
    {
        public const string TOKEN_KEY = "Token";

        private string mIssuer = null;

        private string mAudience = null;

        private SecurityKey mSecurityKey;

        private SigningCredentials mSigningCredentials;

        private TokenValidationParameters mTokenValidation = new TokenValidationParameters();

        private JwtSecurityTokenHandler mJwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        public JWTHelper(string issuer, string audience, byte[] key)
        {
            mIssuer = issuer;
            mAudience = audience;
            mSecurityKey = new SymmetricSecurityKey(key);
            if (string.IsNullOrEmpty(mIssuer))
            {
                mTokenValidation.ValidateIssuer = false;
            }
            else
            {
                mTokenValidation.ValidIssuer = mIssuer;
            }
            if (string.IsNullOrEmpty(mAudience))
            {
                mTokenValidation.ValidateAudience = false;
            }
            else
            {
                mTokenValidation.ValidAudience = mAudience;
            }
            mTokenValidation.IssuerSigningKey = mSecurityKey;
            mSigningCredentials = new SigningCredentials(mSecurityKey, SecurityAlgorithms.HmacSha256);
            Expires = 60 * 24;
        }

        public int Expires { get; set; }



        public void ClearToken(HttpResponse response)
        {
            response.SetCookie(TOKEN_KEY, "", "/", DateTime.Now);
        }

        public void CreateToken(HttpResponse response, string name, string role, int timeout = 20)
        {
            string token = CreateToken(name, role, timeout);
            response.SetCookie(TOKEN_KEY, token, "/", DateTime.Now.AddDays(100));
        }

        public string CreateToken(string name, string role, int timeout = 20)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim("Name", name));
            claimsIdentity.AddClaim(new Claim("Role", role));
            var item = mJwtSecurityTokenHandler.CreateEncodedJwt(mIssuer, mAudience, claimsIdentity, DateTime.Now.AddMinutes(-5),
                DateTime.Now.AddMinutes(timeout), DateTime.Now,
               mSigningCredentials);
            return item;
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            return mJwtSecurityTokenHandler.ValidateToken(token, mTokenValidation, out var securityToken);
        }

        public UserInfo GetUserInfo(HttpRequest request)
        {
            string token = request.Cookies[TOKEN_KEY];
            if (string.IsNullOrEmpty(token))
                return null;
            try
            {
                return GetUserInfo(token);
            }
            catch (Exception e_)
            {
                HttpApiServer server = request.Server;
                if (server.EnableLog(EventArgs.LogType.Info))
                {
                    server.Log(EventArgs.LogType.Info, $"{request.RemoteIPAddress} get token error {e_.Message}");
                }
                return null;
            }

        }

        public UserInfo GetUserInfo(string token)
        {
            UserInfo userInfo = new UserInfo();
            if (!string.IsNullOrEmpty(token))
            {
                var info = ValidateToken(token);
                ClaimsIdentity identity = info?.Identity as ClaimsIdentity;
                userInfo.Name = identity?.Claims?.FirstOrDefault(c => c.Type == "Name")?.Value;
                userInfo.Role = identity?.Claims?.FirstOrDefault(c => c.Type == "Role")?.Value;
            }
            return userInfo;
        }

        public class UserInfo
        {
            public string Name;

            public string Role;
        }

        public static JWTHelper Default
        {
            get;
            set;
        }

        public static void Init()
        {
            Default = new JWTHelper("BeetleX", "BeetleX", Convert.FromBase64String(DBModules.DBHelper.Default.Setting.JwtKey.Value));
        }
    }
}
