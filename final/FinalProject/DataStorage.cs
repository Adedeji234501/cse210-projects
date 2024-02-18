using System.Runtime.Serialization.Formatters.Binary;

class DataStorage
{
    private string dataFilePath;

    public DataStorage(string filePath)
    {
        dataFilePath = filePath;
    }

    public void SaveData(PersonalFinanceManager data)
    {
        try
        {
            // Create a FileStream to write data to the file
            using (FileStream fileStream = new FileStream(dataFilePath, FileMode.Create))
            {
                // Create a BinaryFormatter object for serialization
                BinaryFormatter formatter = new BinaryFormatter();
                // Serialize the data and write it to the file
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(fileStream, data);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public PersonalFinanceManager LoadData()
    {
        PersonalFinanceManager loadedData = null;
        try
        {
            // Check if the file exists
            if (File.Exists(dataFilePath))
            {
                // Create a FileStream to read data from the file
                using (FileStream fileStream = new FileStream(dataFilePath, FileMode.Open))
                {
                    // Create a BinaryFormatter object for deserialization
                    BinaryFormatter formatter = new BinaryFormatter();
                    // Deserialize the data from the file
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                    loadedData = (PersonalFinanceManager)formatter.Deserialize(fileStream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                }
                Console.WriteLine("Data loaded successfully.");
            }
            else
            {
                Console.WriteLine("No existing data found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
        return loadedData;
    }
}