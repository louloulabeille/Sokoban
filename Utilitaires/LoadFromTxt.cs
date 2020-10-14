using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Utilitaires
{
    public class LoadFromTxt : ILoad
    {
        List<List<char>> ILoad.Load(string path, int level)
        {
            string text = File.ReadAllText(path);
            string toSearch = "Maze: " + level.ToString();
            int postmp = text.IndexOf(toSearch, 0);
            int pos2 = text.IndexOf("*************************************", postmp);
            int pos1 = text.IndexOf("\n\n", postmp) + 2;
            string tmp = text.Substring(pos1, pos2 - pos1 +1);
            List<string> listTmp = tmp.Split('\n').ToList();
            List<List<char>> toReturn = new List<List<char>>();
            for (int i = 0; i < listTmp.Count; i++)
            {
                toReturn.Add(listTmp[i].ToCharArray().ToList());
            }
            return toReturn;
        }
    }
}