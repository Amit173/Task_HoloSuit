using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectTranformation : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 20, out hit))
        {
            // targetObject = hit.collider.gameObject;
            float ScaleValue = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 20;
            hit.transform.localScale += Vector3.one * ScaleValue;
            // targetObject.transform.localScale.y = targetObject.transform.localScale.z = transform.localScale.x;
            // hit.transform.localScale += Vector3.one * ScaleValue;
        }
   
        // if (Physics.Raycast(ray, hitInfo, 200))
        // {
        //     hitInfo.transform.localScale.x += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 20;
        //     transform.localScale.y = transform.localScale.z = transform.localScale.x;
        // }    

    }

}
