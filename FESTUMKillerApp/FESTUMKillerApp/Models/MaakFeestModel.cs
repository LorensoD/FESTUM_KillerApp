using FestumClasses.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FESTUMKillerApp.Models
{
    public class MaakFeestModel: UserModel
    {
        [Required]
        public Feest feest { get; set; }
    }
}