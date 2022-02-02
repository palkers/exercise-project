using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;


namespace ExerciseProject
{
    class ReqresApiClient
    {
        private const string BASE_URL = "https://reqres.in/api/";
        private const string USERS_URI = "users/";
        private readonly RestClient restClient;

        public ReqresApiClient()
        {
            restClient = new RestClient(BASE_URL);
            Serilog.Log.Information($"rest client for {BASE_URL} was created");
        }

        public async Task<UserDetails> GetSingleUserDetails(string userId)
        {
            string certainUserURI = USERS_URI + userId; 
            var request = new RestRequest(certainUserURI, Method.Get);
            var response = await restClient.GetAsync(request);
            UserDetails usersDetails = JsonSerializer.Deserialize<UserDetails>(response.Content);
            Serilog.Log.Information($"rest call {request.Method} was performed sucesfully");

            return usersDetails;
        }

        public async Task<RestResponse> GetSingleUserDetails(string userId)
        {

        }

    }
}
