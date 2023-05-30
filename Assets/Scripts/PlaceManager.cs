using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARSubsystems;
using System;

public class PlaceManager : MonoBehaviour
{
    /*public enum TransformMode
    {
        None,
        Tranform,
        Scale,
    }*/
    public enum Mode
    {
        MainMode,
        SelectingMode,
        EditingMode,
    }

    //make enum for scale type (bigger/smaller)
    public static PlaceManager Instance;

    private PlaceIndicator placeIndicator;
    public GameObject objectToPlace;
    public Camera arCamera;
    public LayerMask layerMask;
    static public Mode mode = Mode.MainMode;
    /*static public TransformMode transformMode = TransformMode.None;*/

    public TextMeshProUGUI text; //For Debug use

    private GameObject newPlacedObject;
    [HideInInspector] public GameObject selectedObject;
    public float speed=0.1f;


    public UnityEvent onClickFailed;
    public UnityEvent onClickSuccess;

    // Start is called before the first frame update
    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount> 0)
        {
            //text.text = Input.touches[0].phase.ToString();
            if (mode == Mode.MainMode)
            {
                SelectObject();
            }
            else if (mode == Mode.SelectingMode)
            {
                
                if(Input.touchCount==1)
                {
                    if (Input.touches[0].phase == TouchPhase.Moved)
                    {
                        selectedObject.GetComponent<ObjectManager>().transfromObject(Input.touches[0].deltaPosition);
                        /*switch (transformMode)
                        {
                            case TransformMode.Tranform:
                                selectedObject.GetComponent<ObjectManager>().transfromObject(Input.touches[0].deltaPosition);
                                break;
                            case TransformMode.Scale:
                                selectedObject.GetComponent<ObjectManager>().scalingObject(Input.touches[0].deltaPosition);
                                break;
                        }*/
                    }
                }
                else if (Input.touchCount == 2)
                {
                    Vector2 touchZeroPrevPos = Input.touches[0].position - Input.touches[0].deltaPosition;
                    Vector2 touchOnePrevPos = Input.touches[1].position - Input.touches[1].deltaPosition;

                    Vector2 prevTouchDelta =touchZeroPrevPos- touchOnePrevPos;
                    Vector2 touchDelta = Input.touches[0].position - Input.touches[1].position;

                    selectedObject.GetComponent<ObjectManager>().scalingObject(prevTouchDelta - touchDelta);
                }    
            }
        }     
    }
    public void PlaceObject()
    {
        if(placeIndicator.indicator.activeSelf == true)
        {
            Quaternion rot = placeIndicator.transform.rotation;
            //rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, 0f);
            rot.eulerAngles += new Vector3(180, 0, 180);
            newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, rot);
        }
        if (newPlacedObject is null)
        {
            onClickFailed?.Invoke();
        }
        else
        {
            onClickSuccess.Invoke();
        }

    }

    //Destroy Selected Object
    public void DestroyObject()
    {
        if(selectedObject!= null)
        {
            Destroy(selectedObject);
            mode = Mode.MainMode;
        }
        else
        {
            return;
        }
        
    }

    //Selecting Placed Object
    //Enter Selecting Mode
    public void SelectObject()
    {
        RaycastHit hitObject;
        if(Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = arCamera.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out hitObject, 50f, layerMask))
            {
                text.text = hitObject.transform.gameObject.ToString();
                selectedObject = hitObject.transform.gameObject;
                selectedObject.GetComponent<ObjectManager>().Selected();
                //Make selected object, a bit transparent or more shining
                mode = Mode.SelectingMode;
                onClickSuccess?.Invoke();
            }
            else
            {
                onClickFailed?.Invoke();
            }
        }
    }
    /*public void transformObject()
    {
        transformMode = TransformMode.Tranform;
    }
    public void scaleObject()
    {
        transformMode= TransformMode.Scale;
    }*/
    public void resetObject()
    {
        selectedObject.GetComponent<ObjectManager>().ResetChange();
    }

    //Exit Selecting Mode
    public void Confirm()
    {
        
        if(selectedObject != null)
        {
            if (mode == Mode.EditingMode)
            {
                mode = Mode.SelectingMode;
            }
            else if (mode == Mode.SelectingMode)
            {
                selectedObject.GetComponent<ObjectManager>().confirmChange();
                //[reset semula, atau reset setelah edit] -> edit
                selectedObject.GetComponent<ObjectManager>().Unselect();
/*                transformMode = TransformMode.None;*/
                selectedObject = null;
                mode = Mode.MainMode;
                
            }
        }
        else
        {
            return;
        }
    }

    //Enter Editing Mode
    public void EditObject()
    {
        mode= Mode.EditingMode;
 /*       transformMode = TransformMode.None;*/
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }



}
