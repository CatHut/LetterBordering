using CatHut;
using LetterBordering.Setting;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetterBordering
{
    public class ProjectManager
    {
        public string CurrentTextIndex;

        /// <summary>
        /// プロジェクトの実体
        /// </summary>
        private Dictionary<string, ProjectClass> ProjectDic;

        /// <summary>
        /// Projectのインポートエクスポート用
        /// </summary>
        public CatHut.AppSetting<ProjectClass> AsProject;

        /// <summary>
        /// プロジェクト選択状態保存用
        /// </summary>
        public CatHut.AppSetting<SettingClass> AsSettings;

        const string SETTING_FILE = @"Setting.xml";
        const string DATA_FOLDER = @".\Data";


        public ProjectManager()
        {

            Initialize();
        }


        public void Initialize()
        {
            ProjectDic = new Dictionary<string, ProjectClass>();

            //設定ファイル
            AsSettings = new CatHut.AppSetting<SettingClass>(SETTING_FILE);


            //プロジェクトリストを初期化
            InitProjectDic();


            var id = AsSettings.Settings.SelectedProject;

            //現在選択中のプロジェクトをロード
            if (id == "")
            {
                //プロジェクトがない場合新規作成
                CreateProject("New Project01");
            }
            else
            {
                if (ProjectDic.ContainsKey(id))
                {
                    //設定されいてる場合
                    LoadProjectById(id);
                }
                else
                {
                    //設定されいてるがデータがない場合
                    CreateProject("New Project01");
                }
            }

        }


        /// <summary>
        /// 簡易リストからプロジェクト情報を生成する
        /// </summary>
        public void InitProjectDic()
        {

            var folder = DATA_FOLDER;

            var fileList = new HashSet<string>();

            // フォルダ内のすべてのXMLファイルを取得
            string[] files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);

            // 各ファイルに対して
            foreach (string file in files)
            {
                // ファイルの拡張子を取得（小文字に変換）
                string extension = Path.GetExtension(file).ToLower();

                if (extension == ".xml")
                {
                    fileList.Add(Path.GetFileNameWithoutExtension(file));
                }
            }

            //ファイルが見つからなかったIDを取得
            var deleteList = new HashSet<string>();
            foreach (var temp in AsSettings.Settings.ProjectList)
            {
                if (!fileList.Contains(temp.Id))
                {
                    deleteList.Add(temp.Id);
                }
            }

            //ファイルがない要素は削除しておく
            foreach (var id in deleteList)
            {
                var target = AsSettings.Settings.ProjectList.FirstOrDefault(p => p.Id == id);

                // 見つかった場合はProjectListから削除する
                if (target != null)
                {
                    AsSettings.Settings.ProjectList.Remove(target);
                }
            }

            foreach (var temp in AsSettings.Settings.ProjectList)
            {
                var instance = new ProjectClass();
                instance.Id = temp.Id;
                instance.Name = temp.Name;
                instance.LastSave = temp.LastSave;

                ProjectDic[temp.Id] = instance;
            }

        }


        public void Save()
        {
            AsSettings.SaveData();
            AsProject.SaveData();
        }


        // すべてのProjectClassのNameを返す関数
        public List<string> GetProjectList()
        {
            // ProjectDicの値をLastSaveで降順にソートする
            var sortedProjects = ProjectDic.Values.OrderByDescending(p => p.LastSave);

            // ソートされたProjectClassのNameをリストに格納する
            var names = new List<string>();
            foreach (var project in sortedProjects)
            {
                names.Add(project.Name);
            }

            // リストを返す
            return names;
        }

        public ProjectClass GetProjectByName(string name)
        {
            // ProjectDicの値からNameが一致するものを検索する
            var project = ProjectDic.Values.FirstOrDefault(p => p.Name == name);

            // 見つかった場合はインスタンスを返す
            if (project != null)
            {
                return project;
            }

            // 見つからなかった場合はnullを返す
            return null;
        }


        public ProjectClass GetProjectById(string id)
        {
            // ProjectDicの値からIdが一致するものを検索する
            var project = ProjectDic.Values.FirstOrDefault(p => p.Id == id);

            // 見つかった場合はインスタンスを返す
            if (project != null)
            {
                return project;
            }

            // 見つからなかった場合はnullを返す
            return null;
        }


        public void LoadProjectById(string id)
        {
            var file = DATA_FOLDER + "\\" + id + ".xml";
            AsProject = new CatHut.AppSetting<ProjectClass>(file);
            if(AsProject.Settings.TextInfoDic.Count == 0) { this.AddText(); }

            ProjectDic[id] = AsProject.Settings;
            AsSettings.Settings.SelectedProject = id;
            AsSettings.SaveData();
        }

        public void LoadProjectByName(string name)
        {
            // ProjectDicの値からNameが一致するものを検索する
            var project = ProjectDic.Values.FirstOrDefault(p => p.Name == name);

            if (project != null)
            {
                LoadProjectById(project.Id);
            }

        }


        public void CreateProject(string name)
        {
            var CreateName = GetProjectName(name);


            var instance = new ProjectClass();
            instance.Name = CreateName;

            ProjectDic[instance.Id] = instance;

            var file = DATA_FOLDER + "\\" + instance.Id + ".xml";
            AsProject = new CatHut.AppSetting<ProjectClass>(file);
            AsProject.Settings = ProjectDic[instance.Id];
            AddText();

            //settings更新
            AsSettings.Settings.SelectedProject = instance.Id;

            var temp = new SimpleProjectClass();
            temp.Name = CreateName;
            temp.Id = instance.Id;
            temp.LastSave = DateTime.Now;
            AsSettings.Settings.ProjectList.Add(temp);

            AsSettings.SaveData();

        }

        public void AddText()
        {
            var key = AsProject.Settings.TextInfoDic.Count;
            //AsProject.Settings.TextInfoDic.Add(key, new TextInfo());
            AsProject.Settings.TextInfoDic[key] = new TextInfo();
            AsProject.Settings.SelectedTextIndex = key;

            AddDeco();
            AddDeco();

        }

        public void CopyText(int idx)
        {
            var key = AsProject.Settings.TextInfoDic.Count;
            AsProject.Settings.TextInfoDic[key] = CatHutCommon.DeepClone<TextInfo>(AsProject.Settings.TextInfoDic[idx]);
        }

        public void AddDeco()
        {
            var key = AsProject.Settings.TextInfoDic.Count - 1;
            var decoDic = AsProject.Settings.TextInfoDic[key].DecorationDic;

            decoDic = decoDic ?? new CatHut.SerializableSortedDictionary<int, DecorationInfo>();

            if (!decoDic.ContainsKey(decoDic.Count))
            {
                decoDic.Add(decoDic.Count, new DecorationInfo());
            }
        }


        // 入力nameを受け、ProjectDicに同じNameをもつインスタンスがあるかチェックする関数
        public string GetProjectName(string name)
        {
            // ProjectDicにnameと同じNameを持つインスタンスがあるかどうかを判定する
            bool exists = ProjectDic.Values.Any(p => p.Name == name);

            // ある場合はNew Project01という名前を返す
            if (exists)
            {
                // New Project01という名前で重複した場合はNew Project02を返す
                // 以降New ProjectXXという名前でXXが重複する場合、重複しないYYを発見するまで探索を行い、重複しないNew ProjectYYを返す
                int i = 1;
                string newName;
                do
                {
                    i++;
                    newName = "New Project" + i.ToString("00");
                } while (ProjectDic.Values.Any(p => p.Name == newName));


                MessageBox.Show(name + "というプロジェクトはすでに存在しています。" + Environment.NewLine + newName + "というプロジェクトを作成します。");

                return newName;
            }
            // ない場合はnameを返す
            else
            {
                return name;
            }
        }


    }
}
