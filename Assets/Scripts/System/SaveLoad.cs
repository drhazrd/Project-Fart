using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public Text playerNumberText;
    int currentnumber;
    // Start is called before the first frame update
    void Start()
    {
            PlayerPrefs.SetInt("PlayerScore", 4);
            Debug.Log("Hey we saved!");

        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            int playerNumber = PlayerPrefs.GetInt("PlayerScore");
            Debug.Log("Hey we saved the number " + playerNumber);
            playerNumber = currentnumber;
        }
        //else
        //{
        //}
    }
    
}
