using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    int EnemyType;
    GameObject Enemy;
    public string projectileType;

    Vector2 force = new Vector2(10.0f, 0.0f);

    void Awake()
    {
        if (projectileType == "SC")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Bound")
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
                        if (projectileType == "SP")
                        {
                            other.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                            other.GetComponent<EnemyPathing>().effectTimer = 2.0f;
                            other.GetComponent<EnemyPathing>().pushed = true;
                        }
                        else if (projectileType == "SC")
                        {
                            other.GetComponent<EnemyPathing>().effectTimer = 2.0f;
                            other.GetComponent<EnemyPathing>().stunned = true;
                        }
                        else
                        {
                            Destroy(other.transform.parent.gameObject);
                        }
                        break;
                    }
                case 2:     //Potato
                    {
                        if (projectileType == "P")
                        {
                            Destroy(other.transform.parent.gameObject);
                        }
                        else if (projectileType == "SP")
                        {

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
                        else if (projectileType == "C" && Enemy.GetComponent<EnemyWeakness>().ChilliShield <= 0)
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
}
