using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airTrafficBL
{
    public  class BLFactory
    {
        BLimpl instance;
        public  BLFactory()
        {
            if(this.instance == null)
            {
                this.instance = new BLimpl();
            }
        }

        public BLimpl getTheInstacne()
        {
            return this.instance;
        }
    }
}

