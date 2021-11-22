using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    private int hungerLoss = 10;
    public GameObject popup;
    public static bool bedClicked;
    public static bool fadeNow;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        //the colours is to show play click on object
        popup.SetActive(false);
    }

    private void OnMouseDown()
    {
        //this makes it that player cannot click other object while
        //still interacting with current object
        if (!Computer.comClicked && !Phone.phoneClicked)
        {
            sr.color = Color.black;
            bedClicked = true;
            popup.SetActive(true);
            //popup is showing
        }
    }
    private void OnMouseUp()
    {
        sr.color = originalColor;
    }

    //this 2 methods is for the buttons using EventSystem onclick()
    public void BedDisappear()
    {
        bedClicked = false;
        popup.SetActive(false);
        //popup is not showing
    }
    
    public void SleepNow()
    {
        fadeNow = true;
        PlayerData.Instance.Energy = 100;
        PlayerData.Instance.Hunger -= hungerLoss;
        PlayerData.Instance.day += 1;

        //checking values
        Debug.Log("Energy is " + PlayerData.Instance.Energy);
        Debug.Log("Happinesss is " + PlayerData.Instance.Happiness);
        Debug.Log("Money is " + PlayerData.Instance.Money);
        Debug.Log("Hunger is " + PlayerData.Instance.Hunger);
        Debug.Log("Day " + PlayerData.Instance.day);
        BedDisappear();
    }
}
