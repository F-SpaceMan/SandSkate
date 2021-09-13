using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morre : MonoBehaviour
{
    public GameController gameController;

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag.Equals("Player"))
            gameController.GameOver();
    }
    
}
