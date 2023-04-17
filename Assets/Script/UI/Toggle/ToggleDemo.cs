using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleDemo : MonoBehaviour
{
    [SerializeField]
    private Toggle _toggle;

    public void OnValueChange(bool value)
    {
        Debug.Log(_toggle.isOn);
    }
}
