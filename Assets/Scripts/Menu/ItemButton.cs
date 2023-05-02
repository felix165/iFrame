using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    enum Type
    {
        Frame,
        Picture,
    }
    [HideInInspector] public int itemIndex;
    [HideInInspector] public ItemsScrollViewController itemsScrollViewController;

    [SerializeField] TextMeshProUGUI text;

    public GameObject item;
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
        Debug.Log(itemIndex.ToString());
        GameObject.Find("DebugText").GetComponent<TMP_Text>().text= "Selected"+ this.itemIndex;
        //Change object frame/pict with this item

    }
}
