using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
    private Dropdown _dropdown;
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();
        _dropdown.value = (int)ScriptableDDBB.Instance.language;
    }
    public void ReloadLanguaje()
    {
        ScriptableDDBB.Instance.SetLenguaje((Language)_dropdown.value);
    }
}
