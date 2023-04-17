using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDemo : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private void Start()
    {
        _text.text = "Text Updated";
    }
}
