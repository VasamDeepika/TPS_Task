using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerSpeed;
    public float backSpeed;
    public float turnSpeed;
    public Animator anim;

    ScoreManager scoreManager;

    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Start()
    {
       
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
            characterController.SimpleMove(transform.forward * vertical * moveSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gold" || other.gameObject.tag == "Bottle")
        {
            scoreManager.IncrementScore();
            other.gameObject.SetActive(false);
        }
    }
}