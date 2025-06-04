using System;

namespace AsyncTasks
{
    public class Parser
    {

        private readonly string[] _url;
        private HttpClient _client;

        public Parser(string[] url, HttpClient client)
        {
            this._url = url;
            _client = client;
        }

        private async Task<string> Parse(string url)
        {

                try
                {
                    var responseMessage = await _client.GetAsync(url);

                    responseMessage.EnsureSuccessStatusCode();

                    return await responseMessage.Content.ReadAsStringAsync();

                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка {ex.Message}");
                    return null;
                }
        }

        public async Task<List<string>> Parse()
        {

            var tasks = new List<Task<string>>();

            foreach(var url in _url)
            {
                tasks.Add(Parse(url));
            }

            var res = await Task.WhenAll(tasks);

            return new List<string>(res);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}