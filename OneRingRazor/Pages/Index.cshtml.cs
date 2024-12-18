using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("APIClient");
    }

    public List<Anel> Aneis { get; set; } = new();

    public async Task OnGetAsync()
    {
        var response = await _httpClient.GetAsync("api/Anel");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            
            var dataResponse = JsonSerializer.Deserialize<DataResponse>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Atribuir os dados da resposta à propriedade
            Aneis = dataResponse?.Data ?? new List<Anel>();
        }
    }
}

public class DataResponse
{
    public string Message { get; set; }

    public List<Anel> Data { get; set; }
}

public class Anel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Portador { get; set; } = string.Empty;
    public TipoPortador Tipo { get; set; }
    public string Poder { get; set; } = string.Empty;
}

public enum TipoPortador
{
    Elfo = 1,
    Anao = 2,
    Homem = 3,
    Sauron = 4
}