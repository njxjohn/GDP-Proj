using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    public int happinessGain = 20;
    public int energyTaken = 30;
    public GameObject popup;
    public static bool comClicked;

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
        //Cannot interact with object until done interacting with current object
        if (!Bed.bedClicked && !Phone.phoneClicked)
        {
            sr.color = Color.black;
            comClicked = true;
            popup.SetActive(true);
            //show popup
        }
    }
    private void OnMouseUp()
    {
        sr.color = originalColor;
    }

    //this 2 methods is for the buttons using EventSystem onclick()
    public void ComDisappear()
    {
        comClicked = false;
        popup.SetActive(false);
        //stop showing popup
    }

    public void UsingCom()
    {
        PlayerData.Instance.Energy -= energyTaken;
        PlayerData.Instance.Happiness += happinessGain;

        if (PlayerData.Instance.Happiness > 50)
        {
            PlayerData.Instance.Happiness = 50;
        }

        Debug.Log("Energy is " + PlayerData.Instance.Energy);
        Debug.Log("Happinesss is " + PlayerData.Instance.Happiness);
        ComDisappear();
    }
}
