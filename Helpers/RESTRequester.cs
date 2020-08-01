using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DiscordAPI.Helpers
{
    internal class RESTRequester
    {
        internal const string discordapiUrl = "https://discord.com/api";

        internal HttpClient httpClient;

        private Queue<RESTRequest> requestQueue;
        private Dictionary<string, RateLimit> limits;
        private Dictionary<string, int> routeMaxRequests;

        internal RESTRequester(string token)
        {
            requestQueue = new Queue<RESTRequest>();
            limits = new Dictionary<string, RateLimit>();
            routeMaxRequests = new Dictionary<string, int>();

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bot {token}");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (url, version)");
            httpClient.DefaultRequestHeaders.Add("X-RateLimit-Precision", "millisecond");
        }

        internal void UpdateQueue()
        {
            if (requestQueue.Count > 0)
            {
                RESTRequest[] requests = requestQueue.ToArray();
                requestQueue.Clear();

                for (int i = 0; i < requests.Length; i++)
                {
                    CheckForQueue(requests[i]);
                }
            }
        }

        internal TaskCompletionSource<HttpResponseMessage> Request(RESTRequest request)
        {
            TaskCompletionSource<HttpResponseMessage> source = new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.None);
            request.taskSource = source;

            CheckForQueue(request);

            return source;
        }

        private void CheckForQueue(RESTRequest request)
        {
            if (limits.ContainsKey(request.route.route))
            {
                if (limits[request.route.route].GetRequest())
                    SendRequest(request);
                else
                    requestQueue.Enqueue(request);
            }
            else
            {
                if (routeMaxRequests.ContainsKey(request.route.template))
                {
                    int max = routeMaxRequests[request.route.template];
                    limits.Add(request.route.route, new RateLimit(this, max, max - 1, true));
                }
                else
                {
                    limits.Add(request.route.route, new RateLimit(this, 1, 0));
                }
                SendRequest(request);
            }
        }

        private void GetLimits(HttpResponseMessage response, RESTRequest request)
        {
            HttpResponseHeaders headers = response.Headers;

            //UNSAFE UNSAFE UNSAFE UNSAFE UNSAFE
            int limit = Convert.ToInt32(GetHeader(headers, "X-RateLimit-Limit"));
            int remaining = Convert.ToInt32(GetHeader(headers, "X-RateLimit-Remaining"));
            int resetAfter = (int)(Convert.ToDouble(GetHeader(headers, "X-RateLimit-Reset-After"), CultureInfo.InvariantCulture) * 1000);
            //UNSAFE UNSAFE UNSAFE UNSAFE UNSAFE

            string bucket = GetHeader(headers, "X-RateLimit-Bucket");

            //Console.WriteLine($"Url: {request.route.url}\nRoute: {request.route.route}\nBucket: {bucket}\nLimit: {remaining}/{limit} ({resetAfter} ms)");
            
            if (!routeMaxRequests.ContainsKey(request.route.template))
                routeMaxRequests.Add(request.route.template, limit);

            if (!limits.ContainsKey(request.route.route))
            {
                RateLimit lim = new RateLimit(this, limit, remaining, true);
                limits.Add(request.route.route, lim);
                lim.ResetAfter(resetAfter);
            }
            else
            {
                limits[request.route.route].SetupLimits(limit, remaining);
                limits[request.route.route].ResetAfter(resetAfter);
            }

            if (remaining > 0) UpdateQueue();
        }

        private string GetHeader(HttpResponseHeaders headers, string header)
        {
            string r = null;
            if (headers.Contains(header))
                foreach (var item in headers.GetValues(header))
                    r = item;

            return r;
        }

        private bool GetErrors(HttpResponseMessage response, RESTRequest request)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Got some web errors: {response.StatusCode} {response.ReasonPhrase}\n{response.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");
                
                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    Console.WriteLine("-------Limits-------");
                    foreach (var pair in limits)
                        Console.WriteLine($"K: {pair.Key}\n");
                    Console.WriteLine("-------Max Limits-------");
                    foreach (var pair in routeMaxRequests)
                        Console.WriteLine($"K: {pair.Key} :: {pair.Value}");
                    Console.WriteLine("--------------");
                    Console.WriteLine($"Уебало: {request.route.url}\n{request.route.route}\n{request.route.template}");
                    Console.WriteLine("--------------");
                    Console.WriteLine("Отправляй весь этот лог, начиная с Limits Дяде Жене. Ты уебался в Rate Limit. И поверь, ему пиздец как интересно, почему");
                }
            }

            return !response.IsSuccessStatusCode;
        }

        private async void SendRequest(RESTRequest request)
        {
            string requestUrl = discordapiUrl + request.route.url;

            ByteArrayContent byteContent = null;

            if (request.content != null)
            {
                byteContent = new ByteArrayContent(request.content);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(request.mediaType);
                byteContent.Headers.ContentLength = request.content.Length;
            }

            HttpResponseMessage response;
            switch (request.requestType)
            {
                case RequestType.GET: response = await httpClient.GetAsync(requestUrl); break;
                case RequestType.DELETE: response = await httpClient.DeleteAsync(requestUrl); break;
                case RequestType.POST: response = await httpClient.PostAsync(requestUrl, byteContent); break;
                case RequestType.PATCH: response = await httpClient.PatchAsync(requestUrl, byteContent); break;
                case RequestType.PUT: response = await httpClient.PutAsync(requestUrl, byteContent); break;
                default: return;
            }

            if (byteContent != null) byteContent.Dispose();

            if (!GetErrors(response, request))
                GetLimits(response, request);

            request.taskSource.SetResult(response);
        }
    }
}
