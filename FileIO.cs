using System.Text.Json;
using CSharpNotes.Data;
using CSharpNotes.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class FileIO{
    private IConfiguration config;

    public FileIO(IConfiguration config)
    {
        this.config = config;
    }

    public void Method3(){
        
        // To Write to a file
        File.WriteAllText("log.txt", "Text 1\n");

        // Appending to File, using can be used to release the resources even if there is an exception
        using StreamWriter streamWriter = new StreamWriter("log.txt", true);
        streamWriter.WriteLine("Text 2\n");
        streamWriter.Close(); // To close the stream

        //Reading from a file
        String fileData = File.ReadAllText("log.txt");


        // Serialization and Deserialization 
        /*
            Can be done in two ways
            1. Using Newtonsoft.Json.Serialization package and setting camelCase naming policy using JsonSerializerOptions
            2. Using built-in System.Text.Json

        */


        // Deserialization and Serialization using System.Text.Json

        // Setting Input and Ouput Field Format as camelCase
        JsonSerializerOptions options = new JsonSerializerOptions(){
           PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        IEnumerable<Computer>? computers = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(File.ReadAllText("Computers.json"), options);
        
        // Instance of Computer Entity
        ComputerEntity computerEntity= new ComputerEntity(config);
        if(computers != null){
            foreach(Computer computer in computers) {
                // Inserting to Database
                computerEntity.Add(computer);
            }
            computerEntity.SaveChanges();
        }

        // Serializing, using options
        string serializedSystem = System.Text.Json.JsonSerializer.Serialize(computers, options);

        // Deserialization and Serialization Using Newtonsoft.Json, Input JSON Conversion option is not needed, default is camelCase
        IEnumerable<Computer>? computersNSJ = JsonConvert.DeserializeObject<IEnumerable<Computer>>(File.ReadAllText("Computers.json"));
        if(computersNSJ != null){
            foreach(Computer computer in computersNSJ) {
                // Perform Operations
            }
        }

        // Serialization
        // settings is required to set output filed names as camelCase
        JsonSerializerSettings jsonSerializerSettings= new JsonSerializerSettings(){
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        string serializedNSJ = JsonConvert.SerializeObject(computersNSJ, jsonSerializerSettings);

        /* AutoMapper can be used to map field with different names or map the modified values to the fields,
            Using JSONPropertyName in Model class is the easiest way to map the field with different names
        */
    }
}