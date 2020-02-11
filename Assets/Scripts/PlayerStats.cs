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
        healthText.text = currentHealth.ToString();
        armorText.text = currentArmor.ToString();
        scoreText.text = "n/a";
        grenadesText.text = "n/a";
    }
}
