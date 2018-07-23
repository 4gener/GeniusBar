using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeniusBar.Models
{
    public class GeniusBarContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GeniusBarContext() : base("name=GeniusBarContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GENIUSBAR");          
        }

        public System.Data.Entity.DbSet<GeniusBar.Models.Authorization> Authorizations { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.Coupon> Coupons { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.LaptopBrand> LaptopBrands { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.LaptopModel> LaptopModels { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RecycleEvaluationCategory> RecycleEvaluationCategories { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RecycleEvaluationChoice> RecycleEvaluationChoices { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RecycleOrder> RecycleOrders { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RecycleOrder_RecycleEvaluatonChoice> RecycleOrder_RecycleEvaluatonChoice { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RepairCategory> RepairCategories { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RepairChoice> RepairChoices { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RepairOrder> RepairOrders { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.RepairOrder_RepairChoice> RepairOrder_RepairChoice { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.Role_Authorization> Role_Authorization { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.WebBanner> WebBanners { get; set; }

        public System.Data.Entity.DbSet<GeniusBar.Models.ServiceAddress> ServiceAddresses { get; set; }
    }
}
