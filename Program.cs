using System;
using System.Media;
using System.Threading;
using System.IO;
using NAudio.Wave;
using System.Collections.Generic; //Needed for List and Dictionary usage

class CyberSecurityBot
{
    //Storing user information and interests for future conversation
    static string userName = "";
    static string userInterest = "";

    //Coding for keywords to be recognised and appropriate responses to be given
    static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
    {
        
        { "password", new List<string> {
            "Use strong, unique passwords for every account.",
            "Avoid using personal info like birthdays in your passwords.",
            "Consider using a password manager for safer storage." }
        },
        { "scam", new List<string> {
            "Always double-check URLs and email senders before clicking links.",
            "Scammers often impersonate trusted organizations—be cautious.",
            "Don't share OTPs or personal info over the phone or email." }
        },
        { "privacy", new List<string> {
            "Adjust your social media privacy settings regularly.",
            "Limit how much personal data you share online.",
            "Use encrypted messaging apps for better privacy." }
        },
        { "phishing", new List<string> {
            "Look for typos or strange links in emails.",
            "Don't download attachments from unknown senders.",
            "Banks will never ask for passwords via email." }
        }
    };

    static void Main()
    {
       // Console.OutputEncoding = System.Text.Encoding.UTF8; PlayGreeting(); ShowAsciiArt();

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
                //Goodbye greeting 
                Console.WriteLine($"\n[CyberSecurity Bot] Stay safe on the web {userName}, see you soon.");
                break;
            }

            //Coding for sentiment detection from user input
            if (input.Contains("worried") || input.Contains("nervous") || input.Contains("scared"))
            {
                Console.WriteLine("\n[CyberSecurity Bot] It's okay to feel that way. Cyber threats can be scary, but I'm here to help you stay safe.");
            }
            else if (input.Contains("curious") || input.Contains("interested"))
            {
                Console.WriteLine("\n[CyberSecurity Bot] Curiosity is the first step to better cybersecurity. Ask away!");
            }
            else if (input.Contains("frustrated") || input.Contains("confused"))
            {
                Console.WriteLine("\n[CyberSecurity Bot] Don't worry! Cybersecurity can be complex, but I'll explain everything clearly.");
            }

            
            if (input.Contains("I'm interested in"))
            {
                int index = input.IndexOf("I'm interested in") + "I'm interested in".Length;
                userInterest = input.Substring(index).Trim();
                Console.WriteLine($"\n[CyberSecurity Bot] Good. I'll remember that you're interested in {userInterest}.");
                continue;
            }
            else if (!string.IsNullOrEmpty(userInterest) && input.Contains("remind me"))
            {
                Console.WriteLine($"\n[CyberSecurity Bot] Earlier you said you're interested in {userInterest}. Here's a tip: {GetRandomResponse(userInterest)}");
                continue;
            }

            
            ProvideCyberSecurityInfo(input);
        }

        
    }

    /*static void PlayGreeting()
    {
       // string Audiopath = @"C:\Users\RC_Student_lab\source\repos\poePART1\greeting.wav";

        //if (File.Exists(Audiopath))
        {
            using (var audioFile = new AudioFileReader(Audiopath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
        //else
        {
            Console.WriteLine("Warning: Sound file not found, I won't play greeting sound...");
        }
    }*/

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

        //Cycling through each keyword to find a match
        bool found = false;
        foreach (var keyword in keywordResponses.Keys)
        {
            if (question.Contains(keyword))
            {
                Console.WriteLine(GetRandomResponse(keyword));
                found = true;
                break;
            }
        }

        if (!found)
        {
            //Fallback created in the case of unknown input
            Console.WriteLine("I'm not understanding. Please rephrase or ask a cybersecurity-related question");
        }

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

    //Random selecter for topic tips
    static string GetRandomResponse(string keyword)
    {
        if (keywordResponses.ContainsKey(keyword))
        {
            List<string> responses = keywordResponses[keyword];
            Random rand = new Random();
            return responses[rand.Next(responses.Count)];
        }
        else
        {
            return "Sorry I don’t have tips on that topic.";
        }
    }




}
