using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JSONDDBB
{
    public static void SaveFile(LevelData lvlData)
    {
        string dataJSON = JsonUtility.ToJson(lvlData);
        string path = Application.dataPath + Constants.FOLDER_RESOURCES + Constants.FOLDER_JSON_FILES + lvlData.level.ToString() + Constants.EXTENSION_JSON;
        File.WriteAllText(path, dataJSON);
    }
    public static LevelData LoadData(int level)
    {
        string path = Application.dataPath + Constants.FOLDER_RESOURCES + Constants.FOLDER_JSON_FILES + level.ToString() + Constants.EXTENSION_JSON;
        LevelData dataJSON = new LevelData();
        dataJSON = dataJSON.Null;
        if(File.Exists(path))
        {
            string content = File.ReadAllText(path);
            dataJSON = JsonUtility.FromJson<LevelData>(content);
        }
        return dataJSON;
    }
}
