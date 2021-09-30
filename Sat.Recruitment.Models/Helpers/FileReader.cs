using System.IO;

namespace Sat.Recruitment.Models.Helpers
{
    public static class FileReader
    {
        public static StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            
            return reader;
        }
    }
}
