using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoronaTrackApp
{
    class Program
    {
        static void mainMenu()
        {
            Console.WriteLine("Main Menu?\n1.file\n2.std input\n3.exit\n[f|i|exit]?");
        }




        static void Main(string[] args)
        {
            Runner RunnerObj = new Runner();
            bool run = true;
            string choice = "";
        
            Console.WriteLine("Welcome to Corona-Track-App");

            //while (run)
            //{
            
                while (string.IsNullOrEmpty(choice))
                {
                    mainMenu();
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "f":
                            //Read From File
                            choice = "file";
                            break;
                        case "i":
                            choice = "input";
                            break;
                        case "exit":
                            System.Environment.Exit(1);
                            break;
                        default:
                            break;
                    }
                }

                if(choice == "input")
                {
                    Console.WriteLine("Write a Command..\nnote:first letter should be in Capital case");
                    Console.WriteLine("Write menu to go to main menu!");
                    while (choice=="input") {
                        string line = Console.ReadLine();
                        if (line != "menu") {
                            RunnerObj.generateChoice(line);
                        }
                        else
                        {
                            choice = "";
                        }
                    }
                }
                else if(choice=="file"){
                    Console.WriteLine("******************");
                    Console.WriteLine("Reading commands from File");
                    foreach (string line in File.ReadLines("HelpTest.txt", Encoding.UTF8))
                    {
                        RunnerObj.generateChoice(line);
                     
                    }
                    Console.WriteLine("******************");
                    Console.WriteLine("file Successfully readed\n");
                    choice = "";
                }




            //}

           
  
            Console.ReadKey();
        }
    }
}
