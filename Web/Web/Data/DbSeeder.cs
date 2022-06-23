using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Data
{
    public class DbSeeder
    {
        private readonly MyAppContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public DbSeeder(MyAppContext context,
                        UserManager<ApplicationUser> userManager,
                        RoleManager<IdentityRole> RoleManager)
        {
            _context = context;
            _userManager = userManager;
            _RoleManager = RoleManager;
        }

        public async Task SeedDatabase()
        {
            //Teachers테이블에 데이타가 없다면, 
            if (!_context.Teachers.Any())
            {
                List<Teacher> teachers = new List<Teacher>()
                {
                    new Teacher(){ Name = "세종대왕", Class="한글"},
                    new Teacher(){ Name="이순신", Class="해상전략"},
                    new Teacher(){ Name="을지문덕", Class="지략"},
                    new Teacher(){ Name="제갈량", Class="해상전략"}
                };

                //여러개 추가하고 싶을때
                await _context.AddRangeAsync(teachers);
                await _context.SaveChangesAsync(); 

                //하나만추가하고 싶을때.
                //await _context.AddAsync(new Teacher() { Name = "세종대왕", Class = "한글" });
            }

            //운영자롤을 부여
            var adminAccount = await _userManager.FindByNameAsync("admin@gmail.com");
            var adminRole = new IdentityRole("Admin");
            //데이타베이스에 데이타를 넣기. AspNetRoles에 Admin입력된다.  
            await _RoleManager.CreateAsync(adminRole);
            //adminAccount계정에 운영자ROLE를 부여한다. AspNetUserRoles에 입력된다. 
            await _userManager.AddToRoleAsync(adminAccount, adminRole.Name);
        }
    }
}
