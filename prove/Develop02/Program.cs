using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();// 
        journal.Run();
    }

    class Journal
    {



        private string JournalFileName = ReadLine();
        

        public void Run()// Display Write load Save Exit
        {
            Display_Intro();
            waitforkey();
            ReturnMenu();
            DisplayOutro();
            
        }

        private string getChoice()// gets choice
        {
            bool isChoiceValid = false;

            string Choice = "";
            
            do
            {

            
            Clear();
            Console.Write(
            "\nPlease select one of the following choices:  "+
            "\n1.   **Write"+
            "\n2.   **Display"+
            "\n3.   **Load"+
            "\n4    **Save"+
            "\n5.   **Quit\n");
            Choice = ReadLine();
            if (Choice == "1" || Choice == "2" || Choice == "3" || Choice == "4" || Choice == "5")
            {
                isChoiceValid = true;
            }
            else
            {
                WriteLine($"\"{Choice} \"is not a valid option!");
                waitforkey();
            }
        } while(!isChoiceValid);
        
            return Choice;
        }

        private void save()
        {
            WriteLine("Your progress has been saved.");
        }



        private void ReturnMenu()//loops back for reentry
        {
            WriteLine("You picked:  "+ getChoice());
            waitforkey();
            string Choice;
            do{
            Choice = getChoice();
            switch(Choice)
            {
                case "1":
                AddEntry();
                break;
                case "2":
                DisplayJournalContents();
                waitforkey();
                break;
                case "3":
                Create_Journal_File();
                Load();
                Clear();
                waitforkey();
                break;
                case "4":
                save();
                waitforkey();
                break;
                case "5":
                default:
                break;
            }
            }while(Choice != "5");
        }



        //Internal Methods Hide these pull to main to start
        private void Create_Journal_File() 
        {//DEPENDS ON DIRECTORY
        
        WriteLine("Whats the file name?");
                JournalFileName = ReadLine();//Restablishes the file we are using
            WriteLine($"Does File Exist:{File.Exists(JournalFileName)}");
            if(!File.Exists(JournalFileName))
            {
                File.CreateText(JournalFileName);
            }

        }
        private void Load()
        {
            WriteLine("We've stored the file.\n Restart program to avoid crashing if creating a new text file");
        }
        private void Display_Intro() 
        {
          WriteLine("Welcome to the Journal Program!");
        }

        private void DisplayOutro() 
        {
            WriteLine("GOODBYE!");
            ReadKey(true);
        }

        private void waitforkey()
        {
            WriteLine("Press Any key");
            ReadKey(true);
        }

        private void DisplayJournalContents() 
        {

            string journaltext = File.ReadAllText(JournalFileName);
            WriteLine($"Journal:     ");
            WriteLine(journaltext);
        }


        private void ClearFile() 
        {
            File.WriteAllText(JournalFileName , "");//Wipes
            WriteLine("File Wiped");
            waitforkey();
        }
        
        
        public void AddEntry()
        {
            var random = new Random();
            var list = new List<string>{ "Places you've enjoyed visiting.","Dear Past Me . . .","Dear Future Me . . .","What scares you?","Places you've enjoyed visiting.","Your favorite Books"};
            int index = random.Next(list.Count);
            string randomPrompt = list[index];
            
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
        
            WriteLine("\n***********************Generating Prompt*********************");
            WriteLine(randomPrompt);
            WriteLine("TYPE EXIT TO STOP");
            string newText = "";
            bool isContinue = true;
            while(isContinue)
            {
                string Text = ReadLine();
                if (Text.ToUpper() == "EXIT")
                {
                    isContinue = false;
                }
                else
                {
                    newText += Text+ "\n";
                }
            }
            File.WriteAllText(JournalFileName, "");
            File.AppendAllText(JournalFileName, $"\nEntry:  :     {randomPrompt} :{dateText}\n {newText}\n");
            WriteLine("**************ADDED TEXT******************");
            waitforkey();

        }

    }
}
