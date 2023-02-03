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
    public string DateOfBirthday { get; set; }
    public string Sex { get; set; }
    public FlightClass FlightClass { get; set; }

    public Passenger(string firstName, string secondName, string nationality, string passport, string dateOfBirthday, string sex, FlightClass flightClass)
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
