using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BankAction : MonoBehaviour
{
    public float BankedMoney;
    public Text monehText;
    public Text textboxText;
    public Text depositPopoutText;
    public Text withdrawPopoutText;
    public InputField depositAmount;
    public InputField withdrawAmount;
    private void Awake() {
        monehText.text = "$" + BankedMoney.ToString();
        textboxText.text = "You entered BankName. What will you do?";
    }
    public void DepositAmt() {
        float amt = 0;
        try { amt = float.Parse(depositAmount.text); }
        catch(Exception e) {
            Debug.Log("User entered a non integer/float value into " + depositAmount + "\n" + e);
            return;
        }
        PlayerData.Instance.Money -= amt;
        BankedMoney += amt;
        monehText.text = "$" + BankedMoney.ToString();
        textboxText.text = "You have deposited $" + amt.ToString() + ".";
    }
    public void WithdrawAmt() {
        float amt = 0;
        try { amt = float.Parse(withdrawAmount.text); }
        catch (Exception e) {
            Debug.Log("User entered a non integer/float value into " + withdrawAmount + "\n" + e);
            return;
        }
        BankedMoney -= amt;
        PlayerData.Instance.Money += amt;
        monehText.text = "$" + BankedMoney.ToString();
        textboxText.text = "You have withdrawn $" + amt.ToString() + ".";
    }
    public void AddInterest(float total) { //call this when you proceed to the next day
        BankedMoney += (BankedMoney / 100) * 10;
    }
    public void Deposit() {
        depositPopoutText.text = "you have $" + BankedMoney + ".\nHow much do you want to deposit?";
    }
    public void Withdraw() {
        withdrawPopoutText.text = "you have $" + BankedMoney + ".\nHow much do you want to withdraw?";
    }
    public void clearDataField() {
        depositAmount.text = "";
        withdrawAmount.text = "";
        textboxText.text = "You hesitated.";
    }
    public void ExitBank()
    {
        textboxText.text = "You leave the bank.";
        SceneManager.UnloadSceneAsync("BankAction");
    }
}
