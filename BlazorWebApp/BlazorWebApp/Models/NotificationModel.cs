using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Models;

public class NotificationModel
{
    [Key]
    public string Email { get; set; } = null!;

    public bool subscribeStatus { get; set; } 

    public bool useDarkmode { get; set; }
}
