using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationLandscape : MonoBehaviour
{

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
