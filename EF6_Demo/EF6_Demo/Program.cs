using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailDatabaseContext ctx = new EmailDatabaseContext();
            List<EmailAddress> emails = new List<EmailAddress>();
            emails.Add(new EmailAddress()
            {
                EmailAddressName = "bela@kukac.kukac"
            });
            emails.Add(new EmailAddress()
            {
                EmailAddressName = "bela222@kukac.kukac"
            });
            ctx.Accounts.Add(new Account() { LoginName = "bela", Emails = emails });

            //azert allokalom ujra, hogy ne adja hozza Bela emailjeit, es egy tok ures lista legyen
            emails = new List<EmailAddress>();
            emails.Add(new EmailAddress()
            {
                EmailAddressName = "sanyi@kukac.kukac"
            });
            ctx.Accounts.Add(new Account() { LoginName = "sanyi", Emails = emails });
            ctx.SaveChanges();
        }
    }
}
