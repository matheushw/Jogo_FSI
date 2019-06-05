using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    	vidas += vida;
    }

    public int GetVidas () {
    	return vidas;
    }

    public void SetFrutas (int fruta) {
        frutas += fruta;
        AtualizaHud();
    }

    public void AtualizaHud() {
        GameObject.Find("FrutaText").GetComponent<Text>().text = frutas.ToString();
    }
}
