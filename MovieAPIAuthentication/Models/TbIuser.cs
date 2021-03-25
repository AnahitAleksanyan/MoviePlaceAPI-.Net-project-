using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class TbIuser
    {
        [Key]
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
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        public virtual ICollection<MovieUserCast> MovieUserCasts { get; set; }
        public TbIuser(string username, string password, string salt, DateTime dateOfBirth, string email, string fullName, Gender gender, string phoneNumber, Role role)
        {
            Username = username;
            Password = password;
            Salt = salt;
            DateOfBirth = dateOfBirth;
            Email = email;
            FullName = fullName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public TbIuser()
        {
        }
    }
}
