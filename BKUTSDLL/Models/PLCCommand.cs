using BKUTSDLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKUTSDLL.Models
{
    public class PLCCommand
    {
        private readonly DatabaseService _dbService;

        public PLCCommand(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public void SendCommand(PLCBrand brand, string commandName)
        {
            var commands = _dbService.GetCommandsForBrand(brand);
            var command = commands.FirstOrDefault(c => c.CommandName == commandName);

            if (command == null)
            {
                throw new Exception("Komut bulunamadı !");
            }


            Console.WriteLine($"PLC Markası: {brand}, Komut: {command.CommandText}, Adres: {command.Address}");
        }
    }
}
