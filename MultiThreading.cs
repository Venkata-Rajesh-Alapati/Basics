
/* Multithreading can be achieved in two ways
    1. Tasks (Represents a Asnchronous operation)
    2. Async Methods (Only when method is Async it waits for other operations to complete)[ calling async method internally creates a Task]

    async methods are preferred over Task, beacause task takes function as a argument.
*/

public class MultiThreading{
    // If Method4 is not async, firstTask may not run at all because Method4 may complete its execution
    public async Task Method4(){// async methods must have return type Task
        // Tasks
        Task firstTask = new Task(() => {
            Task.Delay(100);
            Console.WriteLine("Task 1");
        });
        firstTask.Start(); // Tasks should be started explicitly, async method will start automatically when we call it.
    
        await firstTask; //async method without await behaves synchronously, now program doesn't terminate without completing firstTask
        Console.WriteLine("After Task 1");
    }
    public async Task Method5(){
        Task secondTask = new Task(() => {
            Task.Delay(50);// this function is asynchronous
            Console.WriteLine("Task 2");
        });
        secondTask.Start();
        await secondTask;
        Console.WriteLine("After Task 2");
    }

    public async Task Method6()
    {
        // Wait for both tasks to complete
        await Task.WhenAll(Method4(), Method5());
        Method7(); // after Method4, Method5 completion this synchronous method is called, any asynchronous after this will wait until this is completed
        await Method4();
    }

    public void Method7(){
        Thread.Sleep(1); //synchronous sleep method
        Console.WriteLine("Synchronous");
    }
}