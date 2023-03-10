using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_panel.Model;

public class PassengerDB
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Nationality { get; set; }
    public string Passport { get; set; }
    public DateTime DateOfBirthday { get; set; }
    public string Sex { get; set; }

    public ICollection<FligthPassengerListDB> FligthPassengerListsDB { get; set; }



}
