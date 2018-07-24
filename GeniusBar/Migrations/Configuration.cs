
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GeniusBar.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GeniusBar.Models.GeniusBarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}