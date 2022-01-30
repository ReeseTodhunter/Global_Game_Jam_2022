using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakness : MonoBehaviour
{
    [SerializeField]
    private int EnemyType;

    string[] Weakness;
    private bool WeakToPot = false;

    private bool WeakToChil = false;

    private bool WeaktoChilSp = false;

    private bool WeakToPotSp = false;
    // Start is called before the first frame update
    void Start()
    {
        switch (EnemyType)
            {
            case 1:
                Weakness = new string[] { "Any" };
                break;
            case 2:
                Weakness = new string[] { "Potato" };
                break;
            case 3:
                Weakness = new string[] { "Chili" };
                break;
            case 4:
                Weakness = new string[] { "ChilSp", "Potato" };
                break;
            case 5:
                Weakness = new string[] { "PotSp", "Chili" };
                break;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBulletHit() { }
}
