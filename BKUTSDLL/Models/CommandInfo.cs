using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKUTS_DLL.Models
{
    public class CommandInfo
    {
        public int Id { get; set; }
        public string CommandName { get; set; }
        public PLCBrand PlcBrand { get; set; }
        public string CommandText { get; set; }
        public string Address { get; set; }
        public string DataType { get; set; }
    }
}
