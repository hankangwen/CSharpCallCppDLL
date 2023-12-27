// libMath.cpp : 定义 DLL 的导出函数。
//

#include "framework.h"
#include "libMath.h"

// 这是已导出类的构造函数。
ClibMath::ClibMath()
{
    return;
}

int ClibMath::Add(int a, int b)
{
    return a + b;
}

int ClibMath::Sub(int a, int b)
{
    return a - b;
}

LIBMATH_API ClibMath* CreateMyClass() {
    return new ClibMath();
}

LIBMATH_API void DeleteMyClass(ClibMath* obj) {
    delete obj;
}

LIBMATH_API int CallAdd(ClibMath* obj, int num1, int num2) {
    return obj->Add(num1, num2);
}

LIBMATH_API int CallSub(ClibMath* obj, int num1, int num2) {
    return obj->Sub(num1, num2);
}