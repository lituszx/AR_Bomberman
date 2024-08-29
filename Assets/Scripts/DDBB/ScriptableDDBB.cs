using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableDDBB : MonoBehaviour
{
    private List<MultiText> _allTexts = new List<MultiText>();
    public Language language;
    private static ScriptableDDBB _instance;
    public static ScriptableDDBB Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Database");
                _instance = go.AddComponent<ScriptableDDBB>();
                _instance.LoadLanguageFromPlayerPrefs();
            }
            return _instance;
        }
    }
    public void AddTextToList(MultiText script)
    {
        _allTexts.Add(script);
    }
    public void ClearList()
    {
        _allTexts.Clear();
    }
    public string LoadText(int filename)
    {
        MenuText scriptable = (MenuText)Resources.Load<ScriptableObject>(Constants.FOLDER_SCRIPTABLE_OBJECTS + filename.ToString());
        switch (language)
        {
            case Language.Spanish:
                return scriptable.spanish;
            case Language.English:
                return scriptable.english;
            case Language.Catalonian:
                return scriptable.catalonian;
        }
        return null;
    }
    public void SetLenguaje(Language lan)
    {
        language = lan;
        for (int i = 0; i < _allTexts.Count; i++)
        {
            _allTexts[i].SetText();
        }
        PlayerPrefs.SetInt(Constants.KEY_LANGUAGE,(int) language);
    }
    private void LoadLanguageFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(Constants.KEY_LANGUAGE))
            language = (Language)PlayerPrefs.GetInt(Constants.KEY_LANGUAGE);
    }
}
