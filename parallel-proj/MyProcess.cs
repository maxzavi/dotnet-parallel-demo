public class MyProcess
{
    int sleeptimeMiliseconds;
    public MyProcess(int sleeptimeMiliseconds){
        this.sleeptimeMiliseconds=sleeptimeMiliseconds;
    }
    public string execute (int id){
        DateTime dt = DateTime.Now;
        Thread.Sleep(this.sleeptimeMiliseconds);
        return $"Finished id {id:000}, started: {dt:MM/dd/yy H:mm:ss.fff}";
    }
    public async Task<string> executeAsync (int id){
        DateTime dt = DateTime.Now;
        await Task.Delay(this.sleeptimeMiliseconds);
        return $"Finished async id {id:000}, started: {dt:MM/dd/yy H:mm:ss.fff}";
    }
}