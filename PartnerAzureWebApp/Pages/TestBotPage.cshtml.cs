using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MichaelAzureWebApp.Models;
using MichaelAzureWebApp.Data;
using MichaelAzureWebApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MichaelAzureWebApp.Pages
{
    public class TestBotPageModel : PageModel
    {
        private readonly string directLineSecret = "lOJ_BxvDA4A.vbslN32SmjeiZpO6-fG_now73KoIZGl4h2xrpvVdGo4";

        private readonly string tokenModelId = "FFSRPATranslationSpeechBotEN";
        private readonly string speechSubscriptionKey = "5ba5dbcb626a4f9990e6c6c7c36ce1f5";

        private readonly TokenContext _context;

        [BindProperty]
        public string botToken { get; set; }
        [BindProperty]
        public string region { get; set; } = "westus2";
        [BindProperty]
        public string authorizationToken { get; set; }

        public TestBotPageModel(TokenContext context) 
        {
            _context = context;
        }
        public async void OnGet()
        {
            TokenHelper tokenHelper = new TokenHelper(_context);
    
            botToken = tokenHelper.getBotToken(tokenModelId, directLineSecret).Result;

            authorizationToken = tokenHelper.getSpeechServiceToken(region, speechSubscriptionKey).Result;

        }
    }
}