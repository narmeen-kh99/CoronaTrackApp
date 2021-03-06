﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Status
{
    isolated,
    sick,
    healed,

}

namespace CoronaTrackApp
{

    public class Person
    {
        private long id;
        private string firstname;
        private string lastname;
        private string birthdate;
        private string phone;
        private string mail;
        private Address address;
        private int apartment;
        private int house_residents;
        private long sick_id;
        private List<Route> route;
        private Status status;
        private bool isEncounter = false;
        private DateTime addedAt;



        //Empty Constructor
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
            this.addedAt = DateTime.Now;
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
        public DateTime AddedAt
        {
            get { return addedAt; }

        }

        public void setStatus(int status)
        {
            if (status == 0)
            {
                this.status = Status.isolated;
            }else if(status == 1)
            {
                this.status = Status.sick;
                this.addedAt = DateTime.Now;
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

        public List<Route> PRoutes
        {
            get { return route; }
        }
        public string getCity()
        {
            return this.address.City;
        }


        public string printEncounterDetails()
        {
            return this.firstname + " " + this.lastname + " " + this.phone;
        }

        public string printIsolated()
        {
            return this.Id + ", " + this.firstname + ", " + this.lastname + ", " + this.birthdate + ", " + this.phone + ", " + this.mail + ", " + this.address + ", " + this.apartment + ", " + this.house_residents;

        }
        public void addRoute(Route route)
        {
            this.route.Add(route);
        }


        public override string ToString()
        {
            return this.Id + ", " + this.firstname + ", " + this.lastname + ", " +this.birthdate+", "+this.phone+", "+this.mail+", "+this.address+", "+this.apartment+", "+this.house_residents+", "+this.sick_id;
        }

        public override bool Equals(object obj)
        {
            var test = obj as Person;
            return test != null &&
                   id == test.id &&
                   firstname == test.firstname &&
                   lastname == test.lastname &&
                   birthdate == test.birthdate &&
                   phone == test.phone &&
                   mail == test.mail &&
                   address.City == test.address.City &&
                   address.Street == test.address.Street &&
                   address.Number == test.address.Number &&
                   house_residents == test.house_residents &&
                   apartment == test.apartment;
        }

    }
}
