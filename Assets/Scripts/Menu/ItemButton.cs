using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    [HideInInspector] public int itemIndex;
    [HideInInspector] public ItemsScrollViewController itemsScrollViewController;

    [SerializeField] TextMeshProUGUI text;
    public Type type;
    [HideInInspector] public GameObject item;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        text.text = itemIndex.ToString();
    }
    // Update is called once per frame
    void Update()
    {
 
    }
    public void OnItemButtonClick()
    {
        var placeManager = FindObjectOfType<PlaceManager>();
        if (placeManager == null)
        {
            GameObject.Find("DebugText").GetComponent<TMP_Text>().text = "null";
        }
        else
        {
            GameObject.Find("DebugText").GetComponent<TMP_Text>().text = PlaceManager.Instance.selectedObject.ToString();
        }
        switch (type)
        {
            case Type.Frame:
                PlaceManager.Instance.selectedObject.GetComponent<ObjectManager>().setFrame(item);
                break;
            case Type.Picture:
                PlaceManager.Instance.selectedObject.GetComponent<ObjectManager>().setPicture(item);
                break;
        }

        //GameObject.Find("DebugText").GetComponent<TMP_Text>().text = PlaceManager.instance.selectedObject.name.ToString();
        /*if (type==Type.Frame)
        {
            GameObject.Find("DebugText").GetComponent<TMP_Text>().text = "on item buttonClick with " + type+"  ";
*//*            PlaceManager.instance.selectedObject.GetComponent<ObjectManager>().setFrame(item);*//*
        }
        else
        {
            GameObject.Find("DebugText").GetComponent<TMP_Text>().text = "on item buttonClick with " + type+ "  ";
*//*            PlaceManager.instance.selectedObject.GetComponent<ObjectManager>().setPicture(item);
*//*
        }*/

    }
}
