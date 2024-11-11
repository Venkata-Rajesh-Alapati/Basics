using CSharpNotes.Data;
using CSharpNotes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// various ways to access database
public class DataAcess{
    private IConfiguration config;

    public DataAcess(IConfiguration config)
    {
        this.config = config;
    }

    public void Method2(){
                    
            // myComputer object
            Computer myComputer = new Computer(){
                ModelName = "DELL",
                Storage = 512,
                Price = 549.99m,
                New = true,
                ReleaseDate = new DateTime(2022,8,22)
            };

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

            ComputerEntity computerEntity= new ComputerEntity(config);
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