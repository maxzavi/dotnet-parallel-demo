public class MyProcess
{
    public string execute (int id){
        DateTime dt = DateTime.Now;
        Thread.Sleep(1500);
        return $"Finished id {id:000}, started: {dt:MM/dd/yy H:mm:ss.fff}";
    }
    public async Task<string> executeAsync (int id){
        DateTime dt = DateTime.Now;
        await Task.Delay(1500);
        return $"Finished async id {id:000}, started: {dt:MM/dd/yy H:mm:ss.fff}";
    }
}