using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isMouseDragging;
    private Vector3 screenPosition, offset;

    private GameObject target;

    public Dictionary<string , int> ComponentPowerDictionary = new Dictionary<string, int>();
    void Start()
    {
        ComponentPowerDictionary.Add("Cube", 1);
        ComponentPowerDictionary.Add("Sphere", 2);
        ComponentPowerDictionary.Add("Cylinder", 3);
        ComponentPowerDictionary.Add("Hexagon", 6);
        ComponentPowerDictionary.Add("Pentagon", 5);
        ComponentPowerDictionary.Add("Pyramid", 8);
        ComponentPowerDictionary.Add("Capsule", 4);
        ComponentPowerDictionary.Add("Octahedron", 9);
        ComponentPowerDictionary.Add("Cone", 7);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                isMouseDragging = true;
                // Debug.Log("our target position :" + target.transform.position);
                //Here we Convert world position to screen position.
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);

                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }
        }

        if (Input.GetMouseButtonUp(0))
            {
                isMouseDragging = false;
            }

            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

        if (isMouseDragging)
        {
            target.transform.position = currentPosition;  
        }

    }

    void OnCollisionEnter(Collision col )
    {
        string collisionObjName = col.gameObject.name.Split('(')[0];
        string targetObject_string = target.name.Split('(')[0];

        Debug.Log(collisionObjName);
        Debug.Log(targetObject_string);
        if(ComponentPowerDictionary[targetObject_string] > ComponentPowerDictionary[collisionObjName])
        {
            Destroy(col.gameObject);
            GlobalScript.instance.ComponentList[collisionObjName] -= 1;
        }
        else if(ComponentPowerDictionary[targetObject_string] < ComponentPowerDictionary[collisionObjName])
            {
                Destroy(target);
            GlobalScript.instance.ComponentList[targetObject_string] -= 1;
        }
    }



    GameObject ReturnClickedObject(out RaycastHit hit)
    {
            GameObject targetObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction * 20, out hit))
            {
                targetObject = hit.collider.gameObject;
            }
            // if (targetObject.tag == "Components")
            return targetObject;
            // else
            //     return null;
    }
}
