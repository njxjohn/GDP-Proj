using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour
{
    PlayerData _inst;
    public Text OtherInfoText;
    public Text NameText;
    public Slider Energy;
    public Slider Hunger;
    public Slider Happiness;
    private void Awake() {
        if (_inst == null) _inst = PlayerData.Instance;
        Energy.value = (float)_inst.Energy / 100;
        Hunger.value = (float)_inst.Hunger / 100;
        Happiness.value = (float)_inst.Happiness / 100;
        OtherInfoText.text = "Day " + _inst.day + "\nMoney: $" + _inst.Money;
        NameText.text = _inst.name;
    }
    public void EnterHome() { SceneManager.LoadSceneAsync("HomeAction", LoadSceneMode.Additive); }
    public void EnterWorkplace() { SceneManager.LoadSceneAsync("WorkplaceAction", LoadSceneMode.Additive); }
    public void EnterBank() { SceneManager.LoadSceneAsync("BankAction", LoadSceneMode.Additive); }
    public void EnterStore() { SceneManager.LoadSceneAsync("StoreAction", LoadSceneMode.Additive); }
}
