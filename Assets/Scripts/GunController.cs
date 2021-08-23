using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Range(0, 2)]
    [SerializeField] float fireRate = 1f;
    [SerializeField]
    [Range(1, 10)]
    int damage = 1;
    [SerializeField]
    int bulletCount = 60;
    [SerializeField] float timer;
    public ParticleSystem bulletParticleEffect;
    public ParticleSystem deathParticleEffect;
    Animator anim;

    public Transform cameraTranform;

    AudioSource audioSource;
    public AudioClip shootClip;

    public static GunController instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                if (bulletCount > 0)
                {
                    FireGun();
                    bulletParticleEffect.Play();
                }
            }
        }
    }

    private void FireGun()
    {
        bulletCount--;
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 2f);
        RaycastHit hit;
        
        audioSource.clip = shootClip;
        audioSource.Play();
        if (Physics.Raycast(ray, out hit, 100f))
        {
            var health = hit.collider.gameObject.GetComponent<Health>();
            Instantiate(deathParticleEffect, hit.collider.gameObject.transform.position, Quaternion.identity);
            deathParticleEffect.gameObject.SetActive(true);
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}