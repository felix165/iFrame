using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private GameObject frame;
    GameObject picture;
    Vector3 oriScale;
    // Start is called before the first frame update
    void Start()
    {
        oriScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setFrame(GameObject frame)
    {
        Destroy(PlaceManager.instance.selectedObject.transform.Find("Frame").gameObject);
        Instantiate(frame, PlaceManager.instance.selectedObject.transform);
    }
    public void setPicture(GameObject picture)
    {
        Destroy(PlaceManager.instance.selectedObject.transform.Find("Picture").gameObject);
        Instantiate(picture, PlaceManager.instance.selectedObject.transform);
    }
    public GameObject getFrame()
    {
        return frame;
    }
    public GameObject getPicture()
    {
        return picture;
    }
    public void setScale(Vector3 scale)
    {
        this.transform.localScale= new Vector3(oriScale.x*scale.x, oriScale.y*scale.y, oriScale.z*scale.z);
    }
    public void resetScale()
    {
        this.transform.localScale = oriScale;
    }

}
