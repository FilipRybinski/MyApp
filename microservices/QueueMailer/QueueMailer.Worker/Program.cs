using QueueMailer.Worker.Manager;

Console.WriteLine("QueueMailer is working...");
await QueueManager.InitializeAsync();
Console.ReadLine();