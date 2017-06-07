using FestumClasses.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FESTUMKillerApp.Models
{
    public class ZoekFeestModel: UserModel
    {
        [Required]
        public List<Feest> feesten { get; set; }
    }
}