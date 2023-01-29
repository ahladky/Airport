using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;



public class Flight
{
    public string? Direction { get; set; }
    public DateTime DateTimeF { get; set; }
    public string? Flight_number { get; set; }
    public string? City_arrival;
    public string? Airline;
    public string? Terminal;
    public FlightStatus? Flight_status { get; set; }
    public string? Gates;

    public Flight()
    {

    }
    public Flight(string direction, DateTime dateTimeF, string flight_number, string city_arrival, string airline, string terminal, FlightStatus flight_status, string gates)
    {
        Direction = direction;
        DateTimeF = dateTimeF;
        Flight_number = flight_number;
        City_arrival = city_arrival;
        Airline = airline;
        Terminal = terminal;
        Flight_status = flight_status;
        Gates = gates;
    }
   

    public void EditDirection(string direction)
    {
        this.Direction = direction;
    }
    public void EditDateTimeF(DateTime dateTimeF)
    {
        DateTimeF = dateTimeF;
    }
    public void EditFlight_number(string flight_number)
    {
        Flight_number = flight_number;
    }
    public void EditCity_arrival(string city_arrival)
    {
        City_arrival = city_arrival;
    }
    public void EditAirline(string airline)
    {
        Airline = airline;
    }
    public void EditTerminal(string terminal)
    {
        Terminal = terminal;
    }
    public void EditFlightStatus(FlightStatus flight_status)
    {
       Flight_status = flight_status;
    }
    public void EditGates(string gates)
    {
       Gates = gates;
    }

}
