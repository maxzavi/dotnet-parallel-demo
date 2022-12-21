using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch(); 
stopwatch.Start();

int [] ids = {1,2,3,4,5,6,7,8,9,10,11,12};
string parallelFlag  = Environment.GetEnvironmentVariable("TEST_PARALLEL_FLAG") ?? "F";
string asyncFlag  = Environment.GetEnvironmentVariable("TEST_ASYNC_FLAG") ?? "F";
int sleepTimeMs  = int.Parse(Environment.GetEnvironmentVariable("SLEEP_TIME_MILISECONDS") ?? "1500");
Console.WriteLine($"Start: Parameters: TEST_PARALLEL_FLAG->{parallelFlag} TEST_ASYNC_FLAG->{asyncFlag} SLEEP_TIME_MILISECONDS -> {sleepTimeMs}");

int counter=0;

MyProcess myProcess = new MyProcess(sleepTimeMs); 

if (asyncFlag.Equals("T",StringComparison.CurrentCultureIgnoreCase)){
    if (parallelFlag.Equals("T",StringComparison.CurrentCultureIgnoreCase)){
        await Parallel.ForEachAsync(ids, async (item,CancellationToken)=>{
            int x = Interlocked.Increment(ref counter);
            string result = await myProcess.executeAsync(item);
            System.Console.WriteLine($"{x:000}/{ids.Length:000} Result: {result} Elapsed {stopwatch.Elapsed}");   
        });
    }else{
        //Non parallel
        foreach (var item in ids)
        {
            counter++;
            var result = await myProcess.executeAsync(item);
            System.Console.WriteLine($"{counter:000}/{ids.Length:000} Result {result} elapsed {stopwatch.Elapsed}");
        }
    }
}else{
    if (parallelFlag.Equals("T",StringComparison.CurrentCultureIgnoreCase)){
        Parallel.ForEach(ids, item=>{
            int x = Interlocked.Increment(ref counter);
            var result = myProcess.execute(item);
            System.Console.WriteLine($"{x:000}/{ids.Length:000} Result {result} elapsed {stopwatch.Elapsed}");
        });
    }else{
        //Non parallel
        foreach (var item in ids)
        {
            counter++;
            var result = myProcess.execute(item);
            System.Console.WriteLine($"{counter:000}/{ids.Length:000} Result {result} elapsed {stopwatch.Elapsed}");
        }
    }
}
System.Console.WriteLine($"End elapsed {stopwatch.Elapsed}");
