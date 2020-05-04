using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string questTitle;
    public string questDesription;
    public Image questImage;
    public int questExp;
    public int questScore;
}
