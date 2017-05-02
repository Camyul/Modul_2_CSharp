using SchoolSystem.Enums;
using System;

namespace SchoolSystem.Models
{ 
   public class Mark {
        public Mark(Subject sbj, float va) {
            subject = sbj;
            value = va;
        }
        internal float value;
        internal Subject subject;
    }
}
