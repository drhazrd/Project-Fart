using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    Respawn respawn;
    public int currentHealth;
    public int maxHealth = 100;
    public int currentArmor;
    public int maxArmor = 150;
    public int currScore;
    public int heldAmmo;
    public bool noHealth;
    //public Text healthText;
    //public Text armorText;
    public Text scoreText;
    public Text grenadesText;
    // Start is called before the first frame update
    void Start()
    {
        respawn = GetComponent<Respawn>();
        //noHealth = respawn.isDead = false;
        currentArmor = maxArmor;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = currentHealth.ToString();
        //armorText.text = currentArmor.ToString();
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
