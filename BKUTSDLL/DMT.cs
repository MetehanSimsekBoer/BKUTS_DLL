using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DMTLIB
{
    public class DMT
    {
        //Communication control
        [DllImport("DMT.dll", EntryPoint = "OpenModbusSerial")]
        public static extern short OpenModbusSerial(short conn_num, short baud_rate, short data_len, char parity, short stop_bits, short modbus_mode);
        [DllImport("DMT.dll", EntryPoint = "CloseSerial")]
        public static extern void CloseSerial(short comport_num);
        [DllImport("DMT.dll", EntryPoint = "OpenModbusTCPSocket")]
        public static extern short OpenModbusTCPSocket(short conn_num, uint ipaddr);
        [DllImport("DMT.dll", EntryPoint = "CloseSocket")]
        public static extern void CloseSocket(int conn_num);
        //Data Request and Response
        [DllImport("DMT.dll",EntryPoint = "RequestData")]
        public static extern short RequestData(short comm_type, short conn_num, short station_addr, short func_code,  byte[] txbuf, short datalen);
        [DllImport("DMT.dll", EntryPoint = "ResponseData")]
        public static extern short ResponseData(short comm_type, short conn_num,ref short station_addr,ref short func_code,  ref byte rxbuf);
        //Communication status
        [DllImport("DMT.dll", EntryPoint = "GetLastSerialErr")]
        public static extern short GetLastSerialErr();
        [DllImport("DMT.dll", EntryPoint = "ResetSerialErr")]
        public static extern void ResetSerialErr();
        [DllImport("DMT.dll", EntryPoint = "GetLastSocketErr")]
        public static extern short GetLastSocketErr();
        [DllImport("DMT.dll", EntryPoint = "ReadSelect")]
        public static extern short ReadSelect(short conn_num, short time_ms);
        [DllImport("DMT.dll", EntryPoint = "ResetSocketErr")]
        public static extern void ResetSocketErr();

    }
}
