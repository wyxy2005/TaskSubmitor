using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Office.Interop.Word;

namespace OfficeHelper
{
    public class WordHelper
    {
        //#region Parameters
        //private static Microsoft.Office.Interop.Word._Document MyDoc;
        //private static Microsoft.Office.Interop.Word._Application MyWord;
        //private static object Nothing = System.Reflection.Missing.Value;
        //#endregion

        //#region Share Methods

        private _Application wordApp;
        private _Document doc;
        private object oMissing = System.Reflection.Missing.Value;


        public WordHelper()
        {
            this.wordApp = new Microsoft.Office.Interop.Word.Application();
            oMissing = System.Reflection.Missing.Value;
        }

        public _Document Load(string fileFullName)
        {
            
            Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application(); ;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord.Visible = false;
            object fileName = fileFullName;
            oDoc = oWord.Documents.Open(ref fileName,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            return oDoc;
        }

        public void Save(_Document doc)
        {
            doc.Save();
        }

        public void SaveAs(_Document doc, string fileFullName)
        {
            doc.SaveAs(fileFullName, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, 
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }

        public void Close(_Document doc)
        {
            object missingValue = Type.Missing;
            object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            if (doc != null)
                doc.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
            if (this.wordApp != null)
                this.wordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
        }

        //private static _Document OpenWord(_Application wordApp,string templatePath)
        //{
        //    object Visible = false;
        //    object newTemp = false;
        //    wordApp = new Microsoft.Office.Interop.Word.Application();
        //    object templateFile = templatePath + "\\New.doc";
        //    try
        //    {
        //        return wordApp.Documents.Open(ref templateFile, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
        //                                    ref Nothing, ref Nothing, ref Visible, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //private static bool SaveWord(Microsoft.Office.Interop.Word._Document word,string savePath)
        //{
        //    object Visible = false;
        //    object filename = savePath + "\\King.doc";
        //    try
        //    {
        //        word.SaveAs(filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
        //                        ref Nothing, ref Nothing, ref Nothing, ref Visible, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
        //        CloseWord(MyDoc,MyWord);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        CloseWord(MyDoc, MyWord);
        //        return false;
        //    }
        //}

        //private static void CloseWord(Microsoft.Office.Interop.Word._Document word,Microsoft.Office.Interop.Word._Application wordApp)
        //{
        //    object missingValue = Type.Missing;
        //    object doNotSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
        //    if (word != null)
        //        word.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
        //    if (wordApp != null)
        //        wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
        //}

        //#endregion

        //#region Static Methods
        ///// <summary>
        ///// 根据Word文档内的BookMark添加数据
        ///// </summary>
        ///// <param name="dtSource"></param>
        ///// <param name="templatePath"></param>
        ///// <param name="savePath"></param>
        ///// <returns>是否保存成功</returns>
        //public static bool ExportWord(DataTable dtSource, string templatePath, string savePath)
        //{
        //    MyDoc = OpenWord(MyWord, templatePath);
        //    if (MyDoc != null)
        //    {
        //        foreach (Microsoft.Office.Interop.Word.Bookmark bm in MyDoc.Bookmarks)
        //        {
        //            bm.Select();
        //            switch (bm.Name)
        //            {
        //                case "书签名":
        //                    bm.Range.Text = 根据dtSource给书签赋值
        //                    break;
        //                ...
        //            }
        //        }
        //    }
        //    return SaveWord(MyDoc, savePath);
        //}

        //#endregion

        //#region Public Methods
        //#endregion
    }
}
    
