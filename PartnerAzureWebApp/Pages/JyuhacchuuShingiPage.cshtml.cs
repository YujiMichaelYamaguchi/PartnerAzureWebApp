using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelAzureWebApp.Data;
using MichaelAzureWebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MichaelAzureWebApp.Pages
{
    public class JyuhacchuuShingiPageModel : PageModel
    {
        //private readonly string directLineSecret = "j-zkn8_Hfd0.PAzhK-yoJfGrWdI5kIJX_5q5A0dOJHhlxfCv86lY8zI";
        private readonly string directLineSecret = "LjczVanzaRU.dLnYyW8KfbaSl7OXFlKRaRKbRhoHFyz9iQPelU8Hs2c";

        private readonly string tokenModelId = "FFSRPAJyuhacchuuShingiBot";
        private readonly string speechSubscriptionKey = "5ba5dbcb626a4f9990e6c6c7c36ce1f5";
        private readonly TokenContext _context;

        [BindProperty]
        public string botToken { get; set; }
        [BindProperty]
        public string region { get; set; } = "westus2";
        [BindProperty]
        public string authorizationToken { get; set; }

        public JyuhacchuuShingiPageModel(TokenContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            TokenHelper tokenHelper = new TokenHelper(_context);

            botToken = tokenHelper.getBotToken(tokenModelId, directLineSecret).Result;

            authorizationToken = tokenHelper.getSpeechServiceToken(region, speechSubscriptionKey).Result;
        }
    }
}