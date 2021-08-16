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
    [SerializeField] float timer;
    [SerializeField] Transform firePoint;
    public ParticleSystem particleEffect;
    Animator anim;

    public GameObject bulletPrefab;
    public Transform cameraTranform;

    AudioSource audioSource;
    public AudioClip shootClip;
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
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        particleEffect.Play();
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 2f);
        RaycastHit hit;
        
        audioSource.clip = shootClip;
        audioSource.Play();
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Instantiate(bulletPrefab, ray.origin, firePoint.rotation);
            var health = hit.collider.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

    }
}