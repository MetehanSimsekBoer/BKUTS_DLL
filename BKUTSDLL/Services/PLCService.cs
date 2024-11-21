using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BKUTS_DLL.Services
{
    class PLCService
    {
        ModbusClient _modbusClient = new ModbusClient();

        public PLCService(string ipAddress, int port) {

            _modbusClient = new ModbusClient(ipAddress, port);
        }

        public void Connect()
        {
            if (!_modbusClient.Connected)
            {
                _modbusClient.Connect();
                Console.WriteLine("PLC ile bağlantı kuruldu");
            }
        }

        public void Disconnect()
        {
            if (_modbusClient.Connected)
            {
                _modbusClient.Disconnect();
                Console.WriteLine("PLC bağlantısı kapatıldı.");
            }
        }

        public void WriteCoil(int address, bool value)
        {
            _modbusClient.WriteSingleCoil(address, value);
            Console.WriteLine($"Coil adresine yazıldı: Adres={address}, Değer={value}");


        }

        public int[] ReadRegisters(int startAddress, int quantity)
        {
            return _modbusClient.ReadHoldingRegisters(startAddress, quantity);
        }
    }
}
