using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPIAuthentication.Models;
using MovieAPIAuthentication.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPIAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        MovieDBContext dbContext = new MovieDBContext();


        [HttpPost]
        public string Post([FromBody] TbIuser value)
        {
            //Check existing
            if (dbContext.TbIusers.Any(user => user.Username.Equals(value.Username)))
            {
                TbIuser user = dbContext.TbIusers.Where(user => user.Username.Equals(value.Username)).First();

                //Calculate hash password from data of Client and compare with hash in server with salt.
                var client_post_hash_password = Convert.ToBase64String(
                    Common.SaltHashPassword(
                        Encoding.ASCII.GetBytes(value.Password),
                        Convert.FromBase64String(user.Salt)));

                if (client_post_hash_password.Equals(user.Password))
                {
                    Response.StatusCode = StatusCodes.Status200OK;
                    return JsonConvert.SerializeObject(user);
                }
                else
                {
                    Response.StatusCode = StatusCodes.Status403Forbidden;
                    return JsonConvert.SerializeObject("Wrong Password");
                }
            }
            else
            {
                Response.StatusCode = StatusCodes.Status403Forbidden;
                return JsonConvert.SerializeObject("User is not existing in Database");
            }
        }
    }
}
