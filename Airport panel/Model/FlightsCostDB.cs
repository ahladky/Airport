using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel.Model;

public class FlightsCostDB
{
    [Key]
    public int Id { get; set; }
    public int Id_flight { get; set; }
    public string CostName { get; set; }
    public double CostValue { get; set; }

    public FlightDB FlightDB { get; set; }
    //public FlightDB FlightDB { get; set; }
    //public ICollection<FlightDB> FlightDB { get; set; }
    public FlightsCostDB(int id, int id_flight, string costName, double costValue)
    {
        Id = id;
        Id_flight = id_flight;
        CostName = costName;
        CostValue = costValue;
    }

}
