using UnityEngine;
using TMPro;

public class UIHandle : MonoBehaviour
{
    private static UIHandle _instance;
    public static UIHandle Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIHandle>();
                DontDestroyOnLoad(_instance.gameObject);
                if (_instance == null)
                {
                    Debug.LogError("UIHandle instance not found in the scene.");
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    [Header("Currency")]
    public TextMeshProUGUI PlayerMoneyText;
    public TextMeshProUGUI PlayerEnergyText;
    public TextMeshProUGUI PlayerConsumptionText;

    [Header("UI ITEMS")]
    public GameObject PurchaseMenu;
    public GameObject DialogueBox;
    public GameObject Character;

    #region Player Currency
    public void UpdateMoney(string value)
    {
        PlayerMoneyText.text = value;
    }
    public void UpdateEnergy(string value)
    {
        PlayerEnergyText.text = value;
    }
    public void UpdateConsumption(string value)
    {
        PlayerConsumptionText.text = value;
    }
    #endregion

    #region UI Items
    public void DialogueMessage(string content)
    {
        //Set content of the dialogue box as a warning.
        DialogueBox.SetActive(true);
        Character.SetActive(true);
        TextMeshProUGUI text = DialogueBox.GetComponentInChildren<TextMeshProUGUI>();

        text.text = content;
    }
    public void PurchaseMenuAppear()
    {
        //Purchase Menu Appears
        PurchaseMenu.SetActive(true);
    }
    #endregion
}
