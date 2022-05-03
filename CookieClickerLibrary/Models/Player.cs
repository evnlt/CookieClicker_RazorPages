using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CookieClickerLibrary.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "integer")]
        public int CookieAmount { get; set; } = 0;

        [Required]
        public int Cps { get; set; } = 0;

        public List<Building> Buildings { get; set; }

        public Player()
        {

        }

        internal Player(int userId)
        {
            UserId = userId;

            createBuildings();
        }

        private void createBuildings()
        {
            Buildings = new List<Building>();
            Dictionary<string, int> buildings = getBuildings();

            foreach (var building in buildings)
            {
                Buildings.Add(new Building(building.Key, building.Value));
            }
        }

        private Dictionary<string, int> getBuildings()
        {
            return new Dictionary<string, int>()
            {
                {"Clicker",1 },
                {"Grandma", 10 },
                {"Farm", 25 },
                {"Mine", 50 },
            };
        }
    }
}
