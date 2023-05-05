using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private GameObject frame;
    private GameObject picture;
    [SerializeField]
    private Transform frameObj;
    [SerializeField]
    private Transform pictureObj;
    

    [SerializeField]
    private float transformSpeed = 0.04f;
    [SerializeField]
    private float scaleSpeed = 0.02f;

    private Vector3 oriScale;
    private Vector3 oriPosition;
    // Start is called before the first frame update
    void Start()
    {
        oriScale = this.transform.localScale;
        oriPosition = this.transform.position;
        Unselect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setFrame(GameObject frame)
    {
        GameObject.Find("DebugText").GetComponent<TMP_Text>().text = "SetFrame"+ frame.ToString();
        destroyChild(frameObj.gameObject);
        Instantiate(frame, frameObj);

    }
    public void setPicture(GameObject picture)
    {
        GameObject.Find("DebugText").GetComponent<TMP_Text>().text = "SetPicture";
        destroyChild(pictureObj.gameObject);
        Instantiate(picture, pictureObj);
    }
    public GameObject getFrame()
    {
        return frame;
    }
    public GameObject getPicture()
    {
        return picture;
    }

    void destroyChild(GameObject obj)
    {
        for (var i = obj.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(obj.transform.GetChild(i).gameObject);
        }
    }
    public void transfromObject(Vector2 deltaPos)
    {
        transform.position += new Vector3(deltaPos.x, deltaPos.y, 0) * Time.deltaTime * transformSpeed;
    }

    public void scalingObject(Vector2 deltaRange)
    {
        transform.localScale += new Vector3(deltaRange.x,deltaRange.y,0) * Time.deltaTime * scaleSpeed;
    }
    public void ResetChange()
    {
        transform.localScale = oriScale;
        transform.position = oriPosition;
    }
    
    public void confirmChange()
    {
        oriScale = transform.localScale;
        oriPosition= transform.position;
    }

    public void Selected()
    {
        transform.Find("SelectIndicator").transform.gameObject.SetActive(true);
    }
    public void Unselect()
    {
        transform.Find("SelectIndicator").transform.gameObject.SetActive(false);
    }

}
