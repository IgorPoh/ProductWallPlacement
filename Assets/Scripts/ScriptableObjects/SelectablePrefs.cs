using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectablePrefs : ScriptableObject
{

    //Selected Outline size
    [SerializeField]
    float outlineSizeSelected = .015f;

    //UnSelected Outline size
    [SerializeField]
    float outlineSizeUnselected = 0f;

    public float OutlineSizeSelected { get { return outlineSizeSelected; } }
    public float OutlineSizeUnselected { get { return outlineSizeUnselected; } }
}
