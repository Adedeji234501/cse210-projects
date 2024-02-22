using System.Text.Json;

class DataStorage
{
    private string dataFilePath;

    public DataStorage(string filePath)
    {
        dataFilePath = filePath;
    }

    public void SaveData(PersonalFinanceManager data)
    {
        string jsonString = JsonSerializer.Serialize(data);
        File.WriteAllText(dataFilePath, jsonString);
    }

    public PersonalFinanceManager LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            string jsonString = File.ReadAllText(dataFilePath);
            return JsonSerializer.Deserialize<PersonalFinanceManager>(jsonString);
        }
        else
        {
            Console.WriteLine("No existing data found.");
            return null;
        }
    }
}