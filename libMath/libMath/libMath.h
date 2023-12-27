// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 LIBMATH_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// LIBMATH_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef LIBMATH_EXPORTS
#define LIBMATH_API __declspec(dllexport)
#else
#define LIBMATH_API __declspec(dllimport)
#endif

// 此类是从 dll 导出的
class LIBMATH_API ClibMath {
public:
    ClibMath();
    int Add(int a, int b);
    int Sub(int a, int b);
};

// 由于需要给C#调用，为了方便导出类，添加了函数进行导出，并且需要加extern "C"
extern "C" {
    LIBMATH_API ClibMath* CreateMyClass();

    LIBMATH_API void DeleteMyClass(ClibMath* obj);

    LIBMATH_API int CallAdd(ClibMath* obj, int num1, int num2);

    LIBMATH_API int CallSub(ClibMath* obj, int num1, int num2);
}