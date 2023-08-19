using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Animator animator;
    //private Rigidbody rigidbody;
    private bool isDead = false;
    private Vector3 bulletDirection;
    public float upwardforce = 10f;

    public float hitForce = 5f;

    public GameObject damagingObject; // Reference to the damaging GameObject

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        //rigidbody = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "DamageDealer" tag
        if (collision.gameObject.CompareTag("nerf"))
        {

            Debug.Log("attack");
            bulletDirection = collision.transform.forward;
            Debug.Log("Damage dealt to enemy!");
            TakeDamage(5);
        }
    }



    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Death");

        Destroy(gameObject, 3f); // Destroy the gameobject after some time

    }
}