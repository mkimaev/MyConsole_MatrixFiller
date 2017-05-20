using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Matix_Filler
{
    class OwnException : Exception
    {
        public override string HelpLink { get; set; } = "https://github.com/mkimaev/MyConsole_MatrixFiller.git";

        public OwnException(string message) : base (message) {}
    }
}
