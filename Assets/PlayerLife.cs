using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update

	Animator anim;
	bool vivo = true;
    void Start()
    {
    	anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerdeVida () {
    	if (vivo){
    		vivo = false;
	    	anim.SetTrigger("Dead");
	    	GameManager.gm.SetVidas(0);
	    	gameObject.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(WaitForSceneLoad());
            
    	}
    }
    private IEnumerator WaitForSceneLoad() {
     yield return new WaitForSeconds(2);
     SceneManager.LoadScene("DeathScreen");
     
 }

    // public void Reset(){
    // 	if (GameManager.gm.GetVidas() >= 0){
    //         SceneManager.UnloadSceneAsync("DeathScreen");
    // 		SceneManager.LoadScene("cu");
    // 	}
    // }
}
