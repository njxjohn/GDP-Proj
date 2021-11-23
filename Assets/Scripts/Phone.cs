using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    public int happinessGain = 5;
    public int hungerGain = 30;
    public int moneyTaken = 25;
    public static bool phoneClicked;
    public GameObject popup;

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
        if (!Bed.bedClicked && !Computer.comClicked)
        {
            sr.color = Color.black;
            phoneClicked = true;
            popup.SetActive(true);
            //show popup
        }
    }
    private void OnMouseUp()
    {
        sr.color = originalColor;
    }

    //this 2 methods is for the buttons using EventSystem onclick()
    public void PhoneDisappear()
    {
        phoneClicked = false;
        popup.SetActive(false);
        //stop showing popup
    }

    public void UsingPhone()
    {
        PlayerData.Instance.Money -= moneyTaken;
        PlayerData.Instance.Happiness += happinessGain;
        PlayerData.Instance.Hunger += hungerGain;
        
        if (PlayerData.Instance.Happiness > 50)
        {
            PlayerData.Instance.Happiness = 50;
        }

        if (PlayerData.Instance.Hunger > 50)
        {
            PlayerData.Instance.Hunger = 50;
        }

        //check values
        Debug.Log("Energy is " + PlayerData.Instance.Energy);
        Debug.Log("Happinesss is " + PlayerData.Instance.Happiness);
        Debug.Log("Hunger is " + PlayerData.Instance.Hunger);
        Debug.Log("Money is " + PlayerData.Instance.Money);
        PhoneDisappear();
    }
}
