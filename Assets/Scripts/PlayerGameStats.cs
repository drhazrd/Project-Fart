using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameStats : MonoBehaviour
{
    public GameType gType;
    public float infectedTimer;
    public Text infectedTimerText;
    public bool infected;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Infection();
        }
    }
    public void Infection()
    {
        infectedTimerText.text = infectedTimer.ToString();
        if (infected)
        {
            infectedTimer++;
        }
    }
}
