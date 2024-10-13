using System;
using System.Collections.Generic;
using System.Data;
using CSharpNotes.Data;
using CSharpNotes.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

/*
    dotnet new <project name>- To create new project
    dotnet add package <package name> - To add package to the project, added packages can be seen on .csproj
    dotnet run - To run the project
    dotnet restore - To refresh new packages
*/

//namespace should be projectname.<folder in which file is present>
namespace CSharpNotes
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {

        // PascalCase: Used for class names, method names, property names, and namespaces. PascalCase is similar to Camel Case, but the first letter of each word is capitalized. 
        // camelCase: Used for method parameters and local variables. 
        // Private instance fields: Start with an underscore ( _ ) and the remaining text is camelCased.

        /*    byte myByte = 255;
            byte mySecondByte = 0;
 

            sbyte mySbyte = 127;
            sbyte mySecondSbyte = -128;
 
            ushort myUshort = 65535;
 
            short myShort = -32768;
 
            // 4 byte (32 bit) 
            int myInt = 2147483647;
            int mySecondInt = -2147483648;
 
            // 8 byte (64 bit) 
            long myLong = -9223372036854775808;
 
 
            // 4 byte (32 bit) 
            float myFloat = 0.751f;
            float mySecondFloat = 0.75f;
 
            // 8 byte (64 bit) floating point number
            double myDouble = 0.751;
            double mySecondDouble = 0.75d;
 
            // 16 byte (128 bit) floating point number, Decimal is better for precise calculations
            decimal myDecimal = 0.751m;
            decimal mySecondDecimal = 0.75m;
 
            //character
            char ch = 'V';
 
            //string datatype
            string myString = "Hello World";
            string myStringWithSymbols = "!@#$@^$%%^&(&%^*__)+%^@##$!@%123589071340698ughedfaoig137";
  
            //boolean
            bool myBool = true;

            // ? can be used to define variable as nullable
            bool ?testBool = null;

        */

            //arrays
            int[] arr1 = new int[3];

            int[] arr2 = {1, 2};

            int[] arr3 = new int[3]{1,2,3};

            //Multi-Dimensional, seperated by comma
            int[,] arr2d = new int[3,3];
            
            int[,] arr2dv = new int[,]{
                {1, 2},
                {1, 3}
            };
            arr2dv[0,0] = 5; 

            //Lists

            // Unlike Java, Can also use datatypes as type in list along with classes
            // datatype should be mentioned before and after equals
            // can declare in same line using flower brackets
            List<int> l1 = new List<int>(){1,2};
            List<string> l2 = new List<string>();
            l2.Add("Venkata");
            //Unlike Java, can access the elements same way as arrays
            l2[0] = "C#";


            //Dictionaries are used for key-value pairs, like map in java
            Dictionary<string, int[]> keyValuePairs= new Dictionary<string, int[]>(){
                {"1", new int[]{1,2,3}},
                {"2" , new int[]{1,2}} 
            };
            keyValuePairs["2"][0] = 5;


            //IEnumaberable is faster when we want to loop through every element, like Iterator in Java, we can assign list/arrays to it, Not Indexable
            // First() method can be used to get the first record
            IEnumerable<int> ie = new List<int>(){2,3};

            //Console output
            // Console.Write(ch+" "); //no new line
            // Console.WriteLine(myString); //new line added at the end

            
            Computer myComputer = new Computer(){
                ModelName = "DELL",
                Storage = 512,
                Price = 549.99m,
                New = true,
                ReleaseDate = new DateTime(2022,8,22)
            };
            
            // Configuration file instance that can be shared accross classes
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            // Adding and Fetching records using Dapper Class
            //Instance of Database dapper class
            DataDapper dataDapper= new DataDapper(config);

            // @ is used at the beginning to write in multiple lines
            string insertSql = @"INSERT INTO ComputerSchema.Computers (ModelName, Storage, Price, New, ReleaseDate) VALUES
            ('" + myComputer.ModelName+ "','"
            + myComputer.Storage + "','"
            + myComputer.Price + "','"
            + myComputer.New + "','"
            + myComputer.ReleaseDate + "')";

            int result = dataDapper.ExecuteSql(insertSql);

            string selectSql = "SELECT * FROM ComputerSchema.Computers";

            IEnumerable<Computer> computers= dataDapper.QueryData<Computer>(selectSql);
            
            //foreach uses in 
            foreach(Computer computer in computers){
                Console.WriteLine(computer.ComputerId +" "+computer.ModelName +" "+computer.Storage+" "+computer.Price+" "+computer.New+" "+computer.ReleaseDate);
            }

            // Adding and Fetching Database Records using Entity Framework

            DataEntity computerEntity= new DataEntity(config);
            computerEntity.Add(myComputer);
            computerEntity.SaveChanges();

            Console.WriteLine("From Entity Framework");
            foreach(Computer computer in computerEntity.Computer.ToList()){
                Console.WriteLine(computer.ComputerId +" "+computer.ModelName +" "+computer.Storage+" "+computer.Price+" "+computer.New+" "+computer.ReleaseDate);
            }

            // Delete all the rows from table
            computerEntity.Computer.ExecuteDelete();

            Console.WriteLine("After Deletion All");
            foreach(Computer computer in computerEntity.Computer.ToList()){
                Console.WriteLine(computer.ComputerId +" "+computer.ModelName +" "+computer.Storage+" "+computer.Price+" "+computer.New+" "+computer.ReleaseDate);
            }

        }
    }
}