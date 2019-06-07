using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	public static GameManager gm;

	private int vidas = 1;
    private int frutas = 0;

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
