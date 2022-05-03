using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CookieClickerLibrary.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Player")]
        [Required]
        public int PlayerId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        // basic production rate of cookies WITHOUT upgrades
        [Required]
        public int BasicProduction { get; set; }

        // coefficient for basic production of a building
        // BasicProduction * UpgradePercent = real production
        [Required]
        public int UpgradePercent { get; set; } = 1;

        // amount of certain building player has
        [Required]
        public int AmountOwned { get; set; } = 0;

        public Building(string name, int basicProduction)
        {
            Name = name;
            BasicProduction = basicProduction;
        }
        public Building()
        {

        }
    }
}
