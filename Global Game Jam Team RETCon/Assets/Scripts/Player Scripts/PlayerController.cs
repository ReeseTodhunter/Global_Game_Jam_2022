using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float projectileSpeed = 6f;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject BarrelEnd;
    [SerializeField]
    private GameObject projectile;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Take inputs in Update
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void FixedUpdate()
    {
        //Get a constant movement speed by using fixedDeltaTime
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Fire()
    {
        GameObject temp;
        temp = Instantiate(projectile, BarrelEnd.transform);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
    }
}