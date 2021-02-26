using System;
namespace CoronaTrackApp
{
    public class Address
    {
        private string city;
        private string street;
        private int number;

        public Address(string city,string street,int number)
        {
            this.city = city;
            this.street = street;
            this.number = number;
        }

        public string ToString()
        {
            return this.city + ", " + this.street + ", " + this.number;
        }
    }
}
