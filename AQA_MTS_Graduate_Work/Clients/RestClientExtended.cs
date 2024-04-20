using AQA_MTS_Graduate_Work.Helpers.Configuration;
using RestSharp.Authenticators;
using RestSharp;
using System.Diagnostics;
using NLog;

namespace AQA_MTS_Graduate_Work.Clients;
public sealed class RestClientExtended   //Обертка клиента
{
    private readonly RestClient _client;
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public RestClientExtended()     //прописываем авторизацию
    {
        var options = new RestClientOptions(Configurator.AppSettings.URL ?? throw new InvalidOperationException())
        {
            Authenticator =
                new HttpBasicAuthenticator(Configurator.Admin.Username, Configurator.Admin.Password)
        };

        _client = new RestClient(options);  // создаем рест клиент

        Debug.Assert(Configurator.Admin != null, "Configurator.Admin != null");
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

    private void LogRequest(RestRequest request)
    {
        _logger.Debug($"{request.Method} request to: {request.Resource}");

        var body = request.Parameters
            .FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;

        if (body != null)
        {
            _logger.Debug($"Request body: {body}");
        }
    }

    private void LogResponse(RestResponse response)
    {
        if (response.ErrorException != null)
        {
            _logger.Error(
                $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
        }

        _logger.Debug($"Request finished with status code: {response.StatusCode}");

        if (!string.IsNullOrWhiteSpace(response.Content))
        {
            _logger.Debug($"Response content: {response.Content}");
        }
    }

    // 2 асинхронных метода . 1 метод для выполнения запроса, который возвращает рест респонс объект
    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync(request);

        return response;
    }
    // Десирилизация. Превращает ответ в объект класс \ используем дженерики
    public async Task<T> ExecuteAsync<T>(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync<T>(request);
        LogResponse(response);

        return response.Data ?? throw new InvalidOperationException();
    }
}