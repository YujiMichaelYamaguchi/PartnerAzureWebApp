using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelAzureWebApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace MichaelAzureWebApp.Data
{
    public class TokenContext : DbContext
    {
        public TokenContext(DbContextOptions<TokenContext> options) : base(options)
        {

        }

        public DbSet<TokenModel> TokenModels { get; set; }

    }
}
