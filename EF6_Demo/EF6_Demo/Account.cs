using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_Demo
{
    public class Account
    {
        public Account()
        {
            this.Emails = new List<EmailAddress>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string LoginName { get; set; }

        [Required]
        public virtual IList<EmailAddress> Emails { get; set; }
    }
}
