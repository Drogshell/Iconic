using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : ScriptableObject
{
    public string answer;
    public string displayAnswer;

    public string[] hints = new string[3];

    public string[] GetHints()
    {
        if (hints.Length == 0)
        {
            Debug.LogError("Hints not initialised");
        }
        return hints;
    }
    
}
