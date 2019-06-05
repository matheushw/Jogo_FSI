using UnityEngine;
using System.Collections;
public class crouch : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        crouching = false;
    }
    // Update is called once per frame
    public GameObject player;
    public bool crouching;
    void Update()
    {
        Debug.Log(crouching);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouching)
            {
                player.GetComponent<BoxCollider2D>().enabled = false;
                crouching = false;
            }
            else
            {
                player.GetComponent<BoxCollider2D>().enabled = true;
                crouching = true;
            }
        }
    }
}