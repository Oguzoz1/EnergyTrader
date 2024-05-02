using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Player>();
                DontDestroyOnLoad(_instance.gameObject);
                if (_instance == null)
                {
                    Debug.LogError("PlayerCurrency instance not found in the scene.");
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public int Energy { get => _energy;  set => _energy = value; }
    public int Money { get => _money;  set => _money = value; }

    [Header("Settings")]
    [SerializeField] private float _timeInterval = 3f;
    [SerializeField] private float _timeElapsed = 0f;

    [Header("Plots")]
    [SerializeField] private PlotHolder[] _plots;

    [Header("Currency")]
    [SerializeField] private int _energy = 0;
    [SerializeField] private int _consumption = 0;
    [SerializeField] private int _money = 500;

    private int _baseGrowthRate = 1;
    private int _maxRandomIncrease = 30;
    void Start() => Init();
    void Update() => MainFunction();
    private void Init()
    {
        UIHandle.Instance.UpdateEnergy(_energy.ToString());
        UIHandle.Instance.UpdateMoney(_money.ToString());
        UIHandle.Instance.UpdateConsumption(_consumption.ToString());
    }
    private void MainFunction()
    {
        _timeElapsed += Time.deltaTime;
        if(_timeElapsed >= _timeInterval)
        {
            //Execute Func
            UpdateEnergy();
            UpdateMoney();
            UpdateConsumption();
            _timeElapsed = 0;
        }
    }
    private void UpdateConsumption()
    {
        _consumption += Random.Range(0, _maxRandomIncrease) + _baseGrowthRate;
        UIHandle.Instance.UpdateConsumption(_consumption.ToString());
    }
    private void UpdateEnergy()
    {
        _energy += (TotalEnergyIncome() - _consumption);  
        UIHandle.Instance.UpdateEnergy(_energy.ToString());
    }
    public void UpdateEnergy(int valueToAdd)
    {
        _energy += valueToAdd;
        UIHandle.Instance.UpdateEnergy(_energy.ToString());
    }
    private void UpdateMoney()
    {
        //Set passive income
        _money += TotalIncome();
        UIHandle.Instance.UpdateMoney(_money.ToString());
    }
    public void UpdateMoney(int valueToAdd)
    {
        _money += valueToAdd;
        UIHandle.Instance.UpdateMoney(_money.ToString());
    }
    public int TotalIncome()
    {
        int targetValue = 0;
        foreach (PlotHolder plotHolder in _plots)
        {
            targetValue += plotHolder.PassiveIncome();
        }
        return targetValue;
    }
    public int TotalEnergyIncome()
    {
        int targetValue = 0;
        foreach (PlotHolder plotHolder in _plots)
        {
            targetValue += plotHolder.EnergyIncome();
        }
        return targetValue;
    }
}
