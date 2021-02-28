using System;
namespace CoronaTrackApp
{
    public class Address
    {
        private string city;
        private string street;
        private int number;

        public Address(string city, string street, int number)
        {
            this.city = city;
            this.street = street;
            this.number = number;
        }

        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int Number { get => number; set => number = value; }

 

        public override string ToString()

        {
            return this.city + ", " + this.street + ", " + this.number;
        }
    }
}
