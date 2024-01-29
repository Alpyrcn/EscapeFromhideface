using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public GameObject player;
    public Vector3 Startingpoint;

    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;

        // E�er bu nesnenin bir sa�l�k �ubu�u varsa, ba�lant�y� yap
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Sa�l�k �ubu�unu g�ncelle
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // E�er sa�l�k s�f�ra d��t�yse, nesneyi etkisiz hale getir veya ba�ka bir �ey yap
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }
}

