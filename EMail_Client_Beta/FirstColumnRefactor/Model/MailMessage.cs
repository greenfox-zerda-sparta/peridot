using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMail_Client_Beta.Model
{
    public class MailMessage : ObservableObject
    {
        private string from;
        private string to;
        private string subject;
        private string date;
        private string bodyText;

        public string From
        {
            get
            {
                return from;
            }

            set
            {
                Set(() => From, ref from, value);
            }
        }

        public string To
        {
            get
            {
                return to;
            }

            set
            {
                Set(() => To, ref to, value);
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                Set(() => Subject, ref subject, value);
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                Set(() => Date, ref date, value);
            }
        }

        public string BodyText
        {
            get
            {
                return bodyText;
            }

            set
            {
                Set(() => BodyText, ref bodyText, value);
            }
        }
    }
}
