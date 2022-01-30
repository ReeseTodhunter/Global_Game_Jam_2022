using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    GameObject gameManager;
    public Vector3 direction;
    public float moveSpeed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Bound")
        {
            //Always Destroy this object on hit
            Destroy(this.gameObject);
            other.GetComponent<PlayerController>().Lives -= 1;
            if (other.GetComponent<PlayerController>().Lives <= 0)
            {
                Destroy(other.gameObject);
                gameManager = GameObject.Find("GameManager");
                gameManager.GetComponent<GameManager>().gameOver = true;
            }
        }
    }

    void FixedUpdate()
    {
        this.transform.position = this.transform.position += direction * moveSpeed * Time.fixedDeltaTime;
    }
}
