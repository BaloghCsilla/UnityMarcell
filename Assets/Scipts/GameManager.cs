using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int startLives = 100;
    [SerializeField] int startMoney = 100;

    static float gameTime;
    static int lives;
    static int money;

    public static int Money 
    {
        get => money;
        set
        {
            money = Mathf.Max(0, value);
            Debug.Log($"Gamer money: {money}");
        } 
    }

    private void Start()
    {
        lives = startLives;
        money = startMoney;
    }

    public static void Damage(int damage)
    {
        lives -= damage;
        if(lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }

}
