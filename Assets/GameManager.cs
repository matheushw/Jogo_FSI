using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	public static GameManager gm;
    public static PlayerLife pl;

	private int vidas = 1;
    private int frutas = 0;
    
    bool HudCalled = false;


    // Start is called before the first frame update
    void Awake()
    {
    	if(gm == null) {
    		gm = this;
    		DontDestroyOnLoad(gameObject);
    	}

    	else 
    		Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "DeathScreen"){
            Debug.Log(HudCalled);
            Debug.Log(frutas.ToString());
            if(Input.anyKey){
                Reset();
            }
            if(!HudCalled){
                AtualizaHud();
                HudCalled = true;
            }
        }
    }

    public void Reset(){
        HudCalled = false;
    	if (GetVidas() >= 0){
            GameManager.gm.SetFrutas(0);
    		SceneManager.LoadScene("cu");
    	}
    }
    public void SetVidas (int vida) {
        if(vida != 0){
            vidas += vida;
        }else{
    	    vidas = vida;
        }
    }

    public int GetVidas () {
    	return vidas;
    }

    public void SetFrutas (int fruta) {
        if(fruta != 0){
            frutas += fruta;
        }else{
            frutas = fruta;
        }
        
        AtualizaHud();
    }

    public void AtualizaHud() {
        GameObject.Find("FrutaText").GetComponent<Text>().text = frutas.ToString();
    }
}
