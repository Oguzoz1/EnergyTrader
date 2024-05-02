using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    void OnMouseDown()
    {
        // Raycast to detect the clicked object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the clicked object is the one this script is attached to
            if (hit.collider.gameObject == gameObject)
            {
                // Call a method or perform any action with the reference to this GameObject
                HandleClick();
            }
        }
    }

    void HandleClick()
    {
        // This method will be called when the object is clicked
        PurchaseHandler.Instance.Target = gameObject.GetComponent<PlotHolder>();
        UIHandle.Instance.PurchaseMenuAppear();
    }
}
