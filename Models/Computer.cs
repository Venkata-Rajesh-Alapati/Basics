namespace CSharpNotes.Models;

public class Computer{

    public int ComputerId {get; set;}
    public string ModelName { get; set;} = "";

    public int ?Storage {get; set;}

    public decimal ?Price { get; set;}

    public bool ?New { get; set;}

    public DateTime ?ReleaseDate { get; set;}

}

