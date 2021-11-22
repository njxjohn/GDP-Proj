using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    public float Money;
    public int Energy;
    public int Hunger;
    public int Happiness;
    public int day;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Money = 300;
            Energy = 100;
            Hunger = 50;
            Happiness = 50;
            day = 1;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("Total Energy is " + Energy);
        Debug.Log("Total Happinesss is " + Happiness);
        Debug.Log("Total Hunger is " + Hunger);
        Debug.Log("Total Money is " + Money);
        Debug.Log("Day " + day);
    }
}
