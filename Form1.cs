using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 距離の変換
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// mmに変換します。
        /// </summary>
        /// <param name="data">長さ(例:5cm->5)</param>
        /// <param name="mode">単位の種類(mm->0,cm->1,m->2,km->3)</param>
        /// <returns>mmでの長さ</returns>
        public static double mm(double data,int mode)
        {
            //結果を入れる変数
            double kekka = 0;
            switch(mode)
            {
                //mmの場合
                case 0:
                    kekka = data;
                    break;
                case 1:
                    kekka = data * 10;
                    break;
                case 2:
                    kekka = data * 1000;
                    break;
                case 3:
                    kekka = data * 1000000;
                    break;
            }
            return kekka;
        }

        /// <summary>
        /// 単位を変換します。
        /// </summary>
        /// <param name="data">mmの長さ</param>
        /// <param name="mode">変換の種類(mm->0,cm->1,m->2,km->3)</param>
        /// <returns>変換した長さ</returns>
        public static double henkan(double data,int mode)
        {
            //結果を入れる変数
            double kekka = 0;
            switch(mode)
            {
                case 0:
                    kekka = data;
                    break;
                case 1:
                    kekka = data / 10;
                    break;
                case 2:
                    kekka = data / 1000;
                    break;
                case 3:
                    kekka = data / 1000000;
                    break;
            }
            return kekka;
        }

        /// <summary>
        /// エラーを表示します。
        /// </summary>
        /// <param name="error_message">エラーメッセージ</param>
        public static void error(string error_message)
        {
            MessageBox.Show("エラーが発生しました。↓" + Environment.NewLine + 
                error_message,"エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void henkan_button_Click(object sender, EventArgs e)
        {
            //結果を入れる変数
            double kekka = 0;
            //初めの長さ
            double length = 0;
            //数字に変換できるか
            if (!double.TryParse(mae_data.Text, out length))
            {
                error("長さを数字に変換できませんでした。");
                return;
            }
            //単位が選択されているか
            if (mae_tanni.SelectedItem.ToString() == "")
            {
                error("単位が選択されていません。");
                return;
            }

            //長さを変数に入れる
            length = double.Parse(mae_data.Text);
            //なんでも、mmに変換
            switch (mae_tanni.SelectedItem.ToString())
            {
                case "mm":
                    kekka = mm(length, 0);
                    break;
                case "cm":
                    kekka = mm(length, 1);
                    break;
                case "m":
                    kekka = mm(length, 2);
                    break;
                case "km":
                    kekka = mm(length, 3);
                    break;
            }
            //指定の単位に変換
            switch (ato_tanni.SelectedItem.ToString())
            {
                case "mm":
                    kekka = henkan(kekka, 0);
                    break;
                case "cm":
                    kekka = henkan(kekka, 1);
                    break;
                case "m":
                    kekka = henkan(kekka, 2);
                    break;
                case "km":
                    kekka = henkan(kekka, 3);
                    break;
            }
            //表示
            kekka_label.Text = kekka + ato_tanni.SelectedItem.ToString();
        }
    }
}
