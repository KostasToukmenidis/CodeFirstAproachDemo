using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstAproachDemo.Models;

namespace CodeFirstAproachDemo.ViewModels
{
    //Creating this view model class to be able to have the WeaponTypes as a drop down list in the WeaponController Create View
    public class WeaponViewModel
    {
        public Weapon Weapon { get; set; }

        //Could make a list instead but I didn't want to create edit/details/delete buttons in view
        public IEnumerable<WeaponType> WeaponTypes { get; set; }
    }
}