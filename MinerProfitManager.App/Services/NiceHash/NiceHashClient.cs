using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinerProfitManager.App.Services.NiceHash
{
    public class NiceHashClient
    {
        private readonly string _apiDomain;
        private readonly string _organizationID;
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public NiceHashClient(ApiSettings apiSettings)
        {
            _apiDomain = apiSettings.ApiDomain;
            _organizationID = apiSettings.OrganizationID;
            _apiKey = apiSettings.ApiKey;
            _apiSecret = apiSettings.ApiSecret;
        }

        public string Get(string url)
        {
            return Get(url, false, null);
        }

        public string Get(string url, bool auth, string time)
        {
            var client = new RestSharp.RestClient(_apiDomain);
            var request = new RestSharp.RestRequest(url);

            if (auth)
            {
                string nonce = Guid.NewGuid().ToString();
                string digest = HashBySegments(_apiSecret, _apiKey, time, nonce, _organizationID, "GET", GetPath(url), GetQuery(url), null);

                request.AddHeader("X-Time", time);
                request.AddHeader("X-Nonce", nonce);
                request.AddHeader("X-Auth", _apiKey + ":" + digest);
                request.AddHeader("X-Organization-Id", _organizationID);
            }

            var response = client.Execute(request, RestSharp.Method.GET);
            var content = response.Content;
            return content;
        }

        public string Post(string url, string payload, string time, bool requestId)
        {
            var client = new RestSharp.RestClient(_apiDomain);
            var request = new RestSharp.RestRequest(url);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-type", "application/json");

            string nonce = Guid.NewGuid().ToString();
            string digest = HashBySegments(_apiSecret, _apiKey, time, nonce, _organizationID, "POST", GetPath(url), GetQuery(url), payload);

            if (payload != null)
            {
                request.AddJsonBody(payload);
            }

            request.AddHeader("X-Time", time);
            request.AddHeader("X-Nonce", nonce);
            request.AddHeader("X-Auth", _apiKey + ":" + digest);
            request.AddHeader("X-Organization-Id", _organizationID);

            if (requestId)
            {
                request.AddHeader("X-Request-Id", Guid.NewGuid().ToString());
            }

            var response = client.Execute(request, RestSharp.Method.POST);
            var content = response.Content;
            return content;
        }

        public string Delete(string url, string time, bool requestId)
        {
            var client = new RestSharp.RestClient(_apiDomain);
            var request = new RestSharp.RestRequest(url);

            string nonce = Guid.NewGuid().ToString();
            string digest = HashBySegments(_apiSecret, _apiKey, time, nonce, _organizationID, "DELETE", GetPath(url), GetQuery(url), null);

            request.AddHeader("X-Time", time);
            request.AddHeader("X-Nonce", nonce);
            request.AddHeader("X-Auth", _apiKey + ":" + digest);
            request.AddHeader("X-Organization-Id", _organizationID);

            if (requestId)
            {
                request.AddHeader("X-Request-Id", Guid.NewGuid().ToString());
            }

            var response = client.Execute(request, RestSharp.Method.DELETE);
            var content = response.Content;
            return content;
        }

        #region Helpers
        private static string HashBySegments(string key, string apiKey, string time, string nonce, string orgId, string method, string encodedPath, string query, string bodyStr)
        {
            List<string> segments = new List<string>();
            segments.Add(apiKey);
            segments.Add(time);
            segments.Add(nonce);
            segments.Add(null);
            segments.Add(orgId);
            segments.Add(null);
            segments.Add(method);
            segments.Add(encodedPath == null ? null : encodedPath);
            segments.Add(query == null ? null : query);

            if (bodyStr != null && bodyStr.Length > 0)
            {
                segments.Add(bodyStr);
            }
            return CalculateHMACSHA256Hash(JoinSegments(segments), key);
        }

        private static string GetPath(string url)
        {
            var arrSplit = url.Split('?');
            return arrSplit[0];
        }

        private static string GetQuery(string url)
        {
            var arrSplit = url.Split('?');

            if (arrSplit.Length == 1)
            {
                return null;
            }
            else
            {
                return arrSplit[1];
            }
        }

        private static string JoinSegments(List<string> segments)
        {
            var sb = new StringBuilder();
            bool first = true;
            foreach (var segment in segments)
            {
                if (!first)
                {
                    sb.Append("\x00");
                }
                else
                {
                    first = false;
                }

                if (segment != null)
                {
                    sb.Append(segment);
                }
            }

            return sb.ToString();
        }

        private static string CalculateHMACSHA256Hash(string plaintext, string salt)
        {
            string result = "";
            var enc = Encoding.Default;
            byte[]
            baText2BeHashed = enc.GetBytes(plaintext),
            baSalt = enc.GetBytes(salt);
            System.Security.Cryptography.HMACSHA256 hasher = new System.Security.Cryptography.HMACSHA256(baSalt);
            byte[] baHashedText = hasher.ComputeHash(baText2BeHashed);
            result = string.Join("", baHashedText.ToList().Select(b => b.ToString("x2")).ToArray());
            return result;
        }

        #endregion
    }
}