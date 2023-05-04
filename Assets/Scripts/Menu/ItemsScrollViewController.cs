using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScrollViewController : MonoBehaviour
{
    public enum Type
    {
        Frame,
        Picture,
    }
    [SerializeField] int numberOfItem;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform itemParent;
    [SerializeField] Type type;
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
        switch (type)
        {
            case Type.Frame:
                for (int i = 0; i < AssetsManager.Instance.frames.Length; i++)
                {
                    GameObject itemObj = Instantiate(itemPrefab, itemParent);
                    ItemButton item = itemObj.GetComponent<ItemButton>();
                    item.itemIndex = i + 1;
                    item.itemsScrollViewController = this;
                    item.type = Type.Frame;
                    item.item = AssetsManager.Instance.frames[i];
                    item.image.sprite = AssetsManager.Instance.spriteOfFrame[i];
                }
            break;
            case Type.Picture:
                for (int i = 0; i < AssetsManager.Instance.pictures.Length; i++)
                {
                    GameObject itemObj = Instantiate(itemPrefab, itemParent);
                    ItemButton item = itemObj.GetComponent<ItemButton>();
                    item.itemIndex = i + 1;
                    item.itemsScrollViewController = this;
                    item.type = Type.Picture;
                    item.item = AssetsManager.Instance.pictures[i];
                    item.image.sprite = AssetsManager.Instance.spriteOfPicture[i];
                }
            break;
        }
        
    }

}
