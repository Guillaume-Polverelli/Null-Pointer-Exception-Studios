using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    [SerializeField] private float speed;
    [SerializeField] private float gravity;

    public Transform groundCheck;
    [SerializeField] private float groundDistance;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isStopped = false;

    [SerializeField] private float footStepsCD;
    private float fsTimeElapsed = 0f;

    [SerializeField] private AudioClip[] footstepsGrass;

    private AudioSource characterAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        characterAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isStopped)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            
           float x = Input.GetAxis("Horizontal");
           float  z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);


            if (!characterAudioSource.isPlaying && controller.isGrounded && (x >= 1.0f || z >= 1.0f))
            {
                characterAudioSource.clip = footstepsGrass[Random.Range(0, footstepsGrass.Length)];
                characterAudioSource.Play();

            }

        }

    }

    public void setStopped(bool condition)
        {
            isStopped = condition;
        }

        public bool getStopped()
        {
            return isStopped;
        }
}

