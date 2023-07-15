using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterBordering.Setting
{
    public class SettingClass
    {
        /// <summary>
        /// 選択中のUUID
        /// </summary>
        public string SelectedProject;

        /// <summary>
        /// プロジェクトリスト
        /// </summary>
        public List<SimpleProjectClass> ProjectList;

        public SettingClass() {
            SelectedProject = "";
            ProjectList = new List<SimpleProjectClass>();
        }

    }
}
