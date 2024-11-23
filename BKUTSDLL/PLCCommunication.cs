using DMTLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BKUTS_DLL
{
    public class PLCCommunication
    {
        private short slav_addr_r;
        private short func_code_r;
        byte[] sendbuf = new byte[4];       

        public bool OpenConnection(short connNum, uint ipAddress)
        {
            try
            {
              
                int status = DMT.OpenModbusTCPSocket(connNum, ipAddress);
                if (status == -1)
                {
                  
                    return false;
                }

               
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bağlantı hatası: {ex.Message}");
                return false;
            }
        }

        public void CloseConnection(int connNum)
        {
            try
            {
               
                DMT.CloseSocket(connNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bağlantı kapatılırken hata oluştu: {ex.Message}");
            }
        }

        public void SendData(short commType, short connNum, short stationAddr, short funcCode, short dataLen)
        {
            sendbuf[0] = 0x08;
            sendbuf[1] = 0x00;
            sendbuf[2] = 0xFF;
            sendbuf[3] = 0x00;
            DMT.RequestData(commType, connNum, stationAddr, funcCode, sendbuf, dataLen);
        }

        public int ReceiveData(short commType, short connNum, ref short stationAddr, ref short funcCode, ref byte buffer)
        {
            return DMT.ResponseData(commType, connNum, ref stationAddr, ref funcCode, ref buffer);
        }
    }
}

