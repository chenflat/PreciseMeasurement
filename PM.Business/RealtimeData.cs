using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace PM.Business {



    public class RealtimeData {

        public static object GetRealtimeData(string devicenum) {
            object data = null;
            Object share = RealtimeDataProvider.GetShareInstance();
            MethodInfo method = RealtimeDataProvider.GetShareType().GetMethod("GetRealData");
            object[] paramters = new object[] { devicenum };
            if (method != null) {
                data = method.Invoke(share, paramters);
            }
            return data;
        }




        public static void LoadDll() {
            Assembly SampleAssembly;
            SampleAssembly = Assembly.LoadFrom("E:\\Debug\\ShareData.dll");
            // Obtain a reference to a method known to exist in assembly.
          //  MethodInfo Method = SampleAssembly.GetTypes()[1].GetMethod("GetRealData");
            // Obtain a reference to the parameters collection of the MethodInfo instance.
          //  ParameterInfo[] Params = Method.GetParameters();
            // Display information about method parameters.
            // Param = sParam1
            //   Type = System.String
            //   Position = 0
            //   Optional=False
            //foreach (ParameterInfo Param in Params) {
            //    Console.WriteLine("Param=" + Param.Name.ToString());
            //    Console.WriteLine("  Type=" + Param.ParameterType.ToString());
            //    Console.WriteLine("  Position=" + Param.Position.ToString());
            //    Console.WriteLine("  Optional=" + Param.IsOptional.ToString());
            //}

            //迭代类型
            Type[] types = SampleAssembly.GetTypes();
            foreach (Type type in types) {
                if (type.FullName == "ShareData.Share") {
                    Object share = Activator.CreateInstance(type);
                    MethodInfo method = type.GetMethod("GetRealData");
                    object[] paramters = new object[] { "121" };
                    if(method!=null) {
                       object data = method.Invoke(share, paramters);
                    }

                }
            }
            

        
        }

        


    }
}
