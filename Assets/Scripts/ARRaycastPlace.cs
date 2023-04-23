using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycastPlace : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;

    private GameObject placeObject;
    public Camera arCamera;

    public List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        //ganti Input.mousePosition nya dengan 1 UI nanti dengan letak vector2(0,0)
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitObject;
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hitObject, 50f, layerMask))
            {
                //change this side with destory hitObject.obj instead instantiate new object
                Vector3 newPoint = hitObject.point;
                Instantiate(objectToPlace,newPoint, Quaternion.identity);
            }
            else if(raycastManager.Raycast(ray,hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                if(placeObject == null) 
                {
                    placeObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                }
                else
                {
                    placeObject.transform.position = hitPose.position;
                    placeObject.transform.rotation = hitPose.rotation;
                }


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
