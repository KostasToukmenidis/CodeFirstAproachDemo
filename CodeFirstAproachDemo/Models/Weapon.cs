using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using CodeFirstAproachDemo.Controllers;

namespace CodeFirstAproachDemo.Models
{
    public class Weapon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        [DisplayName("Weapon Name")]
        public string Name { get; set; }

        //Foreign Key referencing WeaponType
        //[DisplayName("Weapon Type")] // Using DisplayName so WeaponTypeId doesn't show in Create View changed the view code, I am just going straight to WeaponType.Name now
        public int WeaponTypeId { get; set; }

        [DisplayName("Weapon Price")]
        //[DisplayFormat(DataFormatString = "{ 0:C0 }")] //Euro sign next to the price | {0:c} | "{0:n} &euro"
        public decimal Price { get; set; }

        //This property is used for navigation purposes, it's not used inside our database, there isn't a column with that property but I can easily go like
        //weapon.WeaponType.Name for example
        public WeaponType WeaponType { get; set; }
    }
}