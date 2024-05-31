using BlazorWebApp.Data;
using Microsoft.EntityFrameworkCore;
using static BlazorWebApp.Components.Pages.Details;

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


    public async Task<bool> UpdateUserDetailsAsync(string userId, BasicInfoFormModel model)
    {
        var user = await _context.Users
                .Include(u => u.UserProfile) // Include the UserProfile
                .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        user.Email = model.Email;
        user.UserName = model.Email;
        user.PhoneNumber = model.PhoneNumber;

        if (user.UserProfile != null)
        {
            user.UserProfile.FirstName = model.FirstName;
            user.UserProfile.LastName = model.LastName;
        }


        _context.Entry(user).State = EntityState.Modified;
        var result = await _context.SaveChangesAsync();
        return true;
    }

}
