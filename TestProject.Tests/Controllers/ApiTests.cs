using System.Net.Http.Headers;
using System.Text;

namespace Controllers.Api.Tests;

public class ApiTests {

  [Fact]
  public async void Check_Post_Request_Success() {
    var handler = new HttpClientHandler();
    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
    handler.ServerCertificateCustomValidationCallback =
      (httpRequestMessage, cert, cetChain, policyErrors) => {
        return true;
      };

    HttpClient client = new HttpClient(handler);
    client.BaseAddress = new Uri("https://localhost:5000/");
    client.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header

    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/robots/closest");
    request.Content = new StringContent("{\"loadId\":1,\"x\":33, \"y\":44}",
      Encoding.UTF8,
      "application/json"); //CONTENT-TYPE header

    var apiResponse = await client.SendAsync(request);

    Assert.True(apiResponse.IsSuccessStatusCode);
  }

  [Fact]
  public async void Check_Post_Request_Fail() {
    var handler = new HttpClientHandler();
    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
    handler.ServerCertificateCustomValidationCallback =
      (httpRequestMessage, cert, cetChain, policyErrors) => {
        return true;
      };

    var apiClient = new HttpClient(handler);

    string ApiBaseUrl = "https://localhost:5000/";
    var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/api/robots/closest");

    Assert.False(apiResponse.IsSuccessStatusCode);
  }
}