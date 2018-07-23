﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Services.Description;
using GeniusBar.Models;
using BCrypt.Net;

namespace GeniusBar.Controllers
{
    public class AuthController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();
        
        public class RegisterData
        {
            public string Name;
            public string Email;
            public string Password;
        }

        // POST: api/Register
        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register(RegisterData data)
        {
            User user = new User()
            {
                Name = data.Name,
                Email = data.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Role_ID = 1,
                Cookie = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(data.Email, "MD5")
                    .ToLower(),
            };

            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                return Request.CreateResponse(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    message = "出错啦"
                });
            }
        }
        
        public class LoginData
        {
            public string Email;
            public string Password;
        }
        
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Register(LoginData data)
        {
            User user = db.Users.First(u => u.Email == data.Email);
            
            if (BCrypt.Net.BCrypt.Verify(data.Password, user.Password))
            {
                return Request.CreateResponse(user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new
                {
                    message = "密码错误"
                });
            }
        }
    }
}