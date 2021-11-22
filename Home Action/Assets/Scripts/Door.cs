using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        //the colours is to show play click on object
    }

    private void OnMouseDown()
    {
        //Cannot interact with object until done interacting with current object
        if (!Bed.bedClicked && !Phone.phoneClicked && !Computer.comClicked)
        {
            sr.color = Color.black;
            //change this later
            //SceneManager.LoadSceneAsync("World Map", LoadSceneMode.Single);
            //Leave the map
            SceneManager.UnloadSceneAsync("Home Action");
            Debug.Log("Total Energy is " + PlayerData.Instance.Energy);
            Debug.Log("Total Happinesss is " + PlayerData.Instance.Happiness);
            Debug.Log("Total Hunger is " + PlayerData.Instance.Hunger);
            Debug.Log("Total Money is " + PlayerData.Instance.Money);
        }
    }
    private void OnMouseUp()
    {
        sr.color = originalColor;
    }
}
