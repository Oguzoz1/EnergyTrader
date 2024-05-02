using UnityEngine;

public class PriceManager : MonoBehaviour
{
    private static PriceManager _instance;
    public static PriceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PriceManager>();
                DontDestroyOnLoad(_instance.gameObject);
                if (_instance == null)
                {
                    Debug.LogError("PriceManager instance not found in the scene.");
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public int EnergyAmount { get => _energyAmount; set => _energyAmount = value; }

    [Header("Products")]
    [SerializeField] private int _energyAmount;
    [SerializeField] private int _energyBasePrice = 1;
    [SerializeField] private Country[] _countries;


}
