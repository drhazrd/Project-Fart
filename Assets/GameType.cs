using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameType : MonoBehaviour
{
    //GameManager gmInfo;
    public bool gtInfected, gtDeathmatch, gtArcade;
    public float _inGameTimer;
    // Start is called before the first frame update
    void Start()
    {
        //gmInfo = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gtInfected) 
        {
            StartInfection();
        }
        else if (gtDeathmatch)
        {
            StartDeathMatch();
        }
        else if (gtArcade) 
        {
            StartArcade();
        }
    }
    public void StartDeathMatch() 
    {
        gtDeathmatch = true;
        SceneManager.LoadScene("DeathMatch");
    }
    public void StartArcade() 
    {
        gtArcade = true;
        SceneManager.LoadScene("Arcade");   
    }
    public void StartInfection()
    {
        gtInfected = true;
        SceneManager.LoadScene("Infected");
    }
   
}
