using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    string parentName,panelName;
    int searcheadPos;

    public void OnDrop(PointerEventData eventData)//cuando un tiem le caiga encima
    {
        if (!item) // si nop existe el item
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
            panelName = QueyDonde.GetInstance().nombreRndm.name+"(Clone)";
            parentName = transform.parent.name;
            print("parent name " + parentName);

            searcheadPos = QueyDonde.GetInstance().randPosition;
            print("rand Position " + searcheadPos);

            switch (searcheadPos)
            {
                case 0:
                    if((parentName== "TarjetaVacia(Clone)")&&panelName==item.name)
                    {
                        correctA();
                    }
                    else
                    {
                        inCorrectA();
                    }
                    break;
                case 1:
                    if (parentName == "TarjetaVacia(Clone)(Clone)" && panelName == item.name)
                    {
                        correctA();
                    }
                    else
                    {
                        inCorrectA();
                    }
                    break;
                case 2:
                    if (parentName == "TarjetaVacia(Clone)(Clone)(Clone)" && panelName == item.name)
                    {
                        correctA();
                    }
                    else {
                        inCorrectA();
                    }
                    break;
                default:
                    
                    break;
            }
            if (item)
            {

            }



        }

    }

    public void correctA()
    {
        QueyDonde.GetInstance().unactivePoolItems();
        StartCoroutine(QueyDonde.GetInstance().CorrectoWait());
        item.SetActive(false);
        


    }

    public void inCorrectA()
    {
        QueyDonde.GetInstance().unactivePoolItems();
        StartCoroutine(QueyDonde.GetInstance().InCorrectoWait());
        
        
    }

   

    void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }
}
