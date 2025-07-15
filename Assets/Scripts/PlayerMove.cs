using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float gravity = -25f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 7f;
    private Animator animator;
    private Rigidbody2D rgb;
    private bool isGround;
    private float moveX;
    [SerializeField] private LayerMask mask;
    void Start()
    {
        Physics2D.gravity = new Vector2(0, gravity);
        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (moveX > 0)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isRun", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            
        }
        else if(moveX < 0)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isRun", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
           
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        transform.Translate(Vector2.right * moveX * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(transform.position - new Vector3(0f, 0.8f, 0f), new Vector2(1f, 0.2f), 0f, mask);
        if (Input.GetAxis("Jump") > 0 && isGround)
        {
            animator.Play("New Animation Jump");
            rgb.velocity = Vector2.zero;
            rgb.AddForce(Vector2.up * jump * transform.localScale.x, ForceMode2D.Impulse);
        }
    }
}
