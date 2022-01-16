using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public GameObject destroyedVersion;
    public GameObject ParticleEffect;

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            TargetDestroyed();
        }
    }

    void TargetDestroyed()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
