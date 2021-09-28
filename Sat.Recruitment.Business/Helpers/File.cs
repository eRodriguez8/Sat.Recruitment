using System.IO;

namespace Sat.Recruitment.Business.Helpers
{
    public static class File
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
