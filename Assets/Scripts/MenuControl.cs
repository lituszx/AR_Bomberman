using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void LoadScene(int scene)
    {
        ScriptableDDBB.Instance.ClearList();
        SceneManager.LoadScene(scene);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
