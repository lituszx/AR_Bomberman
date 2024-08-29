using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiText : MonoBehaviour
{
    public int word;
    private Text _text;
    private void Awake()
    {
        ScriptableDDBB.Instance.AddTextToList(this);
        _text = GetComponent<Text>();
        SetText();
    }
    public void SetText()
    {
        _text.text = ScriptableDDBB.Instance.LoadText(word);
    }
}
