using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Data;

public class NotificationEntity
{
    [Key]
    public string Email { get; set; } = null!;

    public bool subscribeStatus { get; set; } = false;

    public bool useDarkmode { get; set; } = false;
}
