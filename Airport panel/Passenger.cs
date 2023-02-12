using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel;

public class Passenger : IComparable
{
    public ushort ID { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Nationality { get; set; }
    public string Passport { get; set; }
    public DateOnly DateOfBirthday { get; set; }
    public Sex Sex { get; set; }
    //public FlightClass FlightClass { get; set; }
    public Passenger()
    {

    }
    public Passenger(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }
        public Passenger(ushort id, string firstName, string secondName, string nationality, string passport, DateOnly dateOfBirthday, Sex sex)//, FlightClass flightClass)
    {
        ID = id;
        FirstName = firstName;
        SecondName = secondName;
        Nationality = nationality;
        Passport = passport;
        DateOfBirthday = dateOfBirthday;
        Sex = sex;
        //FlightClass = flightClass;
    }

    public override string ToString()
    {
        return $"FirstName: {FirstName}, SecondName: {SecondName}, Nationality: {Nationality}, Passport: {Passport}, Birthday: {DateOfBirthday}, Sex: {Sex}";
    }
    public override int GetHashCode()
    {
        return ID + SecondName.ToList().FindAll(c=> c == 'o').Count;
    }

    public void EditID(ushort id)
    {
        ID = id;
    }
    public void EditFirstName(string firstName)
    {
        FirstName = firstName;
    }
    public void EditSecondName(string secondName)
    {
        SecondName = secondName;
    }
    public void EditNationality(string nationality)
    {
        Nationality = nationality;
    }
    public void EditPassport(string passport)
    {
        Passport = passport;
    }
    public void EditDateOfBirthday(DateOnly dateOfBirthday)
    {
        DateOfBirthday = dateOfBirthday;
        
    }
    public void EditSex(Sex sex)
    {
        Sex = sex;
    }
    //public void EditFlightClass(FlightClass flightClass)
    //{
    //    FlightClass = flightClass;
    //}

    public int CompareToByName(string passenger) 
    {

        if (FirstName.CompareTo(passenger) == 0 || SecondName.CompareTo(passenger) == 0) 
            return 0;
        else 
            return -1;
    }
    public int CompareToByPassport(string passport)
    {

        if (Passport.CompareTo(passport) == 0)
            return 0;
        else
            return -1;
    }


    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }
}
