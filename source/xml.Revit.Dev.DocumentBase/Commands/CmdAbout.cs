/* 作    者: xml
** 创建时间: 2024/6/2 13:42:14
**
** Copyright 2024 by zedmoster
** Permission to use, copy, modify, and distribute this software in
** object code form for any purpose and without fee is hereby granted,
** provided that the above copyright notice appears in all copies and
** that both that copyright notice and the limited warranty and
** restricted rights notice below appear in all supporting
** documentation.
*/

using System.Diagnostics;

namespace xml.Revit.Dev.DocumentBase.Commands
{
    /// <summary>
    /// 关于
    /// </summary>
    [XmlHelpUrl("https://mp.weixin.qq.com/s/Y9ZiOBsHAfOB-JavjT_IgQ")]
    [Xml("关于", Application._tooltip, Application._description)]
    [Transaction(TransactionMode.Manual)]
    public sealed class CmdAbout : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements
        )
        {
            TaskDialog mainDialog =
                new("关于")
                {
                    MainInstruction = "关于使用",
                    MainContent =
                        "搜索微信小程序:Revit二次开发教程\n"
                        + "点击下方<复制ID到剪贴板>后在小程序内输入ID\n"
                        + "每日签到后即可免费使用",
                };
            mainDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "复制ID到剪贴板");
            mainDialog.CommonButtons = TaskDialogCommonButtons.None;
            mainDialog.DefaultButton = TaskDialogResult.None;

            TaskDialogResult tResult = mainDialog.Show();
            if (TaskDialogResult.CommandLink1 == tResult)
            {
                Debug.WriteLine(XmlDoc.Guid);
                System.Windows.Clipboard.SetDataObject(XmlDoc.Guid);
                XmlDoc.ShowBalloon("搜索微信小程序:Revit二次开发教程\n签到免费使用");
            }

            return Result.Succeeded;
        }
    }
}
