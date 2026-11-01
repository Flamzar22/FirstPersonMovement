using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public float damage;
    public Image healthBar;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("FindPlayer", 1f, 0.5f);    
        maxHealth = health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision);
        }
    }

    private void TakeDamage(Collision collision)
    {
        health -= 25;
        Destroy(collision.gameObject);
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FindPlayer()
    {
        agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
