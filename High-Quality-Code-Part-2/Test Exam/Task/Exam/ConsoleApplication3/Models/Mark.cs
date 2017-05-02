using System;
using SchoolSystem.Enums;

namespace SchoolSystem.Models
{
   public class Mark {
        private float valuation;
        private Subject subject;

        public Mark(Subject subject, float valuation) {
            this.Subject = subject;
            this.Valuation = valuation;
        }

        public float Valuation
        {
            get
            {
                return this.valuation;
            }

            set
            {
                if ((int)value < 2 && 6 < (int)value)
                {
                    throw new ArgumentOutOfRangeException("Valuation must be between 2 an 6");
                }
                this.valuation = value;
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
            }
        }
    }
}
