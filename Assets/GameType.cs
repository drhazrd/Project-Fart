using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ProjectFart {
    public class GameType : Singleton<GameType>
    {
        //GameManager gmInfo;
        public bool gtInfected, gtDeathmatch, gtArcade;
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

        // Update is called once per frame
        void Update()
        {
            if (maxCollection<= 0)
            {
                GameObject prize = GameObject.FindGameObjectWithTag("King Llama");
                prize.SetActive(true);
            }
        }
        public void StartDeathMatch()
        {
            gtDeathmatch = true;
            SceneManager.LoadScene("DeathMatch");
        }
        public void StartArcade()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Llama");
            int maxCollection = objects.Length;
        }
        public void StartInfection()
        {
            gtInfected = true;
            SceneManager.LoadScene("Infected");
        }

    }
}