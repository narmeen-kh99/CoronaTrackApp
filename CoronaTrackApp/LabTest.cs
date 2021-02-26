using System;
namespace CoronaTrackApp
{
    public class LabTest
    {
        private int labid;
        private int testid;
        private long personid;
        private DateTime date;
        private bool result;

        public LabTest(int labid, int testid, long personid, string date, bool result)
        {
            this.labid = labid;
            this.testid = testid;
            this.personid = personid;
            this.date = DateTime.Parse(date);
            this.result = result;
        }

        public int LabId
        {
            get { return labid; }
        }
        public int TestId
        {
            get { return testid; }
        }
        public long PersonId
        {
            get { return personid; }
        }
        public bool Result
        {
            get { return result; }
        }
        public DateTime Date
        {
            get { return date; }
        }

        public string ToString()
        {
            return this.date.ToString("d") + " " + this.labid + " " + this.testid + " " + this.result;
        }
        public void replaceParams(LabTest newtest)
        {
            this.personid = newtest.personid;
            this.date = newtest.Date; ;
            this.result = newtest.Result;
        }
    }
}
