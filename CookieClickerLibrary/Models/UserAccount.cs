using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CookieClickerLibrary.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [Column(TypeName = "varchar(30)")]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        [MinLength(8)]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        public Player Player { get; set; }

        // it's very important to create new users with this (nickname, password) constructor
        // as it launches the proper chain of creating and populating all the folded data
        // UserAccount -> Player -> List<Building>
        public UserAccount(string nickname, string password)
        {
            Nickname = nickname;
            Password = password;

            Player = new Player(Id);
        }

        public UserAccount()
        {

        }
    }
}
