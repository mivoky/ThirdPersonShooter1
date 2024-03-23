using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemy : MonoBehaviour
{
    public GameObject EndGameScreen;
    public GameObject gameplayUI;
    public int CountOfEnemy;

    public int _countOfKillEnemy;
    private void Start()
    {
        EndGameScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (_countOfKillEnemy == CountOfEnemy)
        {
            PlayerIsWin();
        }
    }
    private void PlayerIsWin()
    {
        gameplayUI.SetActive(false);
        EndGameScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<Shooting>().enabled = false;
    }
}
