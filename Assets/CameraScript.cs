using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject player;       //Variavel que armazena uma referencia para o GameObject do jogador

    private Vector3 offset;         //Variavel que armazena a distancia entre o jogador e a câmera

    // O código começa a ser lido nesse bloco
    void Start () 
    {
        //Calcula a distancia entre o jogador e a camera para ser considerado no calculo seguinte.
        offset = transform.position - player.transform.position;
        
    }
    
    // Esse bloco é executado depois do Start
    void LateUpdate () 
    {
        // Define a posição da câmera igual a do jogador, mantendo a distância calculada previamente
        //transform.position = player.transform.position + offset;
        transform.position = new Vector3(player.transform.position.x + offset.x,transform.position.y,transform.position.z);
    }
}