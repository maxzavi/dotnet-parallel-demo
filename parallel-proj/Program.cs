using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch(); 
stopwatch.Start();
System.Console.WriteLine("Start");


int [] ids = {1,2,3,4,5,6,7,8,9,10,11,12};
MyProcess myProcess = new MyProcess(); 

string parallelFlag  = Environment.GetEnvironmentVariable("TEST_PARALLEL_FLAG") ?? "F";
string asyncFlag  = Environment.GetEnvironmentVariable("TEST_ASYNC_FLAG") ?? "F";
Console.WriteLine($"Parameters: TEST_PARALLEL_FLAG->{parallelFlag} TEST_ASYNC_FLAG->{asyncFlag}");
if (asyncFlag.Equals("T",StringComparison.CurrentCultureIgnoreCase)){
    if (parallelFlag.Equals("T",StringComparison.CurrentCultureIgnoreCase)){
        await Parallel.ForEachAsync(ids, async (item,CancellationToken)=>{
            string result = await myProcess.executeAsync(item);
            System.Console.WriteLine($"Result: {result} Elapsed {stopwatch.Elapsed}");   
        });
    }else{
        //Non parallel
        foreach (var item in ids)
        {
            var result = await myProcess.executeAsync(item);
            System.Console.WriteLine($"Result {result} elapsed {stopwatch.Elapsed}");
        }
    }
}else{
    if (parallelFlag.Equals("T",StringComparison.CurrentCultureIgnoreCase)){
        Parallel.ForEach(ids, item=>{
            var result = myProcess.execute(item);
            System.Console.WriteLine($"Result {result} elapsed {stopwatch.Elapsed}");
        });
    }else{
        //Non parallel
        foreach (var item in ids)
        {
            var result = myProcess.execute(item);
            System.Console.WriteLine($"Result {result} elapsed {stopwatch.Elapsed}");
        }
    }
}
System.Console.WriteLine($"End elapsed {stopwatch.Elapsed}");
