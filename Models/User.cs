using System.ComponentModel.DataAnnotations;

public class User
{
    public int EmployeeID { get; set; }

    [Required]
    public string Name { get; set; }
}