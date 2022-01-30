using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.name == "BasicEnemy")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}