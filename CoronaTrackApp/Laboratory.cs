using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTrackApp
{
    //+++++++++++++++++++++++
    class Laboratory
    {
        private int labid;
        private int testid;
        private long personid;
        private int date;
        private bool result;
        //++++++
        public Laboratory(int labid,int testid, long personid, string date,bool result)
        {
            this.labid = labid;
            this.testid = testid;
            this.personid = personid;
            this.date = date;
            this.result = result;

        }
        //+++++++
    }
}
