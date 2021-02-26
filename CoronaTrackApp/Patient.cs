using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTrackApp
{
    class Patient : Person
    {
        //public Patient(long id, string firstname, string lastname, string phone)
        //{
        //    this.id = id;
        //    this.firstname = firstname;
        //    this.lastname = lastname;
        //    this.phone = phone;
        //}

        public Patient(long id, string firstname, string lastname, string birthdate, string phone, string mail, string city, string street, int house_number, int apartment, int house_residents) : base( id,  firstname,  lastname, birthdate,  phone,  mail,  city,  street,  house_number,  apartment,  house_residents)
        {}



        //public override string WhoAmI()
        //{
        //    return "Patient";
        //}


    }
}
