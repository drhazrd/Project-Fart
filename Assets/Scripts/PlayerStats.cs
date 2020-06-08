using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    Respawn respawn;
    ThorQuestSystem thor;
    public int currentHealth;
    public int maxHealth = 100;
    public int currentArmor;
    public int maxArmor = 150;
    public int currentExperience;
    public int currentLevel;
    public int maxLevel = 150;
    public int currScore;
    public int heldAmmo;
    public bool noHealth;
    public Quest quest;
    public Text missionText;
    public bool isQuesting;
    public Text scoreText;
    public Text grenadesText;
    public int questCurrentAmount;
    public int questRequiredAmount;

    // Start is called before the first frame update
    void Start()
    {
        thor = FindObjectOfType<ThorQuestSystem>();
        respawn = GetComponent<Respawn>();
        //noHealth = respawn.isDead = false;
        currentArmor = maxArmor;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = currentHealth.ToString();
        questCurrentAmount = thor.questCurrentAmount;
        questRequiredAmount = quest.goal.requiredAmount;
        if (quest.isActive)
        {
            missionText.text = quest.questTitle + " " + questCurrentAmount.ToString() + " / " + questRequiredAmount.ToString();
        }
        else
        {
            missionText.text = "No Missions Available, Have Fun!";
        }
        scoreText.text = currScore.ToString();
        grenadesText.text = "n/a";
        if (currentHealth <= 0)
            noHealth = true;
    }
    public void TakeDamage(int damage)
    {
        if (currentArmor <= 0)
        {
            currentHealth -= damage;
            currentArmor = 0;
        }
        else
        {
            currentArmor -= damage;

        }
    }
}
