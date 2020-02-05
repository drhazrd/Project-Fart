using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float deathHeight=50f;
    void Update(){
        if(transform.position.y <= -deathHeight)
        {
        Die();
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            //Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
