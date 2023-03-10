using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

public class ListData
{
            public enum FlightStatus
            {
                check_in
              , gate_closed
              , arrived
              , departed_at
              , unknown
              , canceled
              , expected_at
              , delayed
              , in_flight

            }
            public enum FlightClass
            {
                economy
              , business
            }
            public enum Sex
            {
                male
              , female
            }

       
}
