namespace APIApplication
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrainContex : DbContext
    {
        public TrainContex()
            : base("name=TrainContex")
        {
        }

        public virtual DbSet<TrainTable> TrainTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainTable>()
                .Property(e => e.AdvertisedLocationName)
                .IsUnicode(false);
        }
    }
}
