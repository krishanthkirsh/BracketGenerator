using System.Text.Json;

namespace BracketGenerator.Helper
{
    public static class Utilities
    {
        public static T RetrieveData<T>(string FilePath) 
        {
            try
            {
                string jsonData = File.ReadAllText(FilePath);
                var processedData = JsonSerializer.Deserialize<T>(jsonData);
                if (processedData == null)
                {
                    Console.WriteLine("No data found json file.");
                }
                return processedData;
            }
            catch (Exception ex) {
                Console.WriteLine($"An error occurred while reading the data: {ex.Message}");
                return default;
            }
           
        }

        public static bool GetUserChoice(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine()?.Trim().ToUpper();

            return input switch
            {
                "Y" or "YES" => true,
                "N" or "NO" => false,
                _ => false,
            };
        }
    }
}
