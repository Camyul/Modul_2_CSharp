using System;
using SchoolSystem.Enums;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models
{
   public class Mark : IMarks
    {
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
                if (value < 2.0f || value > 6.0f)
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
