using System.IO;
using System.Text.Json;

namespace ExerciseProject
{
    public static class JsonHandler
    {
        public static UserDetails DeserializeToUserDetailsObject(string stringToDeserialize)
        {
            return JsonSerializer.Deserialize<UserDetails>(stringToDeserialize);
        }

        public static UserDetails DeserializeToUserDetailsObjectFromFile(string nameOfJsonFile)
        {
            string fileContent = File.ReadAllText(nameOfJsonFile);
            return DeserializeToUserDetailsObject(fileContent);
        }
    }
}
