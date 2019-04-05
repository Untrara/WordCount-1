using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class WC
    {
        private string sFilename;    // 文件名
        private string sEnlarge;   //扩展名格式
        private string[] sParameter; // 参数数组  
        private int iCharcount = 0;      // 字符数
        private int iWordcount = 0;      // 单词数
        private int iLinecount = 0;      // 行  数
        private int iNullLinecount = 0;  // 空行数
        private int iCodeLinecount = 0;  // 代码行数
        private int iNoteLinecount = 0;  // 注释行数
        public string str1;
        public WC(string[] sParameter)
        {
            this.sParameter = sParameter;
        }
        
        // 统计基本信息：字符数 单词数 行数
        public void BaseCount(string Filename) 
        {
            try
            {
                // 打开文件
                FileStream file = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(file);
                int nChar;
                int charcount = 0;
                int wordcount = 0;
                int linecount = 0;
                //定义一个字符数组
                char[] symbol = { ' ', ',', '.', '?', '!', ':', ';', '\'', '\"', '\t', '{', '}', '(', ')', '+' ,'-',
                  '*', '='};
                while ((nChar = sr.Read()) != -1)
                {
                    charcount++;     // 统计字符数

                    foreach (char c in symbol)
                    {
                        if (nChar == (int)c)
                        {
                            wordcount++; // 统计单词数
                        }
                    }
                    if (nChar == '\n')
                    {
                        linecount++; // 统计行数
                    }
                }
                iCharcount = charcount;
                iWordcount = wordcount + 1;
                iLinecount = linecount + 1;
                sr.Close();

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        // 统计高级信息：空行数 代码行数 注释行数
        public void SuperCount(string Filename)
        {
            try
            {
                // 打开文件
                FileStream file = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(file);
                String line;
                int nulllinecount = 0;
                int codelinecount = 0;
                int notelinecount = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim(' ');
                    line = line.Trim('\t');
                    //   空行
                    if (line == "" )
                    {
                        nulllinecount++;
                    }
                    //   注释行
                    if (line.Contains("//"))
                    {
                        notelinecount++;
                    }
                    // 代码行
                    else
                    {
                        codelinecount++;
                    }
                }
                iNullLinecount = nulllinecount;
                 iCodeLinecount = codelinecount;
                iNoteLinecount = notelinecount;
                sr.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public string Order(string sFilename)
        {
            this.sFilename = sFilename;
            if (sFilename.Contains("*."))
            {
                sEnlarge = sFilename.Replace("*", "");
                Console.WriteLine(sFilename);
            }
            else {
                try
                {
                    // 打开文件
                    FileStream file = new FileStream(sFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                    StreamReader sr = new StreamReader(file);
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (IOException ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    Console.WriteLine("请输入正确的文件路径或文件格式！！");
                    return "";
                }
            }
            string retrun_str = "";
            foreach (string s in sParameter)
            {
                if (s == "-c")
                {
                    SuperCount(sFilename);
                    BaseCount(sFilename);
                    retrun_str = Display();
                    
                }
                else if (s == "-w")
                {
                    SuperCount(sFilename);
                    BaseCount(sFilename);
                    retrun_str = Display();
                    //Console.WriteLine("   单词个数为： " + iWordcount);
                    
                }
                else if (s == "-l")
                {
                    SuperCount(sFilename);
                    BaseCount(sFilename);
                    retrun_str = Display();
                    //Console.WriteLine("   总的行数为： " + iLinecount);
                    
                }
                else if (s == "-a") //返回（代码行 / 空行 / 注释行）
                {
                    SuperCount(sFilename);
                    BaseCount(sFilename);
                    retrun_str = Display();
                }
                else if (s == "-s")//递归处理目录下符合条件的文件
                {
                    string str = "D:\\Patch" ;
                    GetAllDirList(str);
                    if(list.Count>0)
                    {
                        for(int i = 0; i < list.Count; i++)
                        {
                            BaseCount(list[i]);
                            SuperCount(list[i]);
                            retrun_str = retrun_str + list[i] + "\n";
                            retrun_str = DisplayAll(retrun_str);
                        }
                    }
                    else
                        retrun_str ="目录 ："+ str + " 中没有此格式的文件！！" ;
                    break;
                }
                else
                {
                    retrun_str = "  非法命令！！";
                }
                
            }
            Console.WriteLine(retrun_str);
            return retrun_str;
        }
        public string Display()
        {
            string return_str = "";
            foreach (string s in sParameter)
            {
                 if (s == "-c")
                {
                    return_str += "字符数   ：" + iCharcount.ToString()+"\n";
                }
                else if (s == "-w")
                {
                    return_str += "单词数   ：" + iWordcount.ToString() + "\n";
                }
                else if (s == "-l")
                {
                    return_str += "总行数   ：" + iLinecount.ToString() + "\n";
                }
                else if (s == "-a")
                {
                    return_str += "空行数   ：" + iNullLinecount.ToString() + "\n";
                    return_str += "代码行数 ：" + iCodeLinecount.ToString() + "\n";
                    return_str += "注释行数 ：" + iNoteLinecount.ToString() + "\n";
                }
                //else if(s == "-s")
            }
            return return_str;
        }
        private string DisplayAll(string return_str)
        {

                return_str += "字符数   ：" + iCharcount.ToString() +"\n";
                return_str += "单词数   ：" + iWordcount.ToString() + "\n";
                return_str += "总行数   ：" + iLinecount.ToString() + "\n";
                return_str += "空行数   ：" + iNullLinecount.ToString() + "\n";
                return_str += "代码行数 ：" + iCodeLinecount.ToString() + "\n";
                return_str += "注释行数 ：" + iNoteLinecount.ToString() + "\n" + "\n";

            return return_str;
        }
        
        List<string> list = new List<string>();
        private void GetAllDirList(string strBaseDir)//递归查看目录
        {
            DirectoryInfo di = new DirectoryInfo(strBaseDir);
            DirectoryInfo[] diA = di.GetDirectories();

            DirectoryInfo d = new DirectoryInfo(strBaseDir);
            FileInfo[] files = d.GetFiles();
            string fileName;
            for (int i = 0; i < files.Length; i++)
            {
                fileName = files[i].Name.ToLower();
                if (fileName.EndsWith(sEnlarge))
                {
                    list.Add(strBaseDir+"\\"+fileName);
                    //Console.WriteLine(strBaseDir + "\\" + fileName);
                }
            }
            for (int i = 0; i < diA.Length; i++)
            {
                //al.Add(diA[i].FullName);
                //Console.WriteLine(diA[i].FullName);
                //diA[i].FullName是某个子目录的绝对地址，把它记录在ArrayList中
                GetAllDirList(diA[i].FullName);
            }
            
        }

    }
}
