using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject particleEffect;

    public Animator anim;
    [SerializeField] CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;



    void Update()
    {
        Jamping();
    }

    private void Jamping()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        /* float angle = Vector3.Angle(transform.up, Vector3.up);
         bool angleAllowed = angle >= 0 && angle <= 45;*/
        bool isInIdleOrRunState = anim.GetFloat("Speed") >= 0f;

        if (Input.GetButtonDown("Player1_Jump") && isGrounded && isInIdleOrRunState)
        {
            anim.SetTrigger("Jump");
            //velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            velocity.y = jumpForce;
            GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particle, 2f);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }
}
