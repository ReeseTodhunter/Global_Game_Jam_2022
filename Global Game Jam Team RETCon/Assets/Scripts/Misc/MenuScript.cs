using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    // Start is called before the first frame update
    public void Begin()
    {
        SceneManager.LoadScene("Level");
        gameManager.GetComponent<GameManager>().mainMenu = false;
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
