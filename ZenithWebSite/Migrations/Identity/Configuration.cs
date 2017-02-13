namespace ZenithWebSite.Migrations.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(ZenithWebSite.Models.ApplicationDbContext context)
        {
            setRoles(context);
            context.SaveChanges();
            setUsers(context);
            context.SaveChanges();
            context.Activities.AddOrUpdate(a => a.ActivityId, getActivities());
            context.SaveChanges();
            context.Events.AddOrUpdate(e => e.EventId, getEvents(context));
            context.SaveChanges();
        }

        private void setRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };

                manager.Create(role);
            }
        }

        private void setUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "a"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "m"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "m", Email = "m@m.m" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Member");
            }
        }

        private Event[] getEvents(ZenithWebSite.Models.ApplicationDbContext context)
        {
            var events = new List<Event>
            {
                new Event {EventId= 1, Start =  new DateTime(2017, 03, 04, 8, 30, 0), End =  new DateTime(2017, 03, 04, 10, 20, 0), CreatedBy = "richard93", ActivityId = 1, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 1).CreationDate, IsActive = false},
                new Event {EventId= 2, Start = new DateTime(2017, 03, 04, 11, 30, 0), End = new DateTime(2017, 03, 04, 12, 20, 0), CreatedBy = "richard93", ActivityId = 2, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 2).CreationDate, IsActive = true},
                new Event {EventId= 3, Start = new DateTime(2017, 03, 04, 16, 30, 0), End = new DateTime(2017, 03, 04, 18, 20, 0), CreatedBy = "lisha788", ActivityId = 3, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 3).CreationDate, IsActive = false},
                new Event {EventId= 4, Start = new DateTime(2017, 04, 04, 9, 30, 0), End = new DateTime(2017, 04, 04, 11, 20, 0), CreatedBy = "richard93", ActivityId = 4, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 4).CreationDate, IsActive = false},
                new Event {EventId= 5, Start = new DateTime(2017, 04, 04, 12, 30, 0), End = new DateTime(2017, 04, 04, 15, 20, 0), CreatedBy = "richard93", ActivityId = 5, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 5).CreationDate, IsActive = true},
                new Event {EventId= 6, Start = new DateTime(2017, 04, 04, 16, 30, 0), End = new DateTime(2017, 04, 04, 18, 20, 0), CreatedBy = "richard93", ActivityId = 6, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 6).CreationDate, IsActive = true},
                new Event {EventId= 7, Start = new DateTime(2017, 05, 04, 9, 30, 0), End = new DateTime(2017, 05, 04, 10, 20, 0), CreatedBy = "lisha788", ActivityId = 7, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 7).CreationDate, IsActive = false},
                new Event {EventId= 8, Start = new DateTime(2017, 05, 04, 12, 30, 0), End = new DateTime(2017, 05, 04, 13, 20, 0), CreatedBy = "lisha788", ActivityId = 8, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 8).CreationDate, IsActive = false},
                new Event {EventId= 9, Start = new DateTime(2017, 05, 04, 14, 30, 0), End = new DateTime(2017, 05, 04, 15, 50, 0), CreatedBy = "richard93", ActivityId = 9, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 9).CreationDate, IsActive = true},
                new Event {EventId= 10, Start = new DateTime(2017, 05, 04, 16, 0, 0), End = new DateTime(2017, 05, 04, 17, 20, 0), CreatedBy = "richard93", ActivityId = 10, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 10).CreationDate, IsActive = true},
                new Event {EventId= 11, Start = new DateTime(2017, 06, 04, 8, 30, 0), End = new DateTime(2017, 06, 04, 9, 20, 0), CreatedBy = "lisha788", ActivityId = 11, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 11).CreationDate, IsActive = false},
                new Event {EventId= 12, Start = new DateTime(2017, 06, 04, 11, 30, 0), End = new DateTime(2017, 06, 04, 13, 20, 0), CreatedBy = "richard93", ActivityId = 12, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 12).CreationDate, IsActive = true},
                new Event {EventId= 13, Start =new DateTime(2017, 07, 04, 14, 30, 0), End = new DateTime(2017, 07, 04, 16, 20, 0), CreatedBy = "lisha788", ActivityId = 13, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 13).CreationDate, IsActive = false},
                new Event {EventId= 14, Start = new DateTime(2017, 08, 04, 8, 30, 0), End = new DateTime(2017, 08, 04, 11, 20, 0), CreatedBy = "richard93", ActivityId = 14, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 14).CreationDate, IsActive = false},
                new Event {EventId= 15, Start = new DateTime(2017, 08, 04, 13, 30, 0), End =new DateTime(2017, 08, 04, 16, 20, 0), CreatedBy = "lisha788", ActivityId = 15, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 15).CreationDate, IsActive = true},

                new Event {EventId= 16, Start = new DateTime(2017, 02, 05, 13, 30, 0), End =new DateTime(2017, 02, 06, 16, 20, 0), CreatedBy = "lisha788", ActivityId = 16, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 16).CreationDate, IsActive = true},
                new Event {EventId= 17, Start = new DateTime(2017, 02, 06, 10, 30, 0), End =new DateTime(2017, 02, 07, 12, 20, 0), CreatedBy = "lisha788", ActivityId = 17, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 17).CreationDate, IsActive = true},
                new Event {EventId= 18, Start = new DateTime(2017, 02, 13, 09, 30, 0), End =new DateTime(2017, 02, 14, 11, 30, 0), CreatedBy = "lisha788", ActivityId = 18, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 18).CreationDate, IsActive = true},

                new Event {EventId= 19, Start = new DateTime(2017, 02, 12, 13, 30, 0), End =new DateTime(2017, 02, 13, 16, 20, 0), CreatedBy = "lisha788", ActivityId = 19, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 19).CreationDate, IsActive = true},
                new Event {EventId= 20, Start = new DateTime(2017, 02, 14, 13, 30, 0), End =new DateTime(2017, 02, 15, 16, 20, 0), CreatedBy = "bart604", ActivityId = 20, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 20).CreationDate, IsActive = true},
                new Event {EventId= 21, Start = new DateTime(2017, 02, 17, 13, 30, 0), End =new DateTime(2017, 02, 18, 16, 20, 0), CreatedBy = "homer619", ActivityId = 21, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 21).CreationDate, IsActive = true},
                new Event {EventId= 22, Start = new DateTime(2017, 02, 13, 13, 30, 0), End =new DateTime(2017, 02, 14, 16, 20, 0), CreatedBy = "marge720", ActivityId = 22, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 22).CreationDate, IsActive = true},
                new Event {EventId= 23, Start = new DateTime(2017, 02, 18, 13, 30, 0), End =new DateTime(2017, 02, 19, 16, 20, 0), CreatedBy = "lisa456", ActivityId = 23, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 23).CreationDate, IsActive = true},
                new Event {EventId= 24, Start = new DateTime(2017, 02, 08, 13, 30, 0), End =new DateTime(2017, 02, 09, 16, 20, 0), CreatedBy = "lisa456", ActivityId = 24, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 24).CreationDate, IsActive = true},
                new Event {EventId= 25, Start = new DateTime(2017, 02, 09, 13, 30, 0), End =new DateTime(2017, 02, 10, 16, 20, 0), CreatedBy = "lisa456", ActivityId = 25, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 25).CreationDate, IsActive = true},
                new Event {EventId= 26, Start = new DateTime(2017, 02, 14, 10, 30, 0), End =new DateTime(2017, 02, 14, 12, 20, 0), CreatedBy = "lisa456", ActivityId = 26, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 26).CreationDate, IsActive = true},
                new Event {EventId= 27, Start = new DateTime(2017, 02, 06, 13, 30, 0), End =new DateTime(2017, 02, 07, 15, 20, 0), CreatedBy = "lisa456", ActivityId = 27, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 27).CreationDate, IsActive = true}

            };

            return events.ToArray();
        }

        private Activity[] getActivities()
        {
            var activities = new List<Activity>()
            {
                new Activity {ActivityId = 1, Description = "Senior's Golf Tournament", CreationDate = new DateTime(2017, 03, 04)},
                new Activity {ActivityId = 2, Description = "Leadership General Assembly Meeting", CreationDate = new DateTime(2017, 03, 04)},
                new Activity {ActivityId = 3, Description = "Youth Bowling Tournament", CreationDate = new DateTime(2017, 03, 04)},
                new Activity {ActivityId = 4, Description = "Young ladies cooking lessons", CreationDate = new DateTime(2017, 04, 04)},
                new Activity {ActivityId = 5, Description = "Youth craft leassons", CreationDate = new DateTime(2017, 04, 04)},
                new Activity {ActivityId = 6, Description = "Youth choir practice", CreationDate = new DateTime(2017, 04, 04)},
                new Activity {ActivityId = 7, Description = "Lunch", CreationDate = new DateTime(2017, 05, 04)},
                new Activity {ActivityId = 8, Description = "Pancake Breakfast", CreationDate = new DateTime(2017, 05, 04)},
                new Activity {ActivityId = 9, Description = "Swimming Lessons for the youth", CreationDate = new DateTime(2017, 05, 04)},
                new Activity {ActivityId = 10, Description = "Swimming Exercise for parents", CreationDate = new DateTime(2017, 05, 04)},
                new Activity {ActivityId = 11, Description = "Bingo Tournament", CreationDate = new DateTime(2017, 06, 04)},
                new Activity {ActivityId = 12, Description = "BBQ Lunch", CreationDate = new DateTime(2017, 06, 04)},
                new Activity {ActivityId = 13, Description = "Garage Sale", CreationDate = new DateTime(2017, 07, 04)},
                new Activity {ActivityId = 14, Description = "Youth Basketball Tournament", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 15, Description = "Senior Volleyball Tournament", CreationDate = new DateTime(2017, 08, 04)},

                new Activity {ActivityId = 16, Description = "Karaoke Tournament", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 17, Description = "Sumo Wrestling Tournament", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 18, Description = "Speed Dating", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 19, Description = "Cricket Tournament", CreationDate = new DateTime(2017, 08, 04)},


                new Activity {ActivityId = 20, Description = "Swim Meet", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 21, Description = "Hackathon", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 22, Description = "Baseball Tournament", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 23, Description = "Community Ball", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 24, Description = "Pie Eating Contest", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 25, Description = "Ping Pong Tournament", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 26, Description = "Career Fair", CreationDate = new DateTime(2017, 08, 04)},
                new Activity {ActivityId = 27, Description = "Farmers Market", CreationDate = new DateTime(2017, 08, 04)}

            };

            return activities.ToArray();
        }
    }
}
