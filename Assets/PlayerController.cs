using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpforce;
    public GameObject player;

    private Rigidbody2D rb2d;
    private bool facingRight = true;
    private bool jump = false;
    private bool crouch = false;
    private Animator anim;
    private bool grounded = false;
    private Transform groundCheck;

    // Start is called before the first frame update

    void Start() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    // Update is called once per frame

    void Update() {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded) {
            jump = true;
            anim.SetTrigger("Jumped");
        }
    }
        void FixedUpdate() {
            float h = Input.GetAxisRaw("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(h));

            rb2d.velocity = new Vector2(h * speed, rb2d.velocity.y);

            if (h > 0 && !facingRight) {
                Flip();
            }
            else if (h < 0 && facingRight) {
                Flip();
            }
            if (jump) {
                rb2d.AddForce(new Vector2(0, jumpforce));
                jump = false;
            }
            if (Input.GetKey(KeyCode.DownArrow) && grounded) {
                crouch = true;
                anim.SetBool("Crouch", true);
            }
            else {
                crouch = false;
                anim.SetBool("Crouch", false);
            }

            if (crouch) {
                    player.GetComponent<BoxCollider2D>().enabled = false;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }

            else {
                    player.GetComponent<BoxCollider2D>().enabled = true;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }

        }
        void Flip() {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

}
