using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    int startHealth = 3;
    [SerializeField]
    int currentHealth;
    public bool isPlayerAlive = true;
    public static Health instance;

    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    private void Awake()
    {
        instance = this;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
        
        if(gameObject.tag == "Player")
        {
            isPlayerAlive = false;
            GameManager.instance.WaitForSeconds();
            SceneManager.LoadScene(2);
        }
    }
    
}