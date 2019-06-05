using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaScript : MonoBehaviour
{
    Animator anim;
    CircleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.gameObject.CompareTag("Player"))
    	{
    		GameManager.gm.SetFrutas(1);
    		col.enabled = false;
    		anim.SetTrigger("Coletando");
    		Destroy(gameObject, 1.385f);
    	}
    }
}
