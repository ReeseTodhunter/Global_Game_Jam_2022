using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://youtu.be/yumoqNlaPCE
//https://youtu.be/t_ST7ectK2Q

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]
    private int FlightPath = 0;

    private int Turn = 1;

    private float Counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (FlightPath < 4)
        {
            SimplePathing(FlightPath);
        }
        if (FlightPath > 4)
        {
            RotationPathing(FlightPath, Turn);
        }
    }
    
    void SimplePathing(int Path)
    {
        Counter += Time.fixedDeltaTime;

        if (Counter >= 2)
        {
        }
            transform.position = new Vector2((transform.position.x * Mathf.Cos(transform.rotation.z)), (transform.position.y * Mathf.Sin(transform.rotation.z)));
        
    }
    void RotationPathing(int Path, int Turn)
    {
        
    }
}
