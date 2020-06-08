using UnityEngine;

public class Target : MonoBehaviour
{
    ThorQuestSystem thor;
    public Health healthBar;
    public GameObject healthCanvas;
    public int maxHealth = 100;
    public int currentHealth;
    public int deathHeight = 50;
    void Start()
    {
        thor = FindObjectOfType<ThorQuestSystem>();
        healthCanvas.gameObject.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxValue(maxHealth);
    }
    void Update(){
        if(transform.position.y <= -deathHeight)
        {
        Die();
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
          
        }
        else if (currentHealth <= maxHealth)
            healthCanvas.gameObject.SetActive(true);
    }
    void Die()
    {
        Destroy(gameObject);
        thor.questCurrentAmount--;
    }
}
