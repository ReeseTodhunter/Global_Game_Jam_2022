using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    GameObject gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Always Destroy this object on hit
        Destroy(this.gameObject);
        other.GetComponent<PlayerController>().Lives -= 1;
        if(other.GetComponent<PlayerController>().Lives <= 0)
        {
            Destroy(other.gameObject);
            gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().gameOver = true;
        }
    }
}
