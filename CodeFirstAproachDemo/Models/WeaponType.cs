using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstAproachDemo.Models
{
    public class WeaponType
    {
        public int Id { get; set; }

        [StringLength(50)]
        [DisplayName("Weapon Type")]
        public string Name { get; set; }
    }
}