using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected string city;
        protected string street;
        protected int house_number;
        protected int apartment;
        protected int house_residents;


        //Class 





        public Person(long id, string firstname, string lastname, string birthdate, string phone, string mail, string city, string street, int house_number, int apartment, int house_residents)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthdate = birthdate;
            this.phone = phone;
            this.mail = mail;
            this.city = city;
            this.street = street;
            this.house_number = house_number;
            this.apartment = apartment;
            this.house_residents = house_residents;
        }
        


        public virtual string WhoAmI()
        {
            return "Person";
        }

        public override string ToString()
        {
            return this.Id + ", " + this.firstname + ", " + this.lastname + ", " +this.birthdate+", "+this.phone+", "+this.mail+", "+this.city+", "+this.street+", "+this.house_number+", "+this.apartment+", "+this.house_residents+", 0";
        }

        public long Id
        {
            get { return id; }
        }
    }
}
