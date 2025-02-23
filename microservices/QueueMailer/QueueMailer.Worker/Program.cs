using QueueMailer.Worker.Manager;

try
{
    Console.WriteLine("QueueMailer is working...");
    await QueueManager.InitializeAsync();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

while (true) await Task.Delay(1000);
