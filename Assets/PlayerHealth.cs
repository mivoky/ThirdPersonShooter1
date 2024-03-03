using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxHealth;

    private void Start()
    {
        gameplayUI.SetActive(true);
        gameOverScreen.SetActive(false);
        _maxHealth = Health;
        DrawGameBar();
    }
    private void Update()
    {
        DrawGameBar();
    }
    public void DealDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            PlayerIsDead();
        }
        DrawGameBar();
    }

    public void DrawGameBar()
    {
        valueRectTransform.anchorMax = new Vector2(Health / _maxHealth, 1);
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<Shooting>().enabled = false;
    }
}
