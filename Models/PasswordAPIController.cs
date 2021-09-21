using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordAPIController : ControllerBase
    {
        SystemLoginCredential cred = new SystemLoginCredential();


        [HttpPost]
        public void Login(loginInfo input)
        {
            
        }
        [Route("api/[controller]/password/{pass}")]
        [HttpGet]
        public void ChangePassword(string password)
        {

        }

        [Route("api/[controller]/username/{user}")]
        [HttpGet]
        public void ChangeUsername(string username)
        {

        }
    }

    public class loginInfo
    {
        string username;
        string password;
    }

    public class SystemLoginCredential
    {
        protected string username = "admin";
        protected string password = "12345678";

        public bool CheckCredential(string user, string pass)
        {
            if(user.Equals(username) && pass.Equals(password))
            {
                return true;
            }
            return false;
        }

        public void ChangePassword(string pass)
        {
            bool check = false;
            for(int i =0; i<pass.Count(); i++)
            {
                if (Char.IsUpper(pass[i]))
                {
                    check = true;
                    break;
                }
            }
            if (pass.Contains(" "))
                check = false;
            if(pass.Count() > 8 && pass!=password && check)
            {
                password = pass;
            }
        }

        public void ChangeUsername(string user)
        {
            username = user;
        }
    }
}
