﻿using System;
namespace CoronaTrackApp
{
    public class Route
    {
        private Address address;
        private string sitename;
        private DateTime datetime;
        private string visit_date;
        private string visit_time;

        public Route(string visit_date, string visit_time,string sitename)
        {
            this.sitename = sitename;
            string fulldate = visit_date + " " + visit_time;
            this.datetime = DateTime.Parse(fulldate);
            this.address = null;
            
        }

        public Route(string visit_date, string visit_time,  string sitename, string city,string street,int number)
        {
            this.address = new Address(city,street,number);
            this.sitename = sitename;
            string fulldate = visit_date + " " + visit_time;
            this.datetime = DateTime.Parse(fulldate);
 
        }

        public DateTime RDateTime
        {
            get { return RDateTime; }
        }

        public override string ToString()
        {
            string myString = this.datetime.ToString("dd/MM/yyyy HH:mm") + " " + this.sitename; 
            if(this.address != null)
            {
                myString += " " + this.address;
            }
            return myString;
        }
    }
}
