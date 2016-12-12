using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MapleShark
{
    public partial class DummyOutputWindow : DockContent
    {
        public DummyOutputWindow()
        {
            InitializeComponent();
            mTextBox.AppendText("\n");
        }

        public DummyOutputWindow(string pTitle)
        {
            InitializeComponent();
            Text = pTitle;
            mTextBox.AppendText("\n");
        }

        public void Append(string pOutput) { LogError(pOutput+"\r\n--------------------------------------------------------------"); }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region ��־��¼��֧�������̷߳��� 
        public delegate void LogAppendDelegate(Color color, string text);
        /// <summary> 
        /// ׷����ʾ�ı� 
        /// </summary> 
        /// <param name="color">�ı���ɫ</param> 
        /// <param name="text">��ʾ�ı�</param> 
        public void LogAppend(Color color, string text)
        {
            mTextBox.SelectionColor = color;
            mTextBox.AppendText(text);
            mTextBox.AppendText("\n");
        }
        /// <summary> 
        /// ��ʾ������־ 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            mTextBox.Invoke(la, Color.Red, DateTime.Now.ToString("HH:mm:ss ") + text);
            mTextBox.AppendText("\n");
        }
        /// <summary> 
        /// ��ʾ������Ϣ 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogWarning(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            mTextBox.Invoke(la, Color.Violet, DateTime.Now.ToString("HH:mm:ss ") + text);
            mTextBox.AppendText("\n");
        }
        /// <summary> 
        /// ��ʾ��Ϣ 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogMessage(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            mTextBox.Invoke(la, Color.Black, DateTime.Now.ToString("HH:mm:ss ") + text);
            mTextBox.AppendText("\n");
        }
        #endregion

        private void DummyOutputWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}