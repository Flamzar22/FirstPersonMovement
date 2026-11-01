using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    private float maxHealth;
    public Image healthBar;

    void Start()
    {
        maxHealth = health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 25;
            Destroy(collision.gameObject);
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
