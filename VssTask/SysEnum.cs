using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VssTask.SysEnum
{
    /// <summary>
    /// 需要更新提交的文件类型
    /// </summary>
    public enum FileType
    {

        SQL, /*需要提交的数据库相关类型文件 */

        Code,/*需要提交的代码文件，js，jsp，java等 */

        Doc  /*需要提交的其他项目设计，测试，管理文档  */
    }
}
