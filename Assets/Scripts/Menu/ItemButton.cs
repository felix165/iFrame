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
    public ItemsScrollViewController.Type type;
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
        GameObject.Find("DebugText").GetComponent<TMP_Text>().text= "Selected "+ this.itemIndex+" type "+type;
        switch (type)
        {
            case ItemsScrollViewController.Type.Frame:
                PlaceManager.instance.selectedObject.GetComponent<ObjectManager>().setFrame(item);
                break;
            case ItemsScrollViewController.Type.Picture:
                PlaceManager.instance.selectedObject.GetComponent<ObjectManager>().setPicture(item);
                break;
        }

    }
}
