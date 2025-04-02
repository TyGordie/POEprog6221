using System;
using System.Media;
using System.Threading;
using System.IO;

class CyberSecurityBot
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; PlayGreeting(); ShowAsciiArt();

        string userName;
        do
        {
            Console.Write("Enter your name: ");
            userName = Console.ReadLine().Trim();
        } while (string.IsNullOrEmpty(userName));

        Console.WriteLine($"\n[CyberSecurity Bot] Hello {userName}, ask me cybersecurity-related questions. Type 'exit' to quit.");

        while (true)
        {
            Console.Write("\nYou: ");
            string input = Console.ReadLine().ToLower().Trim();

            if (input == "exit")
            {
                Console.WriteLine($"\n[CyberSecurity Bot] Stay safe on the web {userName}, see you soon.");
                break;
            }

            ProvideCyberSecurityInfo(input);
        }
    }

    static void PlayGreeting()
    {
        string filePath = @"C:\Users\RC_Student_lab\source\repos\POEp1\greeting.wav";

        if (File.Exists(filePath))
        {
            try
            {
                //SoundPlayer player = new SoundPlayer(filePath);
                //player.PlaySync();
                Console.WriteLine("[CyberSecurity Bot] (Playing greeting audio...)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[CyberSecurity Bot] Audio error: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("[CyberSecurity Bot] Error: Greeting file not found.");
        }
    }

    static void ShowAsciiArt()
    {
        Console.WriteLine(@" 
  

.----------------. | CYBER BOT | '----------------' .--------. | [o] [o] | 

 | ------ | 

 | ______/ | '--------' ");
    }

    static void ProvideCyberSecurityInfo(string question)
    {
        Console.Write("[CyberSecurity Bot] ");
        Thread.Sleep(500);

        switch (question)
        {
            case "password safety":
                Console.WriteLine("Use strong, uniquely created passwords and always enable two-factor authentication.");
                break;
            case "phishing":
                Console.WriteLine("Avoid clicking on any suspicious links, whether it be from an entity that should be trusted or not and verify email senders.");
                break;
            case "public wifi":
                Console.WriteLine("Avoid using public Wi-Fi for sensitive or private activity.");
                break;
            case "software updates":
                Console.WriteLine("Always update your software to resolve security vulnerabilities.");
                break;
            default:
                Console.WriteLine("I'll only answer your cybersecurity-related questions.");
                break;
        }
    }


}
