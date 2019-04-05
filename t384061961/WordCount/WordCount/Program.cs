using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = ""; //  存储用户命令
            while (message != "exit")
            {
                Console.Write("wc.exe ");
                // 得到输入命令
                message = Console.ReadLine();
                message = message.Trim(' ');
                message = message.Trim('\t');
                // 分割命令
                 if(message == "")
                {
                     Console.WriteLine("请输入命令！！");
                     continue;
                }
               string[] arrMessSplit = message.Split(' ');
               int iMessLength = arrMessSplit.Length;
               if(arrMessSplit.Length < 2)
                {
                    if(arrMessSplit[0].Length > 2)
                        Console.WriteLine("请输入正确格式命令！！");
                    Console.WriteLine("请输入路径！！");
                    continue;
                }
               string[] sParameter = new string[iMessLength - 1];
                bool isComeTrue = true;
               // 获取命令参数
               for (int i = 0; i < iMessLength - 1; i++)
               {
                    sParameter[i] = arrMessSplit[i];
                    if (sParameter[i].Length >2)
                    {
                        Console.WriteLine("请输入正确格式命令！！");
                        isComeTrue = false;break;
                    }
               }
               if (isComeTrue)
               {
                    // 获取文件名
                    string sFilename = arrMessSplit[iMessLength - 1];
                    // 新建处理类
                    WC newwc = new WC(sParameter);
                    newwc.Order(sFilename);
               }
           }
        }
    }
}
