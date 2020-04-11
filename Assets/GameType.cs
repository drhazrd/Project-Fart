using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ProjectFart {
    public enum Gametype
    {
        Default,
        Infected,
        Deathmatch,
        Arcade
    }
    public class GameType : Singleton<GameType>
    {
        //GameManager gmInfo;
        public Gametype gType;
        public bool isMissionActive;
        public float _inGameTimer;
        public PlayerStats stats;
        DialogueManager dialogueManager;
        public int currentCollection;
        public int maxCollection;
        // Start is called before the first frame update
        void Start()
        {
            //stats = FindObjectOfType<PlayerStats>();
            //gmInfo = GetComponent<GameManager>();
            /*if (gtInfected)
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
            }*/
        }

        // Update is called once per frame
        void Update()
        {
            if (maxCollection == 0 && isMissionActive)
            {
                GameObject prize = GameObject.FindGameObjectWithTag("King Llama");
                if (prize != null)
                {
                    prize.SetActive(true);
                }
            }
            else
            {
                return;
            }
        }
        public void StartDeathMatch()
        {
            //gtDeathmatch = true;
            SceneManager.LoadScene("DeathMatch");
        }
        public void StartArcade()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Llama");
            int maxCollection = objects.Length;
        }
        public void StartInfection()
        {
            //gtInfected = true;
            SceneManager.LoadScene("Infected");
        }

    }
}