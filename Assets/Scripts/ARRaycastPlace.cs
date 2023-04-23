using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycastPlace : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;
    public GameObject secObject;

    private GameObject placeObject;
    public Camera arCamera;

    public List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ganti Input.mousePosition nya dengan 1 UI nanti dengan letak vector2(0,0)

        RaycastHit hitObject;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hitObject, 50f, layerMask))
                {
                    //change this side with destory hitObject.obj instead instantiate new object
                    Vector3 newPoint = hitObject.point;
                    Instantiate(secObject, newPoint, Quaternion.identity);
                }
                else if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    if (placeObject == null)
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
        
    }
}
