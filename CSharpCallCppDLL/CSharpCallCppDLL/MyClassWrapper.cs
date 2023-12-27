using System;
using System.Runtime.InteropServices;

namespace CSharpCallCppDLL
{
    /// <summary>
    /// 在 C# 中可以创建一个对应 C++ 类的 C# 包装类，
    /// 使用 DllImport 属性声明导出函数，例如下面的代码：
    /// </summary>
    public class MyClassWrapper : IDisposable
    {
        private IntPtr myClassInstance;

        [DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateMyClass();

        [DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteMyClass(IntPtr obj);

        //[DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        //private static extern void CallMyMethod(IntPtr obj);

        [DllImport("libMath.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CallAdd(IntPtr obj, int num1, int num2);

        public MyClassWrapper()
        {
            myClassInstance = CreateMyClass();
        }

        //~MyClassWrapper()
        //{
        //    Console.WriteLine("~MyClassWrapper()");
        //    DeleteMyClass(myClassInstance);
        //}

        //public void MyMethod()
        //{
        //    CallMyMethod(myClassInstance);
        //}

        public int CallAdd(int num1, int num2)
        {
            return CallAdd(myClassInstance, num1, num2);
        }

        public void Dispose()
        {
            //充当析构函数
            Console.WriteLine("MyClassWrapper Dispose");
            DeleteMyClass(myClassInstance);
        }
    }
}
