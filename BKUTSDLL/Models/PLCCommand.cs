using BKUTS_DLL.Services;
using BKUTSDLL.Service;
using EasyModbus;
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
                throw new Exception("Komut bulunamadı !!");
            }

            try
            {
                var plcService = new PLCService("192.168.0.83", 502);
                plcService.Connect();
                if (commandName == "Start")
                {
                    Console.WriteLine("Start komutu gönderiliyor");

                    plcService.WriteCoil(0, true);

                    Console.WriteLine("Start komutu başarılı");
                }
                else if (commandName == "Stop")
                {
                    Console.WriteLine("Stop komutu gönderiliyor");

                    plcService.WriteCoil(1, false);
                    Console.WriteLine("Stop komutu başarılı");
                }

                //Aşağıdaki kod bloğu şimdilik test sürecinde
                //Console.WriteLine("PLC durumu okunuyor");
                //int[] registers = plcService.ReadRegisters(151, 16);
                //Console.WriteLine("Okunan değerler:");
                //foreach (var value in registers){
                //    Console.WriteLine(value);
                //}

           
                plcService.Disconnect();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata --> : {ex.Message}");
            }

           
            Console.WriteLine($"PLC Markası: {brand}, Komut: {command.CommandText}, Adres: {command.Address}");
        }
    }
}
