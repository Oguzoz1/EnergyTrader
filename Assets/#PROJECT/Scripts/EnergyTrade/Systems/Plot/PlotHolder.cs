using UnityEngine;

public class PlotHolder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private PlotType _plotType;
    [SerializeField] private Plot[] _plots;
    [SerializeField] private string _description;
    public PlotType PlotType { get => _plotType; private set => _plotType = value; }
    public string Description { get => _description; private set => _description = value; }
    public Plot[] Plots { get => _plots; set => _plots = value; }

    public int EnergyIncome()
    {
        int targetValue = 0;
        for (int i = 0; i < _plots.Length; i++)
        {
            if (!_plots[i].empty)
            {
                //Random Income
                targetValue += Random.Range(150, 300);
            }
        }
        return targetValue;
    }
    public int PassiveIncome()
    {
        int targetValue = 0;
        for (int i = 0; i < _plots.Length; i++)
        {
            if (!_plots[i].empty)
            {
                //Randome Income
                targetValue += Random.Range(50, 150);
            }
        }
        return targetValue;
    }
    public void Build()
    {
        //Get Next EmptyPlot and spawn the prefab at the loc.
        //Make the bool true.

        Plot next = NextEmptyPlot();
        if(next != null)
        {
            int playerMoney = Player.Instance.Money;
            if(playerMoney >= next.Price)
            {
                Instantiate(next.Prefab, next.PlotTransform.position + next.offset, next.Prefab.transform.rotation);
                next.empty = false;
                next.PlotTransform.GetComponent<SquareGizmos>().UpdateColor(Color.red);
                Player.Instance.Money -= next.Price;
            }
            else
            {
                UIHandle.Instance.DialogueMessage("Üzgünüm... " + (next.Price - playerMoney) + " kadar paraya ihtiyacýn var");
            }
        }
        else
        {
            UIHandle.Instance.DialogueMessage("Daha fazla boþ alan yok!");
        }
    }
    private Plot NextEmptyPlot()
    {
        for (int i = 0; i < _plots.Length; i++)
        {
            if (_plots[i].empty == true) return _plots[i];
        }

        return null;
    }
    private void OnValidate()
    {
        Transform[] plotTransforms = GetComponentsInChildren<Transform>();

        for (int i = 0; i < _plots.Length; i++)
        {
            _plots[i].Name = "Plot " + (i + 1);
            if (plotTransforms[i+1])
                _plots[i].PlotTransform = plotTransforms[i+1];
        }
    }
}

public enum PlotType
{
    Solar,
    Wind,
    Plant
}
