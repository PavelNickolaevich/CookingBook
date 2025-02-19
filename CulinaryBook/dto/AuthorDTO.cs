using CulinaryBook.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryBook.dto
{
    public class AuthorDTO
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Experience { get; set; }
    }
    public static class AuthorConverter
    {
        public static AuthorDTO ToDTO(this Authors author)
        {
            return new AuthorDTO
            {
                AuthorID = author.AuthorID,
                AuthorName = author.AuthorName,
                Login = author.Login,
                Password = author.Password,
                BirthOfDate = author.Birth_of_date,
                Phone = author.Phone,
                Email = author.Email,
                Experience = author.Experience
            };
        }

        public static Authors ConvertFromDTO(AuthorDTO authorDTO)
        {
            var author = new Authors
            {
                AuthorID = authorDTO.AuthorID,
                AuthorName = authorDTO.AuthorName,
                Login = authorDTO.Login,
                Password = authorDTO.Password,
                Birth_of_date = authorDTO.BirthOfDate,
                Phone = authorDTO.Phone,
                Email = authorDTO.Email,
                Experience = authorDTO.Experience
            };

            return author;
        }
    }
}

