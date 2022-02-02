using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExerciseProject
{
    public class BasicApiTests
    {
        private ReqresApiClient reqresApiClient;
        private string realtivePathToProperTestData = "testdata/properUserData.json";
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
        public async Task ShouldReturnNotFound()
        {
            //Given
            
            //When
            var response = await reqresApiClient.GetSingleUserDetails
        }

    }
}