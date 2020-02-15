using System;
using GTSharp.Core.FTP;
using GTSharp;
using System.IO;

namespace GTSharpUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("命令说明");
            Console.WriteLine("其他:更新");
            Console.WriteLine("0   :上传");
            var w = Console.ReadLine();
            try
            {
                if (w != "0")
                {
                    Console.Title = "更新程序";
                    Console.WriteLine("开始更新");
                    Console.WriteLine("……");
                    // ftp://172.16.6.28/
                    FluentFTPHelper ftp1 = new FluentFTPHelper("172.16.6.28", "lysdlyy", "lysdlyy");
                    FluentFTPHelper ftp2 = new FluentFTPHelper("172.16.6.28", "gtsharp", "gtsharp");
                    FluentFTPHelper ftp3 = new FluentFTPHelper("172.16.6.28", "dpn48", "dpn48");
                    ClassCOM com = new ClassCOM();
                    var YYPath = Path.GetDirectoryName(Path.GetDirectoryName(com.GetPath()));
                    Console.WriteLine("更新目录位置");
                    Console.WriteLine(YYPath);
                    Console.WriteLine("……");
                    var path = Path.Combine(YYPath, @"GTSharp\Exe\LYSDLYY\");
                    var dpn48 = Path.Combine(YYPath, @"GTSharp\Exe\dpn48\");
                    Console.WriteLine("更新EXE");
                    ftp1.UpdateDownloadFile(path, "");
                    Console.WriteLine("更新DLL");
                    ftp2.UpdateDownloadFile(YYPath, "");
                    Console.WriteLine("更新框架");
                    ftp3.UpdateDownloadFile(dpn48, "");
                    Console.WriteLine("更新完成");
                    Console.WriteLine("……");
                }
                else
                {
                    Console.Title = "上传程序";
                    Console.WriteLine("开始上传");
                    Console.WriteLine("……");
                    // ftp://172.16.6.28/
                    FluentFTPHelper ftp1 = new FluentFTPHelper("172.16.6.28", "lysdlyy", "lysdlyy");
                    FluentFTPHelper ftp2 = new FluentFTPHelper("172.16.6.28", "gtsharp", "gtsharp");
                    ClassCOM com = new ClassCOM();
                    var gtsharp = @"D:\VS\GTSharp\GTSharp\bin\Debug\net20";
                    var lysdlyy = @"D:\VS\LYSDLYY\LYSDLYY\bin\Debug";
                    Console.WriteLine("上传目录位置");
                    Console.WriteLine(gtsharp);
                    Console.WriteLine(lysdlyy);
                    Console.WriteLine("……");
                    Console.WriteLine("上传LYSDLYY");
                    ftp1.UploadFile(lysdlyy);
                    Console.WriteLine("上传GTSharp");
                    ftp2.UploadFile(gtsharp);
                    Console.WriteLine("上传完成");
                    Console.WriteLine("……");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
	}
}