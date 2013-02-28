using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OfficeHelper;
using System.IO;

namespace ConsoleTest
{
    class OfficeHelperTest
    {
        public static void Test()
        {
            //string excelFile = @"D:\1.xlsx";
            string excelFile = @"D:\tmp002.xls";
            DataTable ds = ExcelHelper.LoadExcelDataToTable(excelFile, 1,2,1000,1,10);

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("id", typeof(string));
            DataColumn dc2 = new DataColumn("name",typeof(string));
            dt.Columns.Add(dc);
            dt.Columns.Add(dc2);

            foreach (DataRow dr in ds.Rows)
            {
                if (!string.IsNullOrEmpty(dr[0].ToString()))
                {
                    DataRow drn = dt.NewRow();
                    //drn[0] = int.Parse(dr[0].ToString());
                    //drn[1] = dr[1].ToString();

                    drn[0] = dr[2].ToString();
                    drn[1] = dr[5].ToString();
                    dt.Rows.Add(drn);
                }
            }
            //DataView dv = dt.DefaultView;
            //dv.Sort = "id";
            //dt = dv.ToTable();

            string[] t = { "Lcgrpcont", "Ldgrp", "Lpgrp", "Lpgrpcont", "Lcappntgrp" };
            using (StreamWriter sw = new StreamWriter(@"D:\3.txt"))
            {
                //组织SQL语句
                foreach (DataRow dr in dt.Rows)
                {
                    //string id = dr[0].ToString();
                    //string name = dr[1].ToString();
                    string code1 = dr[0].ToString();
                    string code2 = dr[1].ToString();
                    if (!string.IsNullOrEmpty(code1))
                    {
//                        string sql = @"INSERT INTO ldcode(codetype,code,codename,codealias,OPERATOR,makedate,maketime,modifydate,modifytime) 
// VALUES('businesstype','" + id + "','" + name + @"','团单投保单位性质','001',current_date,to_char(current_date,'hh24:mi:ss'),current_date,to_char(current_date,'hh24:mi:ss'));";

                        foreach (string strTable in t)
                        {
                            string sql = @"UPDATE " + strTable + " a SET a.Grpnature = '" + code2 + "' WHERE a.Grpnature = '" + code1 + "';";
                            sw.WriteLine(sql);
                            sw.WriteLine();
                        }
                    }
                }

                sw.Flush();
                sw.Close();
            }
        }
    }
}
