using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    int EnemyType;
    GameObject Enemy;
    public string projectileType;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " hit at time: " + Time.time);
        //Always Destroy this object on hit
        Destroy(this.gameObject);

        Enemy = other.gameObject;
        EnemyType = Enemy.GetComponent<EnemyWeakness>().EnemyType;
        switch (EnemyType)
        {
            case 1:     //Basic Enemy
            {
                Destroy(other.transform.parent.gameObject);
                break;
            }
            case 2:     //Potato
            {
                if(projectileType == "P")
                {
                    Destroy(other.transform.parent.gameObject);
                }
                break;
            }
            case 3:     //Chilli
            {
                if (projectileType == "C")
                {
                    Destroy(other.transform.parent.gameObject);
                }
                break;
            }
            case 4:     //Potato then Chilli
            {
                if (projectileType == "SP" && Enemy.GetComponent<EnemyWeakness>().ChilliShield > 0)
                {
                    Enemy.GetComponent<EnemyWeakness>().ChilliShield -= 1;
                }
                else if(projectileType == "C" && Enemy.GetComponent<EnemyWeakness>().ChilliShield <= 0)
                {
                    Destroy(other.transform.parent.gameObject);
                }
                break;
            }
            case 5:     //Chilli then Potato
            {
                if (projectileType == "SC" && Enemy.GetComponent<EnemyWeakness>().IceBlock > 0)
                {
                    Enemy.GetComponent<EnemyWeakness>().IceBlock -= 1;
                }
                else if (projectileType == "P" && Enemy.GetComponent<EnemyWeakness>().IceBlock <= 0)
                {
                    Destroy(other.transform.parent.gameObject);
                }
                break;
            }
        }
    }
}
