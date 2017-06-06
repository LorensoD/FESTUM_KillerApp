using FestumClasses.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FESTUMKillerApp.Models
{
    public class UserModel
    {
        [Required]
        public User huidigeGebruiker { get; set; }
    }
}