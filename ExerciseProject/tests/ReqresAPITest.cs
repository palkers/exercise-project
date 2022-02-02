using NUnit.Framework;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExerciseProject
{
    public class BasicApiTests
    {
        private string realtivePathToProperTestData = "testdata/properUserData.json";
        private string NON_EXISTING_USER_ID = "23";
        private string NOT_FOUND_STATUS = "Request failed with status code NotFound";

        private ReqresApiClient reqresApiClient;
        private string fullPathToProperTestData;
        private UserDetails expectedUserDetails;

        [SetUp]
        public void Setup()
        {
            fullPathToProperTestData = Path.Combine(Environment.CurrentDirectory, realtivePathToProperTestData);
            expectedUserDetails = JsonHandler.DeserializeToUserDetailsObjectFromFile(fullPathToProperTestData);
            reqresApiClient = new ReqresApiClient();
        }

        [Test]
        public async Task ShouldReturnUserDetails()
        {
            //Given
            string userId = expectedUserDetails.data.id.ToString();
            string expectedUserFirstName = expectedUserDetails.data.first_name;

            //When 
            UserDetails userDetails = await reqresApiClient.GetSingleUserDetails(userId);

            //Then
            Assert.AreEqual(userDetails.data.first_name, expectedUserFirstName);
        }


        [Test]
        public void ShouldReturnNotFound()
        {
            //Given

            //When
            var exception = Assert.ThrowsAsync<HttpRequestException>(async () => await reqresApiClient.GetSingleUserDetails(NON_EXISTING_USER_ID));

            //Then
            Assert.AreEqual(NOT_FOUND_STATUS, exception.Message);
        }

    }
}