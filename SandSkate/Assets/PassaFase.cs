using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaFase : MonoBehaviour
{
    public GameController gameController;

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag.Equals("Player"))
            gameController.Completed();
    }
}
