using MichaelAzureWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace MichaelAzureWebApp.Models
{
    public class TokenModel
    {
        [Key]
        public string tokenID { get; set; } 
        public DateTime expirationDatetime { get; set; }

        public string conversationId { get; set; }

        public string token { get; set; }

        public double expires_in { get; set; }
   
    }

    public class TokenJason
    {
        [Key]
        public string conversationId { get; set; }

        public string token { get; set; }

        public double expires_in { get; set; }
    }
}
