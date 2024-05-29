using Microsoft.Build.Framework;

namespace _1.API.Request;

public class ClientRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string email { get; set; }
}