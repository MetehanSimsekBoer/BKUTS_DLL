using BKUTSDLL.Models;
using BKUTSDLL.Service;
using Microsoft.Extensions.Configuration;

namespace BKUTSDLL
{
    public class PLCCommandExucutor
    {
        private readonly IConfiguration _configuration;
        private readonly PLCCommand _plcCommand;
      
        public PLCCommandExucutor(IConfiguration configuration, PLCCommand plcCommand)
        {
            _configuration = configuration;
            _plcCommand = plcCommand;
        }
        public void ExecuteCommand(PLCBrand brand, string commandName)
        {
           

            try
            {
                _plcCommand.SendCommand(brand, commandName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}
