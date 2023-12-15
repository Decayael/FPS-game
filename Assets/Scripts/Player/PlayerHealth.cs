using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public int maxHealth = 100;
    private float lerpTimer;
    public float chipSpeed = 2f;

    public Image frontHealthBar;
    public Image backHealthBar;
    

    public event System.Action<int, int> OnHealthChanged; // Event to notify health changes

    void Start()
    {
        Health = maxHealth;
    }

    void Update()
    {
        Health = Mathf.Clamp(Health, 0, maxHealth);
        UpdateHealthUI();
        if (Input.GetKeyUp(KeyCode.H))
        {
            TakeDamage(Random.Range(5, 10));
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log("health");
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        lerpTimer = 0f;
    }


}

