using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonDemo : MonoBehaviour
{
    [SerializeField]
    TMP_Text _text;

    public void OnButtonClick()
    {
        _text.text = "Button Clicked";
    }
}
