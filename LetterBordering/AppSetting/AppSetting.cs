using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;

namespace CatHut {

    public class AppSetting<T> where T : new()
    {

        private String SaveFile;
        public T Settings { set; get; }



        public AppSetting(string file)
        {
            SaveFile = file;
            Initialize();
        }

        public AppSetting()
        {
            SaveFile = "AppSetting.xml";
            Initialize();
        }


        //終了時の呼び出し
        public void Exit()
        {
            SaveData();
        }

        //XMLファイルをSampleClassオブジェクトに復元する
        public void Initialize()
        {

            LoadData();

        }

        //XMLファイルをSampleClassオブジェクトに復元する
        public void LoadData()
        {

            //XmlSerializerオブジェクトを作成
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));


            //ファイルがあれば読み込み、無ければインスタンスを自分で作る。
            try
            {
                //読み込むファイルを開く
                var sr = new System.IO.StreamReader(SaveFile, new System.Text.UTF8Encoding(false));

                //XMLファイルから読み込み、逆シリアル化する
                this.Settings = (T)serializer.Deserialize(sr);

                //ファイルを閉じる
                sr.Close();
            }
            catch
            {
                Debug.WriteLine("xmlファイル読み込み失敗");
                Debug.WriteLine("デフォルト値設定");
                Settings = new T(); // T型のデフォルト値を設定
            }
        }

        //XMLファイルを書き出し
        public void SaveData()
        {

            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));


            try
            {
                //書き込むファイルを開く（UTF-8 BOM無し）
                var sw = new System.IO.StreamWriter(SaveFile, false, new System.Text.UTF8Encoding(false));

                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, Settings);

                //ファイルを閉じる
                sw.Close();
            }
            catch
            {
                Debug.WriteLine("書き込み先" + SaveFile + "に書き込めません。" + Environment.NewLine
                    + "開いている場合は閉じてください");
            }
        }



    }
}
