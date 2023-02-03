using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

public class Passenger
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Nationality { get; set; }
    public string Passport { get; set; }
    public DateOnly DateOfBirthday { get; set; }
    public Sex Sex { get; set; }
    public FlightClass FlightClass { get; set; }

    public Passenger(string firstName, string secondName, string nationality, string passport, DateOnly dateOfBirthday, Sex sex, FlightClass flightClass)
    {
        FirstName = firstName;
        SecondName = secondName;
        Nationality = nationality;
        Passport = passport;
        DateOfBirthday = dateOfBirthday;
        Sex = sex;
        FlightClass = flightClass;
    }
}
