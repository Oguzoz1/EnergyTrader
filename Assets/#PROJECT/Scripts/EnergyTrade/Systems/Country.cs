using UnityEngine;

[System.Serializable]
public class Country 
{
    public string Name;
    [Range(0, 1f)] public float MaxIncreaseRate;
    public Vector2 EnergyProduction;
    public Vector2 EnergyConsumption;

    public void UpdateEnergyProduction()
    {
        float random = Random.Range(0f, MaxIncreaseRate);


    }
    public void UpdateEnergyConsumption()
    {

    }
}
