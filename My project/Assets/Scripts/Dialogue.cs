using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //public string name;
    //public Sprite character;

    [TextArea(3, 10)]
    public string[] sentences;
    [TextArea(1, 10)]
    public string[] names;
}
