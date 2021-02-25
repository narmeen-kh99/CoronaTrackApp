using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTrackApp
{
    class Runner
    {
        private List<Person> people;
        private List<Person> encounters;

        public Runner()
        {
            this.people = new List<Person>();

        }
       
    


        public int indexOf(long id)
        {
            for (int i=0; i<people.Count; i++)
            {

                if(people[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void printSickList()
        {
            foreach(Person person in this.people)
            {
                if (person.WhoAmI() == "Patient")
                {
                    Console.WriteLine(person);
                }
                
            }
        }

        public void generateChoice(string input)
        {
            string[] words = input.Split(' ');
            switch (words[0])
            {
                case "Create-sick":
                  
                    Person PatientObj = new Patient(long.Parse(words[1]), words[2], words[3], words[4], words[5], words[6], words[7], words[8], int.Parse(words[9]), int.Parse(words[10]), int.Parse(words[11]));
                    int index = this.indexOf(PatientObj.Id);
                    if (index > -1)
                    {
                        //If Person Exists we should delete it
                        this.people.RemoveAt(index);
                    }
                    this.people.Add(PatientObj);
                    break;

                case "Show-help":
                    Console.WriteLine("**Show Help Command Start**");
                    Console.WriteLine("Create-sick id firstanme lastname birthdate phone mail city street house-number apartment house-residents");
                    Console.WriteLine("Add-route-site id 01/04/2020 10:00 sitename");
                    Console.WriteLine("Add-route-address id 01/04/2020 10:30 sitename  city street number");
                    Console.WriteLine("Add-sick-encounter sick-id firstname lastname phone");
                    Console.WriteLine("Show-sick-encounter");
                    Console.WriteLine("Update-lab-test labid testid personid date result");
                    Console.WriteLine("Show-new-sicks");
                    Console.WriteLine("Show-stat");
                    Console.WriteLine("Show-person personid");
                    Console.WriteLine("Show-person-route personid");
                    Console.WriteLine("Show-sick");
                    Console.WriteLine("Show-isolated");
                    Console.WriteLine("**Show Help Command End**");
                    break;
                case "Show-sick":
                    this.printSickList();
                    break;
                case "Show-person":
                    long _id = long.Parse(words[1]);
                    int userIndex = this.indexOf(_id);
                    if (userIndex > -1)
                    {
                        Console.WriteLine(this.people[userIndex]);
                        Console.WriteLine("** LAB RESULT BEGIN **");

                        Console.WriteLine("** LAB RESULT END **");
                    }
                    break;
                     
                default:
                    break;
            }
        }

  
    }
}
