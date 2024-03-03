using System.IO;
using Newtonsoft.Json;

public class FileAction
{
    private string fileName;

    public FileAction(string fileName)
    {
            this.fileName = "default.json";
    }

    public void Load(Journal journal, Prompt prompt)
    {
        Console.Write("Enter the file name or leave blank to load default.json: ");
        string fileName = Console.ReadLine();
        bool fileop = true;
        while (fileop)
        {
            if (!File.Exists(fileName))
            {
                break;
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = "default.json";
                string json = File.ReadAllText(fileName);

                // Convert from json to objects
                var data = JsonConvert.DeserializeObject<Data>(json);

                // Load into journal and prompts
                journal.Created = data.Created;
                journal.Entries = data.Entries;
                prompt.prompts = data.Prompts;

            }
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);

                // Convert from json to objects
                var data = JsonConvert.DeserializeObject<Data>(json);

                // Load into journal and prompts
                journal.Created = data.Created;
                journal.Entries = data.Entries;
                prompt.prompts = data.Prompts;
            }
            else
            {
                Console.WriteLine("Invalid file name.");
            }
        }
    }

    public void Save(Journal journal, Prompt prompt)
    {
        Console.Write("Enter the file name or leave blank to save to default.json: ");
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            fileName = "default.json";
        }

        // Create a data object with the jornal, entry, and prompt information
        var data = new Data
        {
            Created = journal.Created,
            Entries = journal.Entries,
            Prompts = prompt.prompts
        };

        // Convert from object to json
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        // Write the json to file
        File.WriteAllText(fileName, json);
    }


    private class Data
    {
        public DateTime Created;

        public List<Entry> Entries;
        public List<string> Prompts;
    }

}