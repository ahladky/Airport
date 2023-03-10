using Airport_panel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

public class MyDbContext : DbContext
{
    public DbSet<FlightDB> FlightDB { get; set; }
    public DbSet<FlightsCostDB> FlightsCostDB { get; set; }
    public DbSet<FligthPassengerListDB> FligthPassengerListDB { get; set; }
    public DbSet<PassengerDB> PassengerDB { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {        
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=mainA;Integrated Security=true;TrustServerCertificate=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<FlightDB>()
            .HasMany(f => f.FlightsCostsDB)
            .WithOne(fc => fc.FlightDB)
            .HasForeignKey(fc => fc.Id_flight);

        modelBuilder.Entity<FlightDB>()
            .HasMany(f => f.FligthPassengerListsDB)
            .WithOne(fp => fp.FlightDB)
            .HasForeignKey(fp => fp.Id_flight);

        modelBuilder.Entity<PassengerDB>()
            .HasMany(p => p.FligthPassengerListsDB)
            .WithOne(fp => fp.PassengerDB)
            .HasForeignKey(fp => fp.Id_passenger);

    }

    public List<FlightDB> SearchByFlightNumber(string flightNumber)
    {
        return FlightDB.Where(x => x.Flight_number.Contains(flightNumber)).ToList();
    }
    public List<FlightDB> SearchByDateArrival(DateTime timeOfArrival)
    {
        return FlightDB.Where(f => f.DateTimeF.Date == timeOfArrival.Date && f.Direction == "arrival").ToList();
    }
    public List<FlightDB> SearchByPort(string flightPort)
    {
        return FlightDB.Where(f => f.City_arrival == flightPort).ToList();
    }
    public List<FlightDB> SearchByNearestFlight(DateTime time, string port, ushort hour)
    {
        DateTime minTime = time.AddHours(-hour);
        DateTime maxTime = time.AddHours(hour);

        return FlightDB.Where(f => f.DateTimeF >= minTime && f.DateTimeF <= maxTime && f.City_arrival == port)
            .OrderBy(f => f.DateTimeF).ToList();
    }
    static void HeadTable()
    {
        Console.Clear();
        Console.WriteLine("|{0,-10}|{1,-18}|{2,-10}|{3,-10}|{4,-14}|{5,-10}|{6,-15}|{7,-5}|", "Direction", "Date/time", "Number", "City", "Airline", "Terminal", "FlightStatus", "Gates");
        Console.WriteLine("|{0,-10}|{1,-18}|{2,-10}|{3,-10}|{4,-14}|{5,-10}|{6,-15}|{7,-5}|", "----------", "------------------", "----------", "----------", "--------------", "----------", "---------------", "-----");
    }
    public void FlightTable(string direction = null)
    {
        HeadTable();
        foreach (FlightDB f in FlightDB)
        {
            if (f.Direction == direction || direction == null)
            {
                Console.WriteLine("|{0,-10}|{1,-18}|{2,-10}|{3,-10}|{4,-14}|{5,-10}|{6,-15}|{7,-5}|",
                   f.Direction, f.DateTimeF.ToString("dd.MM.yyyy HH:mm"), f.Flight_number, f.City_arrival, f.Airline, f.Terminal, (ListData.FlightStatus)Enum.Parse(typeof(ListData.FlightStatus), f.Flight_status), f.Gates);
            }

        }
    }
    public void SearchFlightTable(List<FlightDB> flights)
    {
        HeadTable();
        foreach (FlightDB f in flights)
        {
                Console.WriteLine("|{0,-10}|{1,-18}|{2,-10}|{3,-10}|{4,-14}|{5,-10}|{6,-15}|{7,-5}|",
                   f.Direction, f.DateTimeF.ToString("dd.MM.yyyy HH:mm"), f.Flight_number, f.City_arrival, f.Airline, f.Terminal, (ListData.FlightStatus)Enum.Parse(typeof(ListData.FlightStatus), f.Flight_status), f.Gates);         
        }
    }
    public int OneFlightTable(string flightNumber)
    {
        HeadTable();
        FlightDB f = SearchByFlightNumber(flightNumber).FirstOrDefault();

        Console.WriteLine("|{0,-10}|{1,-18}|{2,-10}|{3,-10}|{4,-14}|{5,-10}|{6,-15}|{7,-5}|",
            f.Direction, f.DateTimeF.ToString("dd.MM.yyyy HH:mm"), f.Flight_number, f.City_arrival, f.Airline, f.Terminal, (ListData.FlightStatus)Enum.Parse(typeof(ListData.FlightStatus), f.Flight_status), f.Gates);
        return f.Id;
    }
    public void ViewFlightPrices(int idFlight)
    {
        List<FlightsCostDB> cost = FlightsCostDB.Where(n => n.Id == idFlight).ToList();

        foreach (var c in FlightsCostDB)
        {
            Console.WriteLine("{0} - {1} $", c.CostName, c.CostValue);
        }

    }
    public void ViewFlightPassegers(int idFlight)
    {
        List<PassengerDB> passengerList = FligthPassengerListDB
                                        .Where(fp => fp.Id_flight == idFlight)
                                        .Select(fp => fp.PassengerDB)
                                        .ToList();

        foreach (var p in passengerList)
        {
            HeadTablePassengers();
            Console.WriteLine("|{0,-3}|{1,-15}|{2,-15}|{3,-11}|{4,-10}|{5,-16}|{6,-6}|", p.Id, p.FirstName, p.SecondName, p.Nationality, p.Passport, p.DateOfBirthday.Date, p.Sex);
        }

    }
    public void ViewFlightPassegers()
    {
        List<PassengerDB> passengerList = PassengerDB.ToList();
        HeadTablePassengers();
        foreach (var p in passengerList)
        {            
            Console.WriteLine("|{0,-3}|{1,-15}|{2,-15}|{3,-11}|{4,-10}|{5,-16}|{6,-6}|", p.Id, p.FirstName, p.SecondName, p.Nationality, p.Passport, p.DateOfBirthday.Date, p.Sex);
        }

    }
    public List<FlightDB> SearchFlightByPassengerId (int idPassenger)
    {
        List<FlightDB> flightList = FligthPassengerListDB
                                        .Where(fp => fp.Id_passenger == idPassenger)
                                        .Select(f => f.FlightDB)
                                        .ToList();
        return flightList;
    }
    public PassengerDB SearchByPassengerId(int idPassenger)
    {
        return PassengerDB.Where(p => p.Id == idPassenger).SingleOrDefault();
    }
    public void OnePassуgerTable(int idPassenger)
    {
        PassengerDB p = PassengerDB.Where(fp => fp.Id == idPassenger).FirstOrDefault();
        
            HeadTablePassengers();
            Console.WriteLine("|{0,-3}|{1,-15}|{2,-15}|{3,-11}|{4,-10}|{5,-16}|{6,-6}|", p.Id, p.FirstName, p.SecondName, p.Nationality, p.Passport, p.DateOfBirthday, p.Sex);        
    }
    static void HeadTablePassengers()
    {
        Console.WriteLine("|{0,-3}|{1,-15}|{2,-15}|{3,-11}|{4,-10}|{5,-16}|{6,-6}|", "id", "FirstName", "SecondName", "Nationality", "Passport", "DateOfBirthday", "Sex");
        Console.WriteLine("|{0,-3}|{1,-15}|{2,-15}|{3,-11}|{4,-10}|{5,-16}|{6,-6}|", "---", "---------------", "---------------", "-----------", "----------", "----------------", "------");
    }
    public List<PassengerDB> SearchByPassengerName(string name)
    {
        return PassengerDB.Where(p => p.FirstName.Contains(name) || p.SecondName.Contains(name)).ToList();
    }
    public List<PassengerDB> SearchByPassport(string passport)
    {
        return PassengerDB.Where(p => p.Passport.Contains(passport)).ToList();
    }
}
