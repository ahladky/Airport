using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel.Model;

//[Table("MA_Flight")]
public class FlightDB
{   
    [Key]
    public int Id { get; set; }
    public string Direction { get; set; }
    public DateTime DateTimeF { get; set; }
    public string Flight_number { get; set; }
    public string City_arrival { get; set; }
    public string Airline { get; set; }
    public string Terminal { get; set; }
    public string Flight_status { get; set; }
    public string Gates { get; set; }

   
    public ICollection<FlightsCostDB> FlightsCostsDB { get; set; }
    public ICollection<FligthPassengerListDB> FligthPassengerListsDB { get; set; }

    public FlightDB(int id, string direction, DateTime dateTimeF, string flight_number, string city_arrival, string airline, string terminal, string flight_status, string gates)
    {
        Id = id;
        Direction = direction;
        DateTimeF = dateTimeF;
        Flight_number = flight_number;
        City_arrival = city_arrival;
        Airline = airline;
        Terminal = terminal;
        Flight_status = flight_status;
        Gates = gates;
    }

    private readonly MyDbContext dbContext;

    public FlightDB(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<FlightDB> GetAll()
    {
        List<FlightDB> flights = dbContext.FlightDB
                                        .Include(f => f.FlightsCostsDB)
                                        .Include(f => f.FligthPassengerListsDB)
                                        .ThenInclude(fp => fp.PassengerDB)
                                        .ToList();
        return flights;
    }

    internal bool Any(Func<object, bool> p)
    {
        throw new NotImplementedException();
    }
}
