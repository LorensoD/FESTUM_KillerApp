using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FESTUMKillerApp.Models
{
    public class ChatModel: UserModel
    {
        [Required]
        public string bericht { get; set; }
    }
}