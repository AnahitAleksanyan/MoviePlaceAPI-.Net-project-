using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieAPIAuthentication.Models;
using MovieAPIAuthentication.Utils;
using MovieAPIAuthentication.Validators;
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
    public class RegisterController : ControllerBase
    {

        MovieDBContext dbContext = new MovieDBContext();

        [HttpPost]
        public string Post([FromBody] UserForJson value)
        {
            //check User have existing in database
            if (!dbContext.TbIusers.Any(user => user.Username.Equals(value.Username)))
            {
                TbIuser tbIuser = UserConverter.ConvertJsonUserToUser(value);
                ValidatorResult validatorResult = UserValidator.IsValidUser(tbIuser);
                if (!validatorResult.IsValid)
                {
                    return JsonConvert.SerializeObject(validatorResult.ValidationMessage);
                }

                TbIuser user = new TbIuser();
                user.Username = tbIuser.Username;
                user.Email = tbIuser.Email;
                user.DateOfBirth = tbIuser.DateOfBirth;
                user.FullName = tbIuser.FullName;
                user.Gender = tbIuser.Gender;
                user.Role = Role.User;
                user.PhoneNumber = tbIuser.PhoneNumber;
                user.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
                user.Password = Convert.ToBase64String(Common.SaltHashPassword(
                    Encoding.ASCII.GetBytes(tbIuser.Password),
                    Convert.FromBase64String(user.Salt)));

                //Add to DB
                try
                {
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Register successfully");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("User is existing in Database.");
            }
        }
    }
}
