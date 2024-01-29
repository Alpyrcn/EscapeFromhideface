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

        // Eðer bu nesnenin bir saðlýk çubuðu varsa, baðlantýyý yap
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Saðlýk çubuðunu güncelle
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Eðer saðlýk sýfýra düþtüyse, nesneyi etkisiz hale getir veya baþka bir þey yap
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

