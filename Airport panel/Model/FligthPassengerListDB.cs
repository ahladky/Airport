using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel.Model;

public class FligthPassengerListDB
{
    [Key]
    public int Id { get; set; }
    public int Id_flight { get; set; }
    public int Id_passenger { get; set; }
    public FlightDB FlightDB { get; set; }
    public PassengerDB PassengerDB { get; set; }
}
