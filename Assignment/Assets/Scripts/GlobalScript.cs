using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class GlobalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalScript instance;

    Vector3 spawnPos;

    [SerializeField]
    private TextMeshProUGUI limit_text;
    public TextMeshProUGUI Component_Count_text;
    public Dictionary<Vector3, Vector3> ComponentDictionary = new Dictionary<Vector3, Vector3>();
    public  Dictionary<string,int> ComponentList = new Dictionary<string, int>();

    public static List<Vector3> ComponentPositionList = new List<Vector3>();
    public static GameObject component = null;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        spawnPos = Camera.main.ScreenToWorldPoint(new Vector3((int)Input.mousePosition.x, (int)Input.mousePosition.y, 10.0f));

        if (ButtonScript.instance.ButtonCheck)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                GameObject target = ReturnClickedObject(out hitInfo);

                if (!ComponentDictionary.ContainsKey(spawnPos) && !IsPointerOverUIObject() && target == null)
                {
                    component = Resources.Load<GameObject>("Components/" + ButtonScript.instance.ComponentName);
                    // ComponentList.Add(component.name, 0);
                    if(ComponentList.ContainsKey(component.name))
                    {
                        if(ComponentList[component.name] < 5)
                        {
                            ComponentList[component.name] += 1;
                            Instantiate(component, spawnPos, Quaternion.identity);
                            ComponentDictionary.Add(spawnPos, component.transform.position);
                            Component_Count_text.text =  component.name + " " + ComponentList[component.name];
                        }

                    }
                    else
                    {
                        ComponentList.Add(component.name, 1);
                        Instantiate(component, spawnPos, Quaternion.identity);
                        ComponentDictionary.Add(spawnPos, component.transform.position);
                        Component_Count_text.text = component.name + " " + ComponentList[component.name];
                    }
                    ComponentPositionList.Add(spawnPos);
                }
            }

        }

        if (component != null && ComponentList.ContainsKey(component.name))
        {
            if(ComponentList[component.name] >= 5)
                limit_text.text = "limit Exceed for" + component.name;
            else
                limit_text.text = " ";
        }
    }

    public static bool IsPointerOverUIObject()
    {
        Debug.Log("IsPointerOverUIObject");
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
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
