using BKUTS_DLL.Models;
using BKUTS_DLL.Service;
using EasyModbus;
using Microsoft.Extensions.Configuration;

namespace BKUTS_DLL
{
    public class PLCCommandExucutor
    {
        private readonly IConfiguration _configuration;
        private readonly PLCCommand _plcCommand;
        private readonly ModbusClient Modbus = new ModbusClient();
        private CancellationTokenSource _cancellationTokenSource;      
        public event Action<bool[]> OnCoilsRead;
        public PLCCommandExucutor(IConfiguration configuration, PLCCommand plcCommand)
        {
            _configuration = configuration;
            _plcCommand = plcCommand;
        }


        public bool Connect(string ipAddress)
        {
            try
            {
                Modbus.IPAddress = ipAddress;
                Modbus.Connect();
                return Modbus.Connected;
            }
            catch (Exception ex)
            {
                throw new Exception($"PLC'ye bağlanılamadı: {ex.Message}");
            }
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
