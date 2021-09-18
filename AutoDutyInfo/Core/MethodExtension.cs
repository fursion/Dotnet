using System;
using System.Windows.Forms;
public static class MethodExtension
{
    /// <summary>
    /// 对TextBox添加新的行，并添加文本
    /// </summary>
    /// <param name="textBox"></param>
    /// <param name="text"></param>
    public static void NewLine(this TextBox textBox, string text)
    {
        if (null != textBox)
        {
            if (textBox.Lines.Length > 0)
                textBox.AppendText("\r\n");
            textBox.AppendText(text);
        }
    }
    /// <summary>
    /// 对TextBox添加新的行
    /// </summary>
    /// <param name="textBox"></param>
    public static void NewLine(this TextBox textBox)
    {
        if (null != textBox)
            textBox.AppendText("\r\n");
    }
}