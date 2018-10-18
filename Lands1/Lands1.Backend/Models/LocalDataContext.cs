namespace Lands1.Backend.Models
{
    using Domain;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Lands1.Domain.User> Users { get; set; }
    }
}