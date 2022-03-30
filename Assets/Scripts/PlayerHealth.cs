using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public int CurrentHealth, MaxHealth;
    public float InvincibleLength;
    private float InvincibleCounter;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(InvincibleCounter > 0)
        {
            InvincibleCounter -= Time.deltaTime;
        }
    }

    public void DealDamage()
    {
        if (InvincibleCounter <= 0)
        {
            CurrentHealth--;
            PlayerController.Instance.DamagePlayer();
            UIManager.Instance.UpdatePlayerHealthUI(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                GameManager.Instance.RestartLevel();
                Debug.Log("Player has no more lives. You need to restart the level.");
            }
            else
            {
                InvincibleCounter = InvincibleLength;
                PlayerController.Instance.KnockBack();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            DealDamage();
        }
    }
}
