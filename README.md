> 本文由 [简悦 SimpRead](http://ksria.com/simpread/) 转码， 原文地址 [mp.weixin.qq.com](https://mp.weixin.qq.com/s/eUos92-heTjMVK7pfX5sNw)

**前言**

很多人说，C# 底层太难了，今天搞个简单点的。看下如何通过最简单的方式 C# 调用 C++ 写的 DLL。以 VS2022 为蓝本。  

**C++**
=======

首先新建一个具有导出项的 C++ DLL 动态链接库项目，用其它的项目新建，比如动态链接库 DLL 项目，或者空项目或有各种问题。打开 VS2022，选择如下图所示：  

![](https://mmbiz.qpic.cn/mmbiz_png/E2GaFRlbWh8iaDtzBgOVanfBcv2S8w7RYxib0WYWTEL438nx4RfL5uJDbrWgU7xLOvH0nibd5VlYqsI8FyTNDNXwQ/640?wx_fmt=png&from=appmsg)

取名叫 Dll1，项目建好了之后，结构如下图：

![](https://mmbiz.qpic.cn/mmbiz_png/E2GaFRlbWh8iaDtzBgOVanfBcv2S8w7RYMWqZ14tDfvDrWYGl4D3s3OoicqCy89L781ibMJA7ib1libQCx0cwdZAX8w/640?wx_fmt=png&from=appmsg)

右击源文件 -》添加 -》新建项 -》文件名: FileName.cpp，源文件文件夹下多了一个 FileName.cpp 的 C++ 文件。其它文件是默认创建的，不用管它。

![](https://mmbiz.qpic.cn/mmbiz_png/E2GaFRlbWh8iaDtzBgOVanfBcv2S8w7RYNRumrelk1rR9G7Kib5lq8n2uHJcbNzqxp8k4UcpYCHgBiax40xhRAxZQ/640?wx_fmt=png&from=appmsg)

FileName.cpp 添加如下代码  

```
#include "pch.h"


extern "C" __declspec(dllexport) int Add(int x, int y)
{
#ifdef _DEBUG
  return x;
#else
  return y;
#endif
}
```

把 Dll1 项目生成下，.../x64/Debug 目录下找到 Dll1.dll。就是生成好的 C++ DLL 了。不需要任何设置。
===================================================================

**C#**
======

新建一个 C# 控制台应用程序，代码如下：

```
namespace ConsoleApp1
{
    public class Test
    {
        [DllImport("E:\\Visual Studio Project\\Test_\\x64\\Debug\\Dll1.dll")]
        public static extern int Add(int a, int b);

        internal class Program
        { 
            static void Main(string[] args)
            {
                Console.WriteLine(Add(33, 2));            
                Console.ReadLine();
            }
        }
    }
}
```

DllImport 里面包含的即是上面 C++ 生成的 Dll1 的路径。

调用结果如下：  

![](https://mmbiz.qpic.cn/mmbiz_png/E2GaFRlbWh8iaDtzBgOVanfBcv2S8w7RYHkULLjyQ9Tc7oczuicouYeeQGqSGibzfxZFS9eUR8iaMicWV0M0CumA1eA/640?wx_fmt=png&from=appmsg)

以上为最简单的 C# 调用 C++ DLL 的过程，全程不需要任何库文件，以及编译方面的设置

