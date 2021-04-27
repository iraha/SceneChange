using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void GameOver()
    {
        if (Input.GetKeyDown("e"))
        {
            gameOverUI.SetActive(true);
        }

    }
}
