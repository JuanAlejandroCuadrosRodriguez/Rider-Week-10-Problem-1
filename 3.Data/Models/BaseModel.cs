using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace _3.Data.Models;

public class BaseModel
{
    public int Id { get; set; }
    
    public Boolean IsActive { get; set; } = true;
}