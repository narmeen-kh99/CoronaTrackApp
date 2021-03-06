﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTrackApp
{
    public class Runner
    {
        private List<Person> people;
        private List<LabTest> tests;
        private DateTime showSickTime;
       

        

        public Runner()
        {
            this.people = new List<Person>();
            this.tests = new List<LabTest>();
            this.showSickTime = DateTime.Now;

        }
       
    


        public int indexOf(List<Person> target ,long id)
        {
            for (int i=0; i< target.Count; i++)
            {

                if(target[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public List<LabTest> getLabTestsByPerson(long p_id)
        {
             return this.tests.Where(test => test.PersonId == p_id).OrderBy(test => test.Date).ToList();
        }
       

        public bool validateInputLength(string[] input,int size)
        {
            return input.Length == size;
        }

        public void printSickList()
        {
            foreach(Person person in this.people)
            {
                if (person.PStatus == Status.sick)
                {
                    Console.WriteLine(person);
                }
                
            }
        }

        public void printSperator()
        {
            Console.WriteLine("\n------------------------------------\n");
        }

        public void printCommandString(string command)
        {
            Console.WriteLine("--- "+command+" COMMAND CALLED ---");
        }

        /*
         * FILE / INPUT FUNCTIONS
         */


       

        public void addRouteSite(long id, string date, string time,string sitename)
        {
            int person_index = this.indexOf(this.people,id);
            if(person_index > -1)
            {
                Route _route = new Route(date, time, sitename);
                this.people[person_index].addRoute(_route);
                Console.WriteLine("New Route site successfully added ");
            }
            else
            {
                Console.WriteLine("Person with id:" + id + " doesnt Exist");
            }
        }


        public void addRouteAddress(long id, string date, string time, string sitename,string city,string street,int number)
        {
            int person_index = this.indexOf(this.people,id);
            if (person_index > -1)
            {
                Route _route = new Route(date, time, sitename,city,street,number);
                this.people[person_index].addRoute(_route);
                Console.WriteLine("New Route address successfully added ");
            }
            else
            {
                Console.WriteLine("Person with id:" + id + " not Exists");
            }
        }

        public void updateLabTest(int labid,int testid,long personid, string date,bool result)
        {
            //check if labid-testid exist
            LabTest test = new LabTest(labid, testid, personid, date, result);
            int index = -1;

            for (int i = 0; i < tests.Count; i++)
            {
                if (tests[i].LabId == labid && tests[i].TestId == testid)
                {
                    index = i;
                    break;
                }
            }

            if(index > -1)
            {
                this.tests[index].replaceParams(test);
            }
            else
            {
                this.tests.Add(test);
            }

            //Update Status
            /*
             * check if this test is the last test for this person
             * if yes then modify person status
             * if sick then => healed
             * if anything and this true then sick
             */
            List<LabTest> personTest = this.getLabTestsByPerson(test.PersonId);
            if (personTest[personTest.Count-1].TestId == test.TestId)
            {
                int p_index = this.indexOf(this.people, test.PersonId);
                if(p_index>-1)
                {
                    if (test.Result)
                    {
                        this.people[p_index].setStatus(1);

                    }
                    else
                    {
                        if(this.people[p_index].PStatus == Status.sick)
                        {
                            this.people[p_index].setStatus(2);
                        }
                    }
      
                }
            }

        }

        public void sickPerCity(int sicks)
        {
        
            var myList = this.people.Where(person => person.PStatus == Status.sick).ToList();
            var dictionary = myList.GroupBy(x=>x.getCity()).ToDictionary(x => x.Key, x => x.Count());
            foreach(var item in dictionary)
            {
                Console.WriteLine(item.Key + ": " + item.Value / sicks * 100 + " %");
            }
        }

        /*
         * END FILE / INPUT FUNCTIONS
         */






        public void generateChoice(string input)
        {
            string[] words = input.Split(' ');
            switch (words[0])
            {
                case "Create-sick":

                    Person PatientObj = new Person(long.Parse(words[1]), words[2], words[3], words[4], words[5], words[6], words[7], words[8], int.Parse(words[9]), int.Parse(words[10]), int.Parse(words[11]));
                    int index = this.indexOf(this.people, PatientObj.Id);
                    if (index > -1)
                    {
                        //If Person Exists we should replace it
                        this.people.Insert(index, PatientObj);
                        this.people.RemoveAt(index + 1);
                    }
                    else
                    {
                        this.people.Add(PatientObj);
                    }

                    break;


                case "Add-route-site":
                    this.printSperator();
                    this.printCommandString("ADD-ROUTE-SITE");

                    if (this.validateInputLength(words, 5))
                    {
                        this.addRouteSite(long.Parse(words[1]), words[2], words[3], words[4]);
                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }
                    break;

                case "Add-route-address":
                    this.printSperator();
                    this.printCommandString("ADD-ROUTE-ADDRESS");

                    if (this.validateInputLength(words, 8))
                    {
                        this.addRouteAddress(long.Parse(words[1]), words[2], words[3], words[4], words[5], words[6], int.Parse(words[7]));
                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }
                    break;
                case "Add-sick-encounter":
                    this.printSperator();
                    this.printCommandString("ADD-SICK-ENCOUNTER");
                    if (this.validateInputLength(words, 5))
                    {
                        Person newperson = new Person(long.Parse(words[1]), words[2], words[3], words[4]);
                        this.people.Add(newperson);

                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }
                    break;

                case "Show-sick-encounter":
                    this.printSperator();
                    this.printCommandString("SHOW-SICK-ENCOUNTER");
                    int i = 0;
                    foreach (Person person in this.people)
                    {
                        if (person.IsEncounter) {

                            int sickindex = this.indexOf(this.people, person.SickId);

                            if (sickindex > -1)
                            {
                                Console.WriteLine(i + ", " + this.people[sickindex].Id + ", " + this.people[sickindex].Firstname + ", " + this.people[sickindex].Lastname + ", " + person.printEncounterDetails());
                            }
                            else
                            {
                                Console.WriteLine(i + ", " + "SICK DETAILS NOT FOUND, " + person.printEncounterDetails());
                            }
                        }
                        i++;
                    }
                    break;

                case "Update-sick-encounter-details":
                    this.printSperator();
                    this.printCommandString("UPDATE-SICK-ENCOUNTER-DETAILS");
                    if (this.validateInputLength(words, 13))
                    {
                        Person item = this.people[int.Parse(words[1])];
                        item.updateInformation(long.Parse(words[2]), words[3], words[4], words[5], words[6], words[7], words[8], words[9], int.Parse(words[10]), int.Parse(words[11]), int.Parse(words[11]));
                        Console.WriteLine("Person information successfully updated");

                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }

                    break;
                case "Update-lab-test":
                    this.printSperator();
                    this.printCommandString("UPDATE-LAB-TEST");
                    if (this.validateInputLength(words, 6))
                    {
                        this.updateLabTest(int.Parse(words[1]), int.Parse(words[2]), long.Parse(words[3]), words[4], bool.Parse(words[5]));
                        Console.WriteLine("Lab test Successfuly updated");
                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }



                    break;
                case "Show-sick":
                    this.printSperator();
                    this.printCommandString("SHOW-SICK");
                    if (this.validateInputLength(words, 1))
                    {
                        this.printSickList();
                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }

                    break;
                case "Show-new-sick":
                    this.printSperator();
                    this.printCommandString("SHOW-NEW-SICK");
                    foreach (Person person in this.people)
                    {
                        if (person.PStatus == Status.sick && person.AddedAt.CompareTo(this.showSickTime) > 0)
                        {
                            Console.WriteLine(person);
                        }
                    }
                    this.showSickTime = DateTime.Now;
                    break;
                case "Show-person":
                    this.printSperator();
                    this.printCommandString("SHOW-PERSON");
                    if (this.validateInputLength(words, 2))
                    {
                        long _id = long.Parse(words[1]);
                        int userIndex = this.indexOf(this.people, _id);
                        if (userIndex > -1 && !this.people[userIndex].IsEncounter)
                        {

                            Console.WriteLine(this.people[userIndex]);
                            Console.WriteLine("** LAB RESULT BEGIN **");
                            List<LabTest> userTests = this.getLabTestsByPerson(_id);
                            if (userTests.Count == 0)
                            {
                                Console.WriteLine("NO LAB TEST FOUND FOR THIS PERSON");
                            }
                            else
                            {
                                foreach (LabTest test in userTests)
                                {
                                    Console.WriteLine(test);
                                }
                            }
                            Console.WriteLine("** LAB RESULT END **");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }
                    break;
                case "Show-person-route":
                    this.printSperator();
                    this.printCommandString("SHOW_ISOLATED");
                    if (this.validateInputLength(words, 2))
                    {
                        long id = long.Parse(words[1]);
                        int p_index = this.indexOf(this.people, id);
                        if (p_index < 0)
                        {
                            Console.WriteLine("PERSON NOT FOUND");
                            break;
                        }
                        List<Route> orderedRoutes = this.people[p_index].PRoutes.OrderBy(r => r.RDateTime).ToList();
                        foreach (Route route in orderedRoutes)
                        {
                            Console.WriteLine(route);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }
                    break;
                case "Show-isolated":
                    this.printSperator();
                    this.printCommandString("SHOW_ISOLATED");
                    if (this.validateInputLength(words, 1))
                    {
                        foreach (Person person in this.people)
                        {
                            if (person.PStatus == Status.isolated && !person.IsEncounter)
                            {
                                Console.WriteLine(person.printIsolated());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The input you pass not Valid!");
                    }
                    break;
                case "Show-stat":
                    this.printSperator();
                    this.printCommandString("SHOW_STAT");
                    string[] cleanInput = (string.Join("", words.Skip(1).ToArray())).Split(',');
                    if (cleanInput.Length > 0)
                    {
                        int sick = this.people.Where(person => person.PStatus == Status.sick).ToList().Count;
                        int isolated = this.people.Where(person => person.PStatus == Status.isolated).ToList().Count;
                        int healed = this.people.Where(person => person.PStatus == Status.healed).ToList().Count;
                        foreach (var word in cleanInput)
                        {
                            switch (word)
                            {
                                case "sicks":
                                    Console.WriteLine("** BEGIN SICK **");
                                    Console.WriteLine(sick);
                                    Console.WriteLine("** END SICK **");
                                    break;
                                case "healed":
                                    Console.WriteLine("** BEGIN HEALED **");
                                    Console.WriteLine(healed);
                                    Console.WriteLine("** END HEALED **");
                                    break;
                                case "isolated":
                                    Console.WriteLine("** BEGIN ISOLATED **");
                                    Console.WriteLine(isolated);
                                    Console.WriteLine("** END ISOLATED **");
                                    break;
                                case "sick-per-city":
                                    Console.WriteLine("** BEGIN SICK-PER-CITY **");
                                    if(sick > 0)
                                    {
                                        this.sickPerCity(sick);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no sicks");
                                    }
                                    Console.WriteLine("** END SICK-PER-CITY **");
                                    break;
                            }
                        }
                    }
                    else
                    {
                       Console.WriteLine("The input you pass not Valid!");
                    }
      
                    break;
                case "Show-help":
                    this.printSperator();
                    this.printCommandString("SHOW_HELP");
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
                    
                    break;

                default:
                    Console.WriteLine("COMMAND NOT FOUND!");
                    break;
            }
        }

  
    }
}
