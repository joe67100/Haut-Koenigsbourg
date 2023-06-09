using UnityEngine;
using Mirror;
using System.Collections;

public class Player : NetworkBehaviour
{
    [SyncVar]
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }

    [Space, Header("Player stats")]
    [SerializeField]
    private float maxHealth = 100f;
    [SyncVar(hook = nameof(OnHealthChanged))]
    private float currentHealth;
    private HealthBar healthBar;
    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabledOnStart;

    [Space, Header("Player Infos")]
    public string PlayerName;
    public int KillsCount = 0;
    public int DeathsCount = 0;
    public int Score = 0;

    public void Setup()
    {
        wasEnabledOnStart = new bool[disableOnDeath.Length];
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            wasEnabledOnStart[i] = disableOnDeath[i].enabled;
        }

        SetDefaults();
    }

    private void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth((int)maxHealth);
    }

    public void SetDefaults()
    {
        isDead = false;
        currentHealth = maxHealth;

        for(int i =0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabledOnStart[i];
        }

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(GameManager.instance.matchSettings.respawnTimer);
        SetDefaults();
        Transform spawnPoint = NetworkManager.singleton.GetStartPosition();
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
    }

    // S'infliger des d�g�ts pour test
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            RpcTakeDamage(999);
        }
    }

    [ClientRpc]
    public void RpcTakeDamage(float amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0); // Emp�che d'aller en dessous de 0 PDV
        Debug.Log(transform.name + " a maintenant : " + currentHealth + " points de vies");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnHealthChanged(float oldHealth, float newHealth)
    {
        if (healthBar != null)
        {
            healthBar.SetHealth((int)newHealth);
        }
    }

    private void Die()
    {
        isDead = true;

        for(int i =0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }


        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        Debug.Log(transform.name + " a �t� �limin�.");

        StartCoroutine(Respawn());
    }

    // Old playInfo.cs

    // methode qui permet de d�finir le nom du joueur
    public void SetName(string name)
    {
        string playerName = name;
    }

    public void AddKillCount()
    {
        KillsCount++;
        Score = Score + 100;
    }

    public void AddDeathCount()
    {
        DeathsCount++;
    }

}
