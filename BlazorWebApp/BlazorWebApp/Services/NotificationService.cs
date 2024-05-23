using BlazorWebApp.Data;
using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services;

public class NotificationService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;


    public async Task<NotificationEntity> CreateNotificationEntity(NotificationModel model)
    {
        var existingSubscriber = await _context.NotificationEntities.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (existingSubscriber == null)
        {

            var entity = new NotificationEntity
            {
                Email = model.Email,
                subscribeStatus = model.subscribeStatus,
                useDarkmode = model.useDarkmode
            };

            var result = await _context.NotificationEntities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        else
        {
            return null!;
        }
    }


    public async Task<NotificationEntity> GetNotificationEntity(string email)
    {
        var entity = await _context.NotificationEntities.FirstOrDefaultAsync(x => x.Email == email);
        if (entity != null)
        {
            return entity;
        }
        else
            return null!;
    }


}
