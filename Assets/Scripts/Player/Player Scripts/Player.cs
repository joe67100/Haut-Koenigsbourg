using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    [SyncVar(hook = nameof(OnHealthChanged))]
    private float currentHealth;

    private HealthBar healthBar;

    private void Awake()
    {
        SetDefaults();
    }

    private void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth((int)maxHealth);
    }

    public void SetDefaults()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(transform.name + " a maintenant : " + currentHealth + " points de vies");
    }

    private void OnHealthChanged(float oldHealth, float newHealth)
    {
        if (healthBar != null)
        {
            healthBar.SetHealth((int)newHealth);
        }
    }
}
