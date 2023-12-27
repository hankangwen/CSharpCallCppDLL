using System;
using System.Runtime.InteropServices;

/*
C# 调用 C++ dll 
将libMath.dll放到CSharpCallCppDLL/bin/Debug目录下
*/
namespace CSharpCallCppDLL
{
    internal class Program
    {
        private static IntPtr myClassInstance;  // 定义C++类的实例，用于后面的调用

        [DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateMyClass();

        [DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteMyClass(IntPtr obj);

        [DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CallAdd(IntPtr obj, int num1, int num2);

        [DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CallSub(IntPtr obj, int num1, int num2);

        static void Main(string[] args)
        {
            Console.WriteLine("测试C#调用C++");

            myClassInstance = CreateMyClass();
            int nRet = CallAdd(myClassInstance, 1, 2);
            Console.WriteLine($"1 + 2 = {nRet}");
            // 清理C++内存
            DeleteMyClass(myClassInstance);

            using (MyClassWrapper myInstance = new MyClassWrapper())
            {
                int nRet2 = myInstance.CallAdd(1, 2);
                Console.WriteLine($"1 + 2 = {nRet2}");
            }

            Console.ReadLine();
        }
    }
}
