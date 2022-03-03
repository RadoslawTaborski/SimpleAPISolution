using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models;

public class Status
{
    #pragma warning disable CS8618 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]   
    public string Name { get; set; }
    
    #pragma warning restore CS8618 
}