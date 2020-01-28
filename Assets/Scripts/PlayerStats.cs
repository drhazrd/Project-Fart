using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public int currentArmor;
    public int maxArmor = 150;

    public Text healthText;
    public Text armorText;
    public Text scoreText;
    public Text ammoText;
    public Text grenadesText;
    // Start is called before the first frame update
    void Start()
    {
        currentArmor = maxArmor;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health :"+ currentHealth.ToString();
        armorText.text = "Armor :" + currentArmor.ToString();
        scoreText.text = "Score :" + "n/a";
        ammoText.text = "Ammo :" + "n/a";
        grenadesText.text = "Grenades :" + "n/a";
    }
}
