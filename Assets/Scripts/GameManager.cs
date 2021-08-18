using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void WaitForSeconds()
    {
        if(Health.instance.isPlayerAlive == false)
        {
            StartCoroutine(Wait());
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
