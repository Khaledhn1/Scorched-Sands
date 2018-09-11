using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;
    public bool isDestroyed = false;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        //takes damage if commanded to by another object and dies if health is 0
    }
    public void Die()
    {
        Destroy(gameObject);
        isDestroyed = true;
    }

}
