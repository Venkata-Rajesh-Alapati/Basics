// From .NET 5.0, top-level(writing C# statements directly without the need of class and main method) statements are allowed, all the statements are treated as within the Main method.

/*
    dotnet new <project name>- To create new project
    dotnet add package <package name> - To add package to the project, added packages can be seen on .csproj
    dotnet run - To run the project
    dotnet restore - To refresh new packages
    dotnet clean - To clean the project
    dotnet build - To build the project
*/

/*  PascalCase: Used for class names, method names, property names, and namespaces. PascalCase is similar to Camel Case, but the first letter of each word is capitalized. 
    camelCase: Used for method parameters and local variables. 
    Private instance fields: Start with an underscore ( _ ) and the remaining text is camelCased. 
    */

//namespace should be projectname.<folder in which file is present>

using Microsoft.Extensions.Configuration;

namespace CSharpNotes
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {

            // Configuration file instance that can be shared accross classes
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            // Types types = new Types();
            // types.Method1();

            // DataAcess dataAcess= new DataAcess(config);
            // dataAcess.Method2();

            // FileIO fileIO= new FileIO(config);
            // fileIO.Method3();

            MultiThreading multiThreading= new MultiThreading();
            multiThreading.Method6().Wait();
        }
    }
}