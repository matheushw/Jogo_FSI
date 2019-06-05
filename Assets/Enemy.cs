using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float velocidade; //Velocidade do inimigo
	Rigidbody2D rb;
	Transform groundCheck;
	bool facing_right = false; //Variavel para indicar se o inimigo está virado para a esquerda
	bool onGround = false; //Variavel para indicar se o inimigo está ou não no chao
    public float jumpForce = 700;

    // Start is called before the first frame update
    void Start()
    {

    	rb = gameObject.GetComponent<Rigidbody2D>();
    	groundCheck = transform.Find("EnemyGroundCheck");
        
    }

    // Update is called once per frame
    void Update()
    {

    	onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(!onGround) {
        	velocidade *= -1;
        }
        
    }

    void FixedUpdate() {
    	rb.velocity = new Vector2(velocidade,rb.velocity.y);
    	if (velocidade > 0 && !facing_right) {
    		Flip();
    	}

    	else if (velocidade < 0 && facing_right) {
    		Flip();
    	}
    }

    void Flip () {
    	facing_right = !facing_right;

    	Vector3 theScale = transform.localScale;

    	theScale.x *= -1;

    	transform.localScale = theScale;

    }

    void OnTriggerEnter2D (Collider2D other) {
    	if (other.gameObject.CompareTag("Player")) {
    		BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
    		foreach(BoxCollider2D box in boxes){
    			box.enabled = false;
    		}

    		other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    		velocidade = 0;
    		transform.Rotate(new Vector3(0, 0, -180));
    		Destroy(gameObject,3);
    	}
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerLife>().PerdeVida();
        }

    }
}
