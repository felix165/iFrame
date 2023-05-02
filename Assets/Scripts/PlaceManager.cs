using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class PlaceManager : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left,
    }
    public enum Mode
    {
        MainMode,
        SelectingMode,
        EditingMode,
    }
    //make enum for scale type (bigger/smaller)
    public static PlaceManager instance;

    private PlaceIndicator placeIndicator;
    public GameObject objectToPlace;
    public Camera arCamera;
    public LayerMask layerMask;
    static public Mode mode = Mode.MainMode;

    public TextMeshProUGUI text; //For Debug use

    private GameObject newPlacedObject;
    private GameObject selectedObject;
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
        
    }
    public void PlaceObject()
    {
        newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, Quaternion.identity);
        if(newPlacedObject is null)
        {
            onClickFailed?.Invoke(); 
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
        Ray ray = arCamera.ScreenPointToRay(placeIndicator.ray);
        if (Physics.Raycast(ray, out hitObject, 50f, layerMask))
        {
            text.text = hitObject.transform.gameObject.ToString();
            selectedObject = hitObject.transform.gameObject;
            //Make selected object, a bit transparent or more shining
            mode = Mode.SelectingMode;
            onClickSuccess?.Invoke();
        }
        else
        {
            onClickFailed?.Invoke();
        }
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
                //Make selected object back to original state
                selectedObject = null;
                mode = Mode.MainMode;
            }
        }
        else
        {
            return;
        }
    }

    //Transform Selected Object
    public void TransformObject(int direction)
    {
        if (selectedObject != null)
        {
            Vector3 pos = selectedObject.transform.position;
            
            switch ((Direction)direction)
            {
                case Direction.Up:
                    pos.y += speed;
                    break;
                case Direction.Down:
                    pos.y -= speed;
                    break;
                case Direction.Right:
                    pos.x += speed;
                    break;
                case Direction.Left:
                    pos.x -= speed;
                    break;
            }
            selectedObject.transform.position = pos;
        }
        else
        {
            return;
        }
        
    }

    //Scalling Selected Object //Scale use input?

    
    //Enter Editing Mode
    public void EditObject()
    {
        mode= Mode.EditingMode;
    }


    //unused
    //Apply selected frame or picture of Selected Object
    public void ApplyEditing()
    {
        //Change frame of selected object
        //Change picture of selected object
    }



}
