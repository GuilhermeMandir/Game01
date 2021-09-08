using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float hspeed = 0.5f;
    public float vspeed = 0.5f;
    public Rigidbody2D playerRb;
    public Animator animator;


    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", move.x);
        animator.SetFloat("vertical", move.y);
        animator.SetFloat("velocidade", move.sqrMagnitude);

        if(move != Vector2.zero)
        {
            animator.SetFloat("idleh", move.x);
            animator.SetFloat("idlev", move.y);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + move * hspeed * Time.fixedDeltaTime);
        playerRb.MovePosition(playerRb.position + move * vspeed * Time.fixedDeltaTime);
    }
}