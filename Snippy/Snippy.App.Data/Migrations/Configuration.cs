using System.Collections.Generic;
using System.Management.Instrumentation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Snippy.App.Model;

namespace Snippy.App.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Snippy.App.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Snippy.App.Data.ApplicationDbContext";
        }

        protected override void Seed(Snippy.App.Data.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }

            if (!context.Labels.Any())
            {
                this.SeedLabels(context);
            }

            if (!context.Languages.Any())
            {
                this.SeedLanguages(context);
            }

            if (!context.Snippets.Any())
            {
                this.SeedSnippets(context);
            }

            if (!context.Comments.Any())
            {
                this.SeedComments(context);
            }
        }

        private void SeedSnippets(ApplicationDbContext context)
        {
            var snippets = new List<Snippet>()
            {
                new Snippet()
                {
                    Title = "Ternary Operator Madness",
                    Description = "This is how you DO NOT user ternary operators in C#!",
                    Code = "bool X = Glob.UserIsAdmin ? true : false;",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    CreationDateTime = DateTime.Parse("26.10.2015 17:20:33"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "C#"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "funny")
                    }
                },
                new  Snippet()
                {
                    Title = "Points Around A Circle For GameObject Placement",
                    Description = "Determine points around a circle which can be used to place elements around a central point",
                    Code = @"private Vector3 DrawCircle(float centerX, float centerY, float radius, float totalPoints, float currentPoint)
{
	float ptRatio = currentPoint / totalPoints;
	float pointX = centerX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;
	float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;

	Vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);

	return panelCenter;
}
                        ",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    CreationDateTime = DateTime.Parse("26.10.2015 20:15:30"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "C#"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "geometry"),
                        context.Labels.FirstOrDefault(l => l.Text == "games"),
                    }
                },
                new Snippet()
                {
                    Title = "forEach. How to break?",
                    Description = @"Array.prototype.forEach You can't break forEach. So use ""some"" or ""every"". Array.prototype.some some is pretty much the same as forEach but it break when the callback returns true. Array.prototype.every every is almost identical to some except it's expecting false to break the loop.",
                    Code = @"
var ary = [""JavaScript"", ""Java"", ""CoffeeScript"", ""TypeScript""];

ary.some(function (value, index, _ary) {
    console.log(index + "": "" + value);
            return value === ""CoffeeScript"";
        });
// output: 
// 0: JavaScript
// 1: Java
// 2: CoffeeScript
 
ary.every(function(value, index, _ary)
        {
            console.log(index + "": "" + value);
            return value.indexOf(""Script"") > -1;
        });
// output:
// 0: JavaScript
// 1: Java
                        ",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "newUser"),
                    CreationDateTime = DateTime.Parse("27.10.2015 10:53:20"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "JavaScript"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "jquery"),
                        context.Labels.FirstOrDefault(l => l.Text == "useful"),
                        context.Labels.FirstOrDefault(l => l.Text == "web"),
                        context.Labels.FirstOrDefault(l => l.Text == "front-end "),
                    }
                },
                new Snippet()
                {
                    Title = "Numbers only in an input field",
                    Description = "Method allowing only numbers (positive / negative / with commas or decimal points) in a field",
                    Code = @"$(""#input"").keypress(function(event){
	var charCode = (event.which) ? event.which : window.event.keyCode;
	if (charCode <= 13) { return true; } 
	else {
		var keyChar = String.fromCharCode(charCode);
		var regex = new RegExp(""[0-9,.-]"");
		return regex.test(keyChar); 
	} 
});",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "someUser"),
                    CreationDateTime = DateTime.Parse("28.10.2015 09:00:56"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "JavaScript"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "web"),
                        context.Labels.FirstOrDefault(l => l.Text == "front-end"),
                    }
                },
                new Snippet()
                {
                    Title = "Create a link directly in an SQL query",
                    Description = "That's how you create links - directly in the SQL!",
                    Code = @"SELECT DISTINCT
              b.Id,
              concat('<button type=""""button"""" onclick=""""DeleteContact(', cast(b.Id as char), ')"""">Delete...</button>') as lnkDelete
FROM tblContact   b
WHERE ....",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    CreationDateTime = DateTime.Parse("30.10.2015 11:20:00"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "SQL"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "bug"),
                        context.Labels.FirstOrDefault(l => l.Text == "funny"),
                        context.Labels.FirstOrDefault(l => l.Text == "mysql"),
                    }
                },
                new Snippet()
                {
                    Title = "Reverse a String",
                    Description = "Almost not worth having a function for...",
                    Code = @"def reverseString(s):
	""""""Reverses a string given to it.""""""
	return s[::-1]",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    CreationDateTime = DateTime.Parse("26.10.2015 09:35:13"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "Python"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "useful")
                    }
                },
                new Snippet()
                {
                    Title = "Pure CSS Text Gradients",
                    Description = "This code describes how to create text gradients using only pure CSS",
                    Code = @"/* CSS text gradients */
h2[data-text] {
	position: relative;
}
h2[data-text]::after {
	content: attr(data-text);
	z-index: 10;
	color: #e3e3e3;
	position: absolute;
	top: 0;
	left: 0;
	-webkit-mask-image: -webkit-gradient(linear, left top, left bottom, from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)));",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "someUser"),
                    CreationDateTime = DateTime.Parse("22.10.2015 19:26:42"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "CSS"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "web"),
                        context.Labels.FirstOrDefault(l => l.Text == "front-end"),
                    }
                },
                new Snippet()
                {
                    Title = "Check for a Boolean value in JS",
                    Description = "How to check a Boolean value - the wrong but funny way :D",
                    Code = @"var b = true;

if (b.toString().length < 5) {
  //...
}",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    CreationDateTime = DateTime.Parse("22.10.2015 05:30:04"),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "JavaScript"),
                    Labels = new HashSet<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "funny")
                    }
                },
            };

            foreach (var snippet in snippets)
            {
                context.Snippets.Add(snippet);
            }

            context.SaveChanges();
        }

        private void SeedComments(ApplicationDbContext context)
        {
            var comments = new List<Comment>()
            {
                new Comment()
                {
                    Content = "Now that's really funny! I like it!",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    CreationDateTime = DateTime.Parse("30.10.2015 11:50:38"),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Ternary Operator Madness")
                },
                new Comment()
                {
                    Content = "Here, have my comment!",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "newUser"),
                    CreationDateTime = DateTime.Parse("01.11.2015 15:52:42"),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Ternary Operator Madness")
                },
                new Comment()
                {
                    Content = "I didn't manage to comment first :(",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "someUser"),
                    CreationDateTime = DateTime.Parse("02.11.2015 05:30:20"),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Ternary Operator Madness")
                },
                new Comment()
                {
                    Content = "That's why I love Python - everything is so simple!",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "newUser"),
                    CreationDateTime = DateTime.Parse("27.10.2015 15:28:14"),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Reverse a String")
                },
                new Comment()
                {
                    Content = "I have always had problems with Geometry in school. Thanks to you I can now do this without ever having to learn this damn subject",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "someUser"),
                    CreationDateTime = DateTime.Parse("29.10.2015 15:08:42"),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Points Around A Circle For GameObject Placement")
                },
                new Comment()
                {
                    Content = "Thank you. However, I think there must be a simpler way to do this. I can't figure it out now, but I'll post it when I'm ready.",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    CreationDateTime = DateTime.Parse("03.11.2015 12:56:20"),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Numbers only in an input field")
                },
            };

            foreach (var comment in comments)
            {
                context.Comments.Add(comment);
            }

            context.SaveChanges();
        }

        private void SeedLanguages(ApplicationDbContext context)
        {
            var languages = new List<Language>()
            {
                new Language() { Name = "C#"},
                new Language() { Name = "JavaScript"},
                new Language() { Name = "Python"},
                new Language() { Name = "CSS"},
                new Language() { Name = "SQL"},
                new Language() { Name = "PHP"},
            };

            foreach (var language in languages)
            {
                context.Languages.Add(language);
            }

            context.SaveChanges();
        }

        private void SeedLabels(ApplicationDbContext context)
        {
            var Labels = new List<Label>()
            {
                new Label()
                {
                    Text = "bug"
                },
                new Label()
                {
                    Text = "funny"
                },
                new Label()
                {
                    Text = "jquery"
                },
                new Label()
                {
                    Text = "mysql"
                },
                new Label()
                {
                    Text = "useful"
                },
                new Label()
                {
                    Text = "web"
                },
                new Label()
                {
                    Text = "geometry"
                },
                new Label()
                {
                    Text = "back-end"
                },
                new Label()
                {
                    Text = "front-end"
                },
                new Label()
                {
                    Text = "games"
                }
            };

            foreach (var label in Labels)
            {
                context.Labels.Add(label);
            }

            context.SaveChanges();

        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var userToInsert = new User { UserName = "admin", Email = "admin@snippy.softuni.com" };
            userManager.Create(userToInsert, "adminPass123");

            userStore = new UserStore<User>(context);
            userManager = new UserManager<User>(userStore);
            userToInsert = new User { UserName = "someUser", Email = "someUser@example.com" };
            userManager.Create(userToInsert, "someUserPass123");

            userStore = new UserStore<User>(context);
            userManager = new UserManager<User>(userStore);
            userToInsert = new User { UserName = "newUser", Email = "new_user@gmail.com" };
            userManager.Create(userToInsert, "userPass123");
        }
    }
}
