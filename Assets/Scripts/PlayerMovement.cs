using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerSpeed;
    public float backSpeed;
    public float turnSpeed;
    public Animator anim;
    [SerializeField]
    int coinCount = 5;

    public ParticleSystem coinParticleEffect;

    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);
        anim.SetFloat("Speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        if (vertical != 0)
        {
            float moveSpeed = (vertical > 0) ? playerSpeed : backSpeed;
            //anim.SetTrigger("Back");
            characterController.SimpleMove(transform.forward * vertical * moveSpeed);

        }
        if(coinCount<=0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gold" || other.gameObject.tag == "Bottle")
        {
            coinCount--;
            other.gameObject.SetActive(false);
            Instantiate(coinParticleEffect, transform.position, Quaternion.identity);
            coinParticleEffect.gameObject.SetActive(true);
            ScoreManager.instance.IncrementScore();
        }
    }
}