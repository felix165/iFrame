using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScrollViewController : MonoBehaviour
{
    [SerializeField] int numberOfItem;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform itemParent;
    // Start is called before the first frame update
    void Start()
    {
        LoadItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadItem()
    {
        for(int i = 0; i<numberOfItem; i++)
        {
            GameObject itemObj = Instantiate(itemPrefab,itemParent);
            itemObj.GetComponent<ItemButton>().itemIndex = i+1;
            itemObj.GetComponent<ItemButton>().itemsScrollViewController= this;
        }
    }

}
