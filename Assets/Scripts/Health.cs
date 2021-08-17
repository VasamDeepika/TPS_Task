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

    //public ParticleSystem particleEffect;
    private void OnEnable()
    {
        currentHealth = startHealth;
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
        //particleEffect.Play();
        gameObject.SetActive(false);
        if(gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}