using MovieAPIAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIAuthentication.Utils
{
    public static class UserConverter
    {
        public static UserForJson ConvertUserToJsonUser(TbIuser tbIuser) {
            UserForJson userForJson = new UserForJson(
                username: tbIuser.Username,
                password: tbIuser.Password,
                fullName: tbIuser.FullName,
                email: tbIuser.Email,
                phoneNumber: tbIuser.PhoneNumber,
                gender: tbIuser.Gender==Gender.Male?1: tbIuser.Gender == Gender.Female?2: tbIuser.Gender == Gender.Other?3:0,
                role: tbIuser.Role == Role.Administrator ? 1 : tbIuser.Role == Role.User ?2:0,
                salt: tbIuser.Salt,
                dateOfBirth: tbIuser.DateOfBirth.ToString()
                );
            return userForJson;
        }

        public static TbIuser ConvertJsonUserToUser(UserForJson userForJson)
        {
            DateTime dateTime = new DateTime();
            DateTime.TryParse(userForJson.DateOfBirth, out dateTime);
            TbIuser tbIuser = new TbIuser(
                username: userForJson.Username,
                password: userForJson.Password,
                fullName: userForJson.FullName,
                email: userForJson.Email,
                phoneNumber: userForJson.PhoneNumber,
                gender: userForJson.Gender==1?Gender.Male: userForJson.Gender == 2?Gender.Female: userForJson.Gender == 3?Gender.Other:0,
                role:userForJson.Role==1?Role.Administrator:userForJson.Role==2?Role.User:0,
                salt: userForJson.Salt,
                dateOfBirth: dateTime
                ) ;
            return tbIuser;
        }
    }
}
