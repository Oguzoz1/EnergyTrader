using UnityEngine;

public class ScreenCaptureExample : MonoBehaviour
{
    private int screenshotCounter = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            string screenshotName = "Screenshot_" + screenshotCounter + ".png";
            ScreenCapture.CaptureScreenshot(screenshotName);
            screenshotCounter++;
        }
    }
}
