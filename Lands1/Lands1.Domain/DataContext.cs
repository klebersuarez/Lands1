namespace Lands1.Domain
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConecction")
        {

        }
    }
}
