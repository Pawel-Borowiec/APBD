using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class Uczelnia
    {
        public DateTime createTime { get; set; }

        public string author { get; set; }
        public List<Student> studenci { get; set; }
        public List<activeStudy> activeStudies { get; set; }
    }
}
