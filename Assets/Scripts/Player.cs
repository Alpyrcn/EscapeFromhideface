using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region REFERENCES

    [Header("UI Elements")]
    [Space(5)]
    public Slider healthBar;
    public Slider energyBar;

    #endregion

    #region VARIABLES

    [Header("Maximum Values")]
    [Space(5)]
    public float maxHealth;
    public float maxEnergy;

    [Header("Current Values")]
    [Space(5)]
    public float health;
    public float energy;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        health = maxHealth ;
        energy = maxEnergy ;

        UpdateHealthBar();
        UpdateEnergyBar();
    }


    #endregion

    #region  METHODS

    public void UpdateHealth(float value)
    {
        float newValue = health + value;

        health = Mathf.Clamp(newValue, 0f, maxHealth);

        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        // Saðlýk sýfýra düþtüðünde ölüm iþlemlerini burada gerçekleþtirebilirsiniz.
        if (health <= 0)
        {
            //Die();
        }

        UpdateHealthBar();
    }

    public void UpdateEnergy(float value)
    {
        float newValue = energy + value;

        energy = Mathf.Clamp(newValue, 0f, maxEnergy);

        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        energyBar.value = SliderValue(energy, 0f, maxEnergy);
    }

    private void UpdateHealthBar()
    {
        healthBar.value = SliderValue(health, 0f, maxHealth);
    }

    void IncreaseEnergy(float amount)
    {
        energyBar.value += amount * Time.deltaTime;
    }

    void DecreaseEnergy(float amount)
    {
        energyBar.value -= amount * Time.deltaTime;
    }
    #endregion

    #region UTILITY METHODS

    // Gives a result between 0 and 1 to update the slider
    private float SliderValue(float input, float min, float max)
    {
        float ratio = (input -  min) / (max - min);

        return ratio;
    }

    #endregion

}
