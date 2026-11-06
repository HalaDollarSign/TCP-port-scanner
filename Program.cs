using System;
using System.Net.Sockets;

Console.WriteLine("=== PROSTY SKANER PORTÓW TCP ===");

Console.Write("Podaj adres IP lub domenę docelową: ");
string host = Console.ReadLine();

int startPort = 1;
int endPort = 1024;

Console.WriteLine($"\nSkanowanie hosta {host} w zakresie portów {startPort}-{endPort}...\n");

for (int port = startPort; port <= endPort; port++)
{
    Console.Write($"\rSkanuję port: {port}   ");

    try
    {
        using (TcpClient client = new TcpClient())
        {
            var result = client.BeginConnect(host, port, null, null);
            var success = result.AsyncWaitHandle.WaitOne(100);

            if (success && client.Connected)
            {
                Console.Write("\r\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[+] Port {port} jest OTWARTY");
                Console.ResetColor();
            }
        }
    }
    catch
    {
      
    }
}

Console.WriteLine("\n\nSkanowanie zakończone!");
Console.WriteLine("Naciśnij dowolny klawisz, aby wyjść...");
Console.ReadKey();