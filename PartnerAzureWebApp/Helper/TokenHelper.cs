using MichaelAzureWebApp.Data;
using MichaelAzureWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MichaelAzureWebApp.Helper
{
    public class TokenHelper
    {
        private readonly TokenContext _context;
        private readonly string tokenGenerateURL = "https://directline.botframework.com/v3/directline/tokens/generate";
        private readonly string tokenRefreshURL = "https://directline.botframework.com/v3/directline/tokens/refresh";

        private readonly string speechTokenID = "SpeechTokenID";
        private readonly string speechTokenGenerateUrl = ".api.cognitive.microsoft.com/sts/v1.0/issueToken";
        private readonly double speechTokenExpirationMinute = 10.0;

        public TokenHelper(TokenContext context)
        {
            _context = context;
        }
        public async Task<string> getBotToken(string tokenModelId,string directLineSecret)
        {
            DateTime expireDatetime = DateTime.MinValue;
            TokenModel tokenModel = new TokenModel();

            if (_context.TokenModels.Any(e => e.tokenID == tokenModelId))
            {
                tokenModel = _context.TokenModels.Find(tokenModelId);
                expireDatetime = tokenModel.expirationDatetime;
            }
            TokenJason tokenJason = new TokenJason();

            if (DateTime.Now > expireDatetime)
            {
                tokenJason = TokenHelper.getToken(tokenGenerateURL, directLineSecret).Result;
                tokenModel.token = tokenJason.token;
                if (expireDatetime == DateTime.MinValue)
                {
                    tokenModel.tokenID = tokenModelId;
                    tokenModel.expirationDatetime = DateTime.Now.AddSeconds(tokenJason.expires_in);
                    tokenModel.conversationId = tokenJason.conversationId;
                    tokenModel.expires_in = tokenJason.expires_in;
                    _context.Add(tokenModel);
                }
            }
            else
            {
                //tokenJason = TokenHelper.getToken(tokenRefreshURL, tokenModel.token).Result;
                //tokenModel.token = tokenJason.token;
                //tokenModel.expirationDatetime = DateTime.Now.AddSeconds(tokenJason.expires_in);
                tokenJason = TokenHelper.getToken(tokenGenerateURL, directLineSecret).Result;
                tokenModel.token = tokenJason.token;
                if (expireDatetime == DateTime.MinValue)
                {
                    tokenModel.tokenID = tokenModelId;
                    tokenModel.expirationDatetime = DateTime.Now.AddSeconds(tokenJason.expires_in);
                    tokenModel.conversationId = tokenJason.conversationId;
                    tokenModel.expires_in = tokenJason.expires_in;
                    _context.Add(tokenModel);
                }
            }
            
            await _context.SaveChangesAsync();

            return tokenJason.token;

        }
        private static async Task<TokenJason> getToken(string url, string secret)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {

                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(url);

                request.Headers.Add("Authorization", "Bearer " + secret);
                var response = await client.SendAsync(request);

                // 結果の取得とデシリアライズ
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenJason>(jsonResponse);

                return result;

            }
        }

        public async Task<string> getSpeechServiceToken(string region, string subscriptionKey)
        {
            DateTime expireDatetime = DateTime.MinValue;
            TokenModel tokenModel = new TokenModel();

            if (_context.TokenModels.Any(e => e.tokenID == speechTokenID))
            {
                tokenModel = _context.TokenModels.Find(speechTokenID);
                expireDatetime = tokenModel.expirationDatetime;
            }

            if (DateTime.Now > expireDatetime)
            {
                tokenModel.token = TokenHelper.getSpeechToken("https://" + region + speechTokenGenerateUrl, subscriptionKey).Result;

                if (expireDatetime == DateTime.MinValue)
                {
                    tokenModel.tokenID = speechTokenID;
                    tokenModel.expirationDatetime = DateTime.Now.AddMinutes(speechTokenExpirationMinute);
                    tokenModel.conversationId = "";
                    tokenModel.expires_in = speechTokenExpirationMinute;
                    _context.Add(tokenModel);
                }
            }

            await _context.SaveChangesAsync();

            return tokenModel.token;

        }

        private static async Task<string> getSpeechToken(string url, string subscriptionKey)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {

                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(url);

                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                var response = await client.SendAsync(request);

                var result = await response.Content.ReadAsStringAsync();
               
                return result;

            }
        }
    }
}
