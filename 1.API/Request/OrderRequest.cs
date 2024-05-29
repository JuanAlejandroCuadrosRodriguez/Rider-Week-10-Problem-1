using Microsoft.Build.Framework;

namespace _1.API.Request;

public class OrderRequest
{
    [Required]
    public int ClientId {get; set;}
    public int Total {get; set;}

}