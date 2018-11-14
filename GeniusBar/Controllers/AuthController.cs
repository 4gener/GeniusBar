using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using GeniusBar.Models;

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
        
        private User getCooikedUser()
        {
            // To be implemented 
            // throw new System.NotImplementedException();
            
            var cookie = System.Web.HttpContext.Current.Request.Cookies["GB"];
            if (cookie == null) return null;
            var user = db.Users.Where(e => e.COOKIE == cookie.Value).FirstOrDefault();
            return user;
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
                COOKIE = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(data.Email, "MD5")
                    .ToLower(),
            };

            if (db.Users.Count(e => e.Name == data.Name) > 0)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new
                {
                    message = "换一个名字哦"
                });
            }

            if (db.Users.Count(e => e.Email == data.Email) > 0)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new
                {
                    message = "已经注册过啦"
                });
            }

            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                HttpResponseMessage res = Request.CreateResponse(user);
                //var cookie = new CookieHeaderValue("GB", user.COOKIE);
                //cookie.Path = "/";
                //res.Headers.AddCookies(new CookieHeaderValue[] {cookie});
                return res;
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

        // POST: api/engineer_egister
        [HttpPost]
        [Route("api/engineer_register")]
        public HttpResponseMessage EngineerRegister(RegisterData data)
        {
            User user = new User()
            {
                Name = data.Name,
                Email = data.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Role_ID = 2,
                COOKIE = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(data.Email, "MD5")
                    .ToLower(),
            };

            if (db.Users.Count(e => e.Name == data.Name) > 0)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new
                {
                    message = "换一个名字哦"
                });
            }

            if (db.Users.Count(e => e.Email == data.Email) > 0)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new
                {
                    message = "已经注册过啦"
                });
            }

            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                HttpResponseMessage res = Request.CreateResponse(user);
                //var cookie = new CookieHeaderValue("GB", user.COOKIE);
                //cookie.Path = "/";
                //res.Headers.AddCookies(new CookieHeaderValue[] {cookie});
                return res;
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
            var cookiedUser = getCooikedUser();
            if (cookiedUser != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    message = "请先退出再登录"
                });
            }
            
            User user = db.Users.First(u => u.Email == data.Email);

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new
                {
                    message = "用户不存在"
                });
            }

            if (BCrypt.Net.BCrypt.Verify(data.Password, user.Password))
            {
                HttpResponseMessage res = Request.CreateResponse(user);
                var cookie = new CookieHeaderValue("GB", user.COOKIE);
                cookie.Path = "/";
                res.Headers.AddCookies(new CookieHeaderValue[] {cookie});
                return res;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new
                {
                    message = "密码错误"
                });
            }
        }

        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage LogOut()
        {
            HttpResponseMessage res = Request.CreateResponse(new
            {
                message = "登出成功"
            });
            var cookie = new CookieHeaderValue("GB", "");
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Path = "/";
            res.Headers.AddCookies(new CookieHeaderValue[] {cookie});
            return res;
        }
    }
}
