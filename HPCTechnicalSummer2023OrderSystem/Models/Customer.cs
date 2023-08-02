using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPCTechnicalSummer2023OrderSystem.Models;

public class Customer
{
    public int Id { get; set; }
    [StringLength(200)]
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public ICollection<Order> Orders { get; set; } = null!;

    public override string? ToString()
    {
        return $"\tId:\t{Id}\n\tFirst Name:\t{FirstName}\n\tLast Name:\t{LastName}\n\tAddress:\t{Address}\n\tPhone:{Phone}\n\tEmail:\t{Email}\n";
    }
}
