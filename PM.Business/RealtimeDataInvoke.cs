using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace PM.Business {
    
    /// <summary>
    /// 实时数据调用
    /// 
    /// </summary>
    public class RealtimeDataInvoke {


    }


    [Serializable]
    public class devvalue {
        public string POINTNUM;
        public string DEVICENUM;
        public string INSPECTOR;
        public string MEASURETIME;
        public string AI_Density;
        public string SW_Temperature;
        public string AF_FlowInstant;
        public string SW_Pressure;
        public string AT_Flow;
        public string MV1;
        public string MV2;
        public string MV3;
        public string MV4;
        public string MV5;
    }

    public class Share {
        public struct dev {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] POINTNUM;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] DEVICENUM;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] INSPECTOR;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] MEASURETIME;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] AI_Density;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] SW_Temperature;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] AF_FlowInstant;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] SW_Pressure;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] AT_Flow;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] MV1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] MV2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] MV3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] MV4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] MV5;
        }

        public class ShareMem {
            public ShareMem() {

            }
            ~ShareMem() {
                Close();
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr CreateFileMapping(int hFile, IntPtr lpAttributes, uint flProtect, uint dwMaxSizeHi, uint dwMaxSizeLow, string lpName);

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr OpenFileMapping(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)]bool bInheritHandle, string lpName);

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr MapViewOfFile(IntPtr hFileMapping, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern bool UnmapViewOfFile(IntPtr pvBaseAddress);

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern bool CloseHandle(IntPtr handle);

            [DllImport("kernel32", EntryPoint = "GetLastError")]
            public static extern int GetLastError();

            const int ERROR_ALREADY_EXISTS = 183;
            const int FILE_MAP_COPY = 0x0001;
            const int FILE_MAP_WRITE = 0x0002;
            const int FILE_MAP_READ = 0x0004;
            const int FILE_MAP_ALL_ACCESS = 0x0002 | 0x0004;
            const int PAGE_READONLY = 0x02;
            const int PAGE_READWRITE = 0x04;
            const int PAGE_WRITECOPY = 0x08;
            const int PAGE_EXECUTE = 0x10;
            const int PAGE_EXECUTE_READ = 0x20;
            const int PAGE_EXECUTE_READWRITE = 0x40;
            const int SEC_COMMIT = 0x8000000;
            const int SEC_IMAGE = 0x1000000;
            const int SEC_NOCACHE = 0x10000000;
            const int SEC_RESERVE = 0x4000000;
            const int INVALID_HANDLE_VALUE = -1;
            IntPtr m_hSharedMemoryFile = IntPtr.Zero;
            IntPtr m_pwData = IntPtr.Zero;
            bool m_bAlreadyExist = false;
            bool m_bInit = false;
            long m_MemSize = 0;

            public int Init(string strName, long lngSize) {
                if (lngSize <= 0 || lngSize > 0x00800000)
                    lngSize = 0x00800000;
                m_MemSize = lngSize;
                if (strName.Length > 0) {
                    m_hSharedMemoryFile = CreateFileMapping(INVALID_HANDLE_VALUE, IntPtr.Zero, (uint)PAGE_READWRITE, 0, (uint)lngSize, strName);
                    if (m_hSharedMemoryFile == IntPtr.Zero) {
                        m_bAlreadyExist = false;
                        m_bInit = false;
                        return 2;
                    }
                    else {
                        if (GetLastError() == ERROR_ALREADY_EXISTS) {
                            m_bAlreadyExist = true;
                        }
                        else {
                            m_bAlreadyExist = false;
                        }
                    }
                    m_pwData = MapViewOfFile(m_hSharedMemoryFile, FILE_MAP_WRITE, 0, 0, (uint)lngSize);
                    if (m_pwData == IntPtr.Zero) {
                        m_bInit = false;
                        CloseHandle(m_hSharedMemoryFile);
                        return 3;
                    }
                    else {
                        m_bInit = true;
                        if (m_bAlreadyExist == false) {

                        }
                        else {
                            return 1;
                        }
                    }
                }
                return 0;
            }

            public void Close() {
                if (m_bInit) {
                    UnmapViewOfFile(m_pwData);
                    CloseHandle(m_hSharedMemoryFile);
                }
            }

            public int Read(ref byte[] bytData, int lngAddr, int lngSize) {
                if (lngAddr + lngSize > m_MemSize)
                    return 2;
                if (m_bInit) {
                    Marshal.Copy(m_pwData, bytData, lngAddr, lngSize);
                }
                else {
                    return 1;
                }
                return 0;
            }

            public int Write(byte[] bytData, int lngAddr, int lngSize) {
                if (lngAddr + lngSize > m_MemSize)
                    return 2;
                if (m_bInit) {
                    Marshal.Copy(bytData, lngAddr, m_pwData, lngSize);
                }
                else {
                    return 1;
                }
                return 0;
            }
        }

        public devvalue GetRealData(string userid) {
            ShareMem sharmem = new ShareMem();
            dev devtemp = new dev();
            devvalue devlist = new devvalue();
            try {
                int ret = sharmem.Init(userid, Marshal.SizeOf(devtemp));
                if (ret == 0 || ret == 1) {
                    string strtdata = "";
                    byte[] databuffer = new byte[Marshal.SizeOf(devtemp)];
                    if (sharmem.Read(ref databuffer, 0, databuffer.Length) == 0) {
                        strtdata = Encoding.ASCII.GetString(databuffer, 0, databuffer.Length); ;
                    }
                    if (strtdata != "") {
                        string[] values = strtdata.Split('#');
                        if (values.Length > 0 && values.Length <= 15) {
                            devlist.POINTNUM = values[1];
                            devlist.DEVICENUM = values[2];
                            devlist.INSPECTOR = values[3];
                            devlist.MEASURETIME = values[4];
                            devlist.AI_Density = values[5];
                            devlist.SW_Temperature = values[6];
                            devlist.AF_FlowInstant = values[7];
                            devlist.SW_Pressure = values[8];
                            devlist.AT_Flow = values[9];
                            devlist.MV1 = values[10];
                            devlist.MV2 = values[11];
                            devlist.MV3 = values[12];
                            devlist.MV4 = values[13];
                            devlist.MV5 = values[14];
                        }
                    }
                }
            }
            catch {
            }
            return devlist;
        }
    }
}
