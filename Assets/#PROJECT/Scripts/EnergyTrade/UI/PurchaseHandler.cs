using UnityEngine;

public class PurchaseHandler : MonoBehaviour
{
    [SerializeField] private PlotHolder _target;

    private static PurchaseHandler _instance;
    public static PurchaseHandler Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PurchaseHandler>();
                DontDestroyOnLoad(_instance.gameObject);
                if (_instance == null)
                {
                    Debug.LogError("PurchaseHandler instance not found in the scene.");
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    public PlotHolder Target { get => _target;  set => _target = value; }

    public void PurchaseSolar()
    {
        if(_target.PlotType != PlotType.Solar)
        {
            //ERROR MESSAGE HERE
            UIHandle.Instance.DialogueMessage(_target.Description);
        }
        else
        {
            //Build next empty slot PlotHolder.Build()
            _target.Build();
        }
    }
    public void PurchaseWind()
    {
        if (_target.PlotType != PlotType.Wind)
        {
            //ERROR MESSAGE HERE
            UIHandle.Instance.DialogueMessage(_target.Description);

        }
        else
        {
            //Build next empty slot PlotHolder.Build()
            _target.Build();
        }
    }
    public void PurchasePlant()
    {
        if (_target.PlotType != PlotType.Plant)
        {
            //ERROR MESSAGE HERE
            UIHandle.Instance.DialogueMessage(_target.Description);

        }
        else
        {
            //Build next empty slot PlotHolder.Build()
            _target.Build();

        }
    }
}
