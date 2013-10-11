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
            Test2();
        }

        public static void Test1()
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

        public static void Test2()
        {
            //string excelFile = @"D:\1.xlsx";
            string excelFile = @"D:\tmp003.xls";
            string excelFile1 = @"D:\tmp005.xls";
            string excelFile2 = @"D:\tmp004.xls";

            
            DataTable ds = ExcelHelper.LoadExcelDataToTable(excelFile, 1, 2, 1000, 1, 10);
            DataTable ds1 = ExcelHelper.LoadExcelDataToTable(excelFile1, 1, 2, 1000, 1, 10);
            DataTable ds2 = ExcelHelper.LoadExcelDataToTable(excelFile2, 1, 2, 1000, 1, 10);


            string[] t = { "Lcgrpcont", "Ldgrp", "Lpgrp", "Lpgrpcont" };
            using (StreamWriter sw = new StreamWriter(@"D:\4.txt"))
            {
                //组织SQL语句
                foreach (DataRow dr in ds.Rows)
                {
                    //string id = dr[0].ToString();
                    //string name = dr[1].ToString();
                    string name = dr[2].ToString();
                    string unit = dr[7].ToString();
                    unit = unit.Replace("私营企业", "私有");
                    unit = unit.Replace("民营企业", "个体");
                    DataRow[] findrow1 = ds1.Select("column4 = '" + unit + "' or column4 = '" + unit.Replace("企业","") + "'");
                    string unitCode = " $$$" + unit;
                    if (findrow1.Length > 0)
                    {
                        unitCode = findrow1[0][2].ToString();
                    }

                    string bussi = dr[8].ToString();
                    bussi = bussi.Replace("建筑业", "房屋和土木工程建筑业");
                    bussi = bussi.Replace("建筑工程", "房屋和土木工程建筑业");
                    bussi = bussi.Replace("金融业", "银行业");
                    bussi = bussi.Replace("卫生、社会保障和社会福利业", "卫生");
                    bussi = bussi.Replace("信息传输、计算机服务和软件业", "计算机服务业");
                    bussi = bussi.Replace("一般买卖（零售批发业）", "零售业");
                    bussi = bussi.Replace("一般职业", "零售业");
                    bussi = bussi.Replace("制造加工维修业", "家具制造业");
                    bussi = bussi.Replace("公共事业", "其他服务业");
                    bussi = bussi.Replace("医药卫生保健", "卫生");
                    bussi = bussi.Replace("公检法等执法检查机关", "国家机构");
                    bussi = bussi.Replace("文化、体育和娱乐业", "娱乐业");
                    DataRow[] findrow2 = ds2.Select("column4 = '" + bussi + "' or column4 = '" + bussi.Replace("企业", "") + "'");
                    string bussiCode = " $$$" + bussi;
                    if (findrow2.Length > 0)
                    {
                        bussiCode = findrow2[0][2].ToString();
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        sw.WriteLine(@"INSERT INTO bak_Lcgrpcont SELECT pgi_bak_seq.NEXTVAL,'chengning',Sysdate,'update','ABLREQUEST-1536', a.* FROM Lcgrpcont a WHERE a.grpname = '" + name + "';");
                        sw.WriteLine(@"UPDATE Lcgrpcont a SET a.grpnature = '" + unitCode + "', a.businesstype = '" + bussiCode + "',modifydate = trunc(current_date),modifytime = to_char(current_date,'hh24:mi:ss')   WHERE a.grpname = '" + name + "';");

                        sw.WriteLine(@"INSERT INTO bak_Ldgrp SELECT pgi_bak_seq.NEXTVAL,'chengning',Sysdate,'update','ABLREQUEST-1536', a.* FROM Ldgrp a WHERE a.grpname = '" + name + "';");
                        sw.WriteLine(@"UPDATE Ldgrp a SET a.grpnature = '" + unitCode + "', a.businesstype = '" + bussiCode + "',modifydate = trunc(current_date),modifytime = to_char(current_date,'hh24:mi:ss')  WHERE a.grpname = '" + name + "';");

                        sw.WriteLine(@"INSERT INTO bak_Lpgrp SELECT pgi_bak_seq.NEXTVAL,'chengning',Sysdate,'update','ABLREQUEST-1536', a.* FROM Lpgrp a WHERE a.grpname = '" + name + "';");
                        sw.WriteLine(@"UPDATE Lpgrp a SET a.grpnature = '" + unitCode + "', a.businesstype = '" + bussiCode + "' ,modifydate = trunc(current_date),modifytime = to_char(current_date,'hh24:mi:ss') WHERE a.grpname = '" + name + "';");

                        sw.WriteLine(@"INSERT INTO bak_Lpgrpcont SELECT pgi_bak_seq.NEXTVAL,'chengning',Sysdate,'update','ABLREQUEST-1536', a.* FROM Lpgrpcont a WHERE a.grpname = '" + name + "';");
                        sw.WriteLine(@"UPDATE Lpgrpcont a SET a.grpnature = '" + unitCode + "', a.businesstype = '" + bussiCode + "' ,modifydate = trunc(current_date),modifytime = to_char(current_date,'hh24:mi:ss') WHERE a.grpname = '" + name + "';");
                        sw.WriteLine();
                    }
                }

                sw.Flush();
                sw.Close();
            }
        }


        public static DataTable ExcelToTable(string excelFile, int col) 
        {
            DataTable ds = ExcelHelper.LoadExcelDataToTable(excelFile, 1, 2, 1000, 1, 10);

            DataTable dt = new DataTable();
            for (int i = 0; i < col; ++i)
            {
                DataColumn dc = new DataColumn("col" + i, typeof(string));
                dt.Columns.Add(dc);
            }
            return dt;
        }
    }
}
