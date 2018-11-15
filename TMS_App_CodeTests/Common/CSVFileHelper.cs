using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.IO;

namespace TMS_App_CodeTests.Common
{
    public static class CSVFileHelper
    {
        public static DataTable OpenCSV(string filePath)
        {
            //Encoding encoding = Common.GetType(filePath); //Encoding.ASCII;// 
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));
            //StreamReader sr = new StreamReader(fs, encoding); 
            //string fileContent = sr.ReadToEnd(); 
            //encoding = sr.CurrentEncoding; 
            //记录每次读取的一行记录 
            string strLine = "";
            //记录每行记录中的各字段内容 
            string[] aryLine = null; string[] tableHead = null;
            //标示列数 
            int columnCount = 0;
            //标示是否是读取的第一行 
            bool IsFirst = true;
            //逐行读取CSV中的数据 
            while ((strLine = sr.ReadLine()) != null)
            {
                //strLine = Common.ConvertStringUTF8(strLine, encoding); 
                //strLine = Common.ConvertStringUTF8(strLine); 
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false; columnCount = tableHead.Length;
                    //创建列 
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }
            sr.Close();
            fs.Close();
            return dt;
        }
    }
}
