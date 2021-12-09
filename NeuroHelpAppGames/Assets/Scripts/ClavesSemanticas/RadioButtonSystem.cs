using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RadioButtonSystem : MonoBehaviour
{
    ToggleGroup toggleGroup;

    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (toggleGroup.name=="ToggleGroup1")
        {
            if (toggle.GetComponentInChildren<Text>().text == ClavesSemanticas.GetInstance().object1.text)
            {
                Debug.Log("Es correcto 1");

                ClavesSemanticas.GetInstance().prenderVisto1();
                ClavesSemanticas.GetInstance().isToggle1Correct= true;
            }
            else
            {
                ClavesSemanticas.GetInstance().prenderEquiz1();
                ClavesSemanticas.GetInstance().isToggle1Correct = false;
            }
            
        }
        if (toggleGroup.name == "ToggleGroup2")
        {
            if (toggle.GetComponentInChildren<Text>().text == ClavesSemanticas.GetInstance().object2.text)
            {
                Debug.Log("Es correcto 2");
                ClavesSemanticas.GetInstance().prenderVisto2();
                ClavesSemanticas.GetInstance().isToggle2Correct = true;

            }
            else
            {
                ClavesSemanticas.GetInstance().prenderEquiz2();
                ClavesSemanticas.GetInstance().isToggle2Correct = false;
            }

        }
        if (toggleGroup.name == "ToggleGroup3")
        {
            if (toggle.GetComponentInChildren<Text>().text == ClavesSemanticas.GetInstance().object3.text)
            {
                Debug.Log("Es correcto 3");
                ClavesSemanticas.GetInstance().prenderVisto3();
                ClavesSemanticas.GetInstance().isToggle3Correct = true;
            }
            else
            {
                ClavesSemanticas.GetInstance().prenderEquiz3();
                ClavesSemanticas.GetInstance().isToggle3Correct = false;
            }

        }

        Debug.Log(toggle.name + " _ " + toggle.GetComponentInChildren<Text>().text);
    }
}