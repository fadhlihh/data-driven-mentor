using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputDemo : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]
    private TMP_Text _text;

    public void OnClickButton()
    {
        _text.text = _inputField.text;
    }
}
