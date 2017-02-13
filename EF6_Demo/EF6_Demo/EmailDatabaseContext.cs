using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_Demo
{
    public class EmailDatabaseContext : DbContext
    {
        public EmailDatabaseContext() : base("EmailDatabaseContext") { }

        static EmailDatabaseContext()
        {
            Database.SetInitializer(new DbInitializer());
            using (EmailDatabaseContext db = new EmailDatabaseContext())
            {
                db.Database.Initialize(false);
            }
        }
        //tablak:
        public DbSet<Account> Accounts { get; set; }
        public DbSet<EmailAddress> Emails { get; set; }
    }

    public class DbInitializer : DropCreateDatabaseAlways<EmailDatabaseContext>
    {
        protected override void Seed(EmailDatabaseContext context)
        {
            base.Seed(context);
        }
    }
}
