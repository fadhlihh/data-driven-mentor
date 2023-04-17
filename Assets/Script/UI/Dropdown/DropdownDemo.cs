using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownDemo : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown _dropdown;

    public void OnValueChange(int value)
    {
        Debug.Log(_dropdown.value);
        Debug.Log(_dropdown.options[value].text);
    }
}
