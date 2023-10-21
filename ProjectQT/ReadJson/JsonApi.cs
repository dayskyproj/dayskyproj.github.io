using ProjectQT.Data.DataDating;
using ProjectQT.Data.DataQuizDimensional;
using TextJson = System.Text.Json;

namespace ProjectQT.ReadJson
{
    public class JsonApi : IJsonApi
    {

        private readonly HttpClient Http;
        private readonly TextJson.JsonSerializerOptions Options;
        private string Controlador { get; } = "sample-data/";

        public JsonApi(HttpClient httpClient)
        {
            this.Http = httpClient;
            Options = new TextJson.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<InfoQuizDimensional> JsonQuizDimensional(string version)
        {

            var response = await Http.GetAsync($"{Controlador}/QuizDimensional.json");
            var content = await response.Content.ReadAsStringAsync();
            var apiResultJson = TextJson.JsonSerializer.Deserialize<InfoQuizDimensional[]>(content, Options);

            var result = apiResultJson.FirstOrDefault(x => x.Version == version);

            return await Task.FromResult(result);
        }

        public async Task<InfoDating> JsonDating(string version)
        {

            var response = await Http.GetAsync($"{Controlador}/Dating.json");
            var content = await response.Content.ReadAsStringAsync();
            var apiResultJson = TextJson.JsonSerializer.Deserialize<InfoDating[]>(content, Options);

            var result = apiResultJson.FirstOrDefault(x => x.Version == version);

            return await Task.FromResult(result);
        }
    }
}
