using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Status{
    isolated,
    sick,
    healed,

}

namespace CoronaTrackApp
{
    class Person
    {
        protected long id;
        protected string firstname;
        protected string lastname;
        protected string birthdate;
        protected string phone;
        protected string mail;
        protected Address address;
        protected int apartment;
        protected int house_residents;
        protected long sick_id;
        protected List<Route> route;
        protected Status status;
        protected bool isEncounter = false;


        //Class 


        public Person() { }


        public Person(long id, string firstname, string lastname, string birthdate, string phone, string mail, string city, string street, int house_number, int apartment, int house_residents)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthdate = birthdate;
            this.phone = phone;
            this.mail = mail;
            this.address = new Address(city, street, house_number);
            this.apartment = apartment;
            this.house_residents = house_residents;
            this.sick_id = 0;
            this.route = new List<Route>();
            this.status = Status.sick;
        }

        public Person(long sickid, string firstname, string lastname, string phone)
        {
            this.sick_id = sickid;
            this.firstname = firstname;
            this.lastname = lastname;
            this.phone = phone;
            this.isEncounter = true;
            this.status = Status.isolated;

        }


        public long Id
        {
            get { return id; }
        }
        public long SickId
        {
            get { return sick_id; }
        }
        public string Firstname
        {
            get { return firstname; }
        }
        public string Lastname
        {
            get { return lastname; }
        }
        public bool IsEncounter
        {
            get { return isEncounter; }
        }
        public Status PStatus
        {
            get { return status; }
         
        }
        public void setStatus(int status)
        {
            if (status == 0)
            {
                this.status = Status.isolated;
            }else if(status == 1)
            {
                this.status = Status.sick;
            }else if (status == 2)
            {
                this.status = Status.healed;
            }
        }




        public void updateInformation(long id, string firstname, string lastname, string birthdate, string phone, string mail, string city, string street, int house_number, int apartment, int house_residents)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthdate = birthdate;
            this.phone = phone;
            this.mail = mail;
            this.address = new Address(city, street, house_number);
            this.apartment = apartment;
            this.house_residents = house_residents;
            this.isEncounter = false;
            this.route = new List<Route>();

        }
        public string printEncounterDetails()
        {
            return this.firstname + " " + this.lastname + " " + this.phone;
        }


        public void addRoute(Route route)
        {
            this.route.Add(route);
        }



        public override string ToString()
        {
            return this.Id + ", " + this.firstname + ", " + this.lastname + ", " +this.birthdate+", "+this.phone+", "+this.mail+", "+this.address+", "+this.apartment+", "+this.house_residents+", "+this.sick_id;
        }


 
    }
}
