using SchoolSystem.Enums;
using System;

namespace SchoolSystem
{ 
    class Mark {
        public Mark(Subject sbj, float va) {
            subject = sbj;
            value = va;
        }
        internal float value;
        internal Subject subject;
    }
}
