using System;
using UnityEngine;

public class PoisonHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private int poisonDamage;

    private int currentHealth;
    private float timeDelay = 1f;
    private float timeSinceAttack;
    private int poisinCounter;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float) currentHealth / (float) startingHealth; }
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0){
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);
        }
        currentHealth -= amount;
        OnHPPctChanged(CurrentHpPct);
        if (CurrentHpPct <= 0){
            Die();
        }
        Invoke("Poisined", 0f);
    }

    void Poisined(){
        timeSinceAttack = 0f;
        poisinCounter = 0;
        while(poisinCounter <= 5 && currentHealth >= 0){
            Debug.Log("Poisoned");
            timeSinceAttack += Time.deltaTime;
            if(timeDelay <= Time.deltaTime){
                timeSinceAttack = 0f;
                poisinCounter++;
                currentHealth -= poisonDamage;
                OnHPPctChanged(CurrentHpPct);
            }
        }
        Debug.Log("while ended");
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
