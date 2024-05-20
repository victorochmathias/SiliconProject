using BlazorWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services;

public class UserService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;


    public async Task<UserProfile> GetUserProfileAsync(string id)
    {
        var userProfileEntity = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);
        if (userProfileEntity != null) 
        {
            return userProfileEntity;
        }

        return null!;
    }

}
