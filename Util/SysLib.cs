using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Util
{
    /// <summary>
    /// 系统工具
    /// 辅助FCL库，定制本地化操作
    /// 
    /// 作者：ChengNing
    /// 日期：2012-12-06
    /// </summary>
    public static class SysLib
    {
        /// <summary>
        /// 将DataTable指定列转化为string的List
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="tableColumn">列索引，从0开始</param>
        /// <returns></returns>
        public static IList<string> TableToList(DataTable dtb,int tableColumn)
        {
            if (dtb == null || dtb.Rows.Count == 0)
                return null;
            IList<string> colList = new List<string>();
            foreach (DataRow dr in dtb.Rows)
            {
                colList.Add(dr[tableColumn].ToString());
            }
            return colList;
        }

        /// <summary>
        /// 将DataTable指定列转化为string的List
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="columnName">列名称</param>
        /// <returns></returns>
        public static IList<string> TableToList(DataTable dtb, string columnName)
        {
            if (dtb == null || dtb.Rows.Count == 0)
                return null;
            IList<string> colList = new List<string>();
            foreach (DataRow dr in dtb.Rows)
            {
                colList.Add(dr[columnName].ToString());
            }
            return colList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static DataTable RemoveSubTable(DataTable dtb,int startIndex, int count)
        {
            if (dtb == null || dtb.Rows.Count == 0)
                return null;
            for (int i = startIndex; i < count; i++)
            {
                dtb.Rows.RemoveAt(startIndex);
            }
            return dtb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static DataTable RemoveSubTable(DataTable dtb,int startIndex)
        {
            return RemoveSubTable(dtb, startIndex, dtb.Rows.Count - startIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static DataTable SubTable(DataTable dtb,int startIndex, int count)
        {
            if (dtb == null || dtb.Rows.Count == 0)
                return null;
            DataTable dtbResult = dtb.Clone();
            for (int i = startIndex; i < count; i++)
            {
                dtbResult.ImportRow(dtb.Rows[i]);
            }
            return dtbResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static DataTable SubTable(DataTable dtb,int startIndex)
        {
            return SubTable(dtb, startIndex, dtb.Rows.Count - startIndex);
        }




    }//end class
}//end namespace
