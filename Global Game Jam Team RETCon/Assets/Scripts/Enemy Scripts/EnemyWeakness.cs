using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakness : MonoBehaviour
{
    public int EnemyType;
    // 1 = Basic
    // 2 = Potato
    // 3 = Chilli
    // 4 = Potato then Chilli 
    // 5 = Chilli then Potato
    public int ChilliShield;    //hit with potato
    public int IceBlock;    //hit with chilli

    // Start is called before the first frame update
    void Start()
    {
        if (EnemyType == 4)
        {
            ChilliShield = 2;
        }
        else if( EnemyType == 5)
        {
            IceBlock = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
