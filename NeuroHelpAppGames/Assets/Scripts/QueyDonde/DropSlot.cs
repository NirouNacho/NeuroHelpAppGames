using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    string parentName;
    int searcheadPos;

    public void OnDrop(PointerEventData eventData)//cuando un tiem le caiga encima
    {
        if (!item) // si nop existe el item
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
            
            parentName = transform.parent.name;
            print("parent name " + parentName);

            searcheadPos = QueyDonde.GetInstance().randPosition;
            print("rand Position " + searcheadPos);

            switch (searcheadPos)
            {
                case 0:
                    if(parentName== "TarjetaVacia(Clone)")
                    {
                        StartCoroutine(QueyDonde.GetInstance().CorrectoWait());
                    }
                    else
                    {
                        StartCoroutine(QueyDonde.GetInstance().InCorrectoWait());
                    }
                    break;
                case 1:
                    if (parentName == "TarjetaVacia(Clone)(Clone)")
                    {
                        StartCoroutine(QueyDonde.GetInstance().CorrectoWait());
                    }
                    else
                    {
                        StartCoroutine(QueyDonde.GetInstance().InCorrectoWait());
                    }
                    break;
                case 2:
                    if (parentName == "TarjetaVacia(Clone)(Clone)(Clone)")
                    {
                        StartCoroutine(QueyDonde.GetInstance().CorrectoWait());
                    }
                    else {
                        StartCoroutine(QueyDonde.GetInstance().InCorrectoWait());
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
    void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }
}
