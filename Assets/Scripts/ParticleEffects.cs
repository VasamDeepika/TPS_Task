using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    public ParticleSystem deatharticleEffect;
    public static ParticleEffects instance;
    private void Awake()
    {
        instance = this;
    }
    public void DeathParticleEffects()
    {
        Instantiate(deatharticleEffect, gameObject.transform.position, Quaternion.identity);
        deatharticleEffect.gameObject.SetActive(true);
    }
}
