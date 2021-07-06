using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaSetter : MonoBehaviour
{

    public Canvas canvas;
    RectTransform panelSafeArera;

    Rect currentSafeArea = new Rect();
    ScreenOrientation currenOrientation = ScreenOrientation.AutoRotation;

    // Start is called before the first frame update
    void Start()
    {
        panelSafeArera = GetComponent<RectTransform>();

        //store current values

        currenOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;

        ApplySafeArea();
    }
    void ApplySafeArea()
    {
        if (panelSafeArera == null)
            return;

        Rect safeArea = Screen.safeArea;

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;

        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        //asign values to the panel

        panelSafeArera.anchorMin = anchorMin;
        panelSafeArera.anchorMax = anchorMax;

       

        currenOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;

    }
    // Update is called once per frame
    void Update()
    {
        //script updating the anchors each time that the resolution 
        //is changing during runtime

        if ((currenOrientation!=Screen.orientation)||(currentSafeArea!=Screen.safeArea))
        {
            ApplySafeArea();
        }
    }
}
