using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clipboardsave
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            var basename = DateTime.Now.ToString("yyyyMMddhhmmss");
            if (Clipboard.ContainsImage())
            {
                var img = Clipboard.GetImage();
                var diag = new SaveFileDialog();
                diag.FileName = basename + ".png";
                var res = diag.ShowDialog();
                if (res == DialogResult.OK)
                {
                    img.Save(diag.FileName);
                    Console.Write(diag.FileName.Replace("\\", "/") + "\n");
                }
                else
                {
                    Console.Write("Saving image is aborted.");
                }
            }
            else if (Clipboard.ContainsText())
            {
                var txt = Clipboard.GetText();
                var diag = new SaveFileDialog();
                diag.FileName = basename + ".txt";
                var res = diag.ShowDialog();
                if (res == DialogResult.OK)
                {
                    using(var w = new System.IO.StreamWriter(diag.FileName))
                    {
                        w.Write(txt);
                    }
                    Console.Write(diag.FileName.Replace("\\", "/") + "\n");
                }
                else
                {
                    Console.Write("Saving text is aborted.");
                }
            }
            else
            {
                Console.Write("No data!");
            }
        }
    }
}
