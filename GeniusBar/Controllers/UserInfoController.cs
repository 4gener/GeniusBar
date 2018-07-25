using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GeniusBar.Models;
using BCrypt.Net;


namespace GeniusBar.Controllers
{
    public class UserInfoController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        public class UserInfo
        {
            public String username;
            public String oldpassword;
            public String password;
            public String email;
        }

        public class BasicInfo
        {
            public String username;
            public String email;
        }

        private User getCooikedUser()
        {
            // To be implemented 
            // throw new System.NotImplementedException();

            var cookie = System.Web.HttpContext.Current.Request.Cookies["GB"];
            var user = db.Users.Where(e => e.COOKIE == cookie.Value).FirstOrDefault();
            return user;
        }

        [HttpGet]
        [Route("api/userInfo")]
        public IHttpActionResult GetUserInfo()
        {
            var user = getCooikedUser();
            if (user==null)
            {
                return Unauthorized();
            }
            BasicInfo info = new BasicInfo();
            info.username = user.Name;
            info.email = user.Email;
            return Ok(info);
        }

        [HttpPut]
        [Route("api/userInfo")]
        public IHttpActionResult EditUserInfo(UserInfo info)
        {
            var user = getCooikedUser();
            if(user==null)
            {
                return Unauthorized();
            }
            if(BCrypt.Net.BCrypt.Verify(info.password,user.Password))
            {
                return Unauthorized();
            }
            user.Email = info.email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(info.password);
            user.Name = info.username;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(user);
        }
    }
}
