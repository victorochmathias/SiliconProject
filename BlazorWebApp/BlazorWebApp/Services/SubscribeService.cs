using BlazorWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services;

public class SubscribeService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;




    public async Task<SubscribeEntity> FindSubscriberByEmail(string email)
    {
        var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
        if (subscriber != null)
        {
            return subscriber;
        }
        else
        {
            return null!;
        }
    }
}
