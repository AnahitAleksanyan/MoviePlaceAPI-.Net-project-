using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class UserForJson

    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("role")]
        public int Role { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        public UserForJson(string username, string password, string fullName, string email, string phoneNumber, string dateOfBirth, int gender, int role, string salt)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Role = role;
            Salt = salt;
        }

        public UserForJson()
        {
        }
    }
}
