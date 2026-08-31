using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
class Program
{ 
    
    static void Main()
    {
        var smser = new List<IMessegeSender>();

        ConsoleMessageSender a1 = new ConsoleMessageSender();
        FileMessageSender a2 = new FileMessageSender();
        FakeSmsMessageSender a3 = new FakeSmsMessageSender();
        smser.Add(a1);
        smser.Add(a2);
        smser.Add(a3);
        NotificationService Notiall = new NotificationService(a1 , a2 , a3);
        Notiall.AllGetMessage(smser, "Hello everyone!");
  
    }
    
}
public interface IMessegeSender
{
    void SendMessege(string Message);
}
public class NotificationService
{
    
    private ConsoleMessageSender Sender1;
    private FileMessageSender Sender2;
    private FakeSmsMessageSender Sender3;
    public NotificationService(ConsoleMessageSender sender1, FileMessageSender sender2, FakeSmsMessageSender sender3)
    {
        Sender1 = sender1;
        Sender2 = sender2;
        Sender3 = sender3;
    }
    
    public void AllGetMessage(List <IMessegeSender> senderList, string Message)
    {
        foreach (IMessegeSender sender in senderList)
        {
            sender.SendMessege(Message);
        }
    }

}
public class ConsoleMessageSender : IMessegeSender
{
    public void SendMessege(string Messsage)
    {

        Console.WriteLine($"Send :{Messsage}");
    }
}
public class FileMessageSender : IMessegeSender
{
 
    public void SendMessege(string Message)
    {
        File.WriteAllText("stm.txt", Message);

       // Console.WriteLine($"[.txt]{Message}");
    }
}

public class FakeSmsMessageSender : IMessegeSender
{
    public void SendMessege(string Message)
    {
        Console.WriteLine($"from Sms - {Message} ");
    }
}

