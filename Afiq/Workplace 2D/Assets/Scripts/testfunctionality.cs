using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class testfunctionality : MonoBehaviour
{
    public int MoneyEarned = 100;
    public float minimumChanceToPromote = 0.1f;
    public float currentChanceToPromote;
    public void Work()
    {
        SceneManager.LoadScene(1);
        PlayerData.Instance.Money += MoneyEarned;
        Debug.Log("You earned $100 from working today!");
        PlayerData.Instance.Energy -= 50;
        Debug.Log("You lost 50 energy from working.");
        currentChanceToPromote += 0.1f;
    }
    public void Promotion()
    {
        SceneManager.LoadScene(2);

        if(currentChanceToPromote >= minimumChanceToPromote)
        {
            if(currentChanceToPromote == 1f)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                MoneyEarned += 50;
                currentChanceToPromote = 0.0f;
            }
            if(Random.value > currentChanceToPromote)
            {
                Debug.Log("Congratulations, You have been promoted and now have higher pay!");
                MoneyEarned += 50;
                currentChanceToPromote = 0.0f;
            }
            else
            {
                Debug.Log("Sorry, You have failed to promote!");
            }
        }
        else
        {
            Debug.Log("Sorry, You do not meet the requirements!");
        }
    }
}
