using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{

    // Start is called before the first frame update

   public static ButtonScript instance;

    [SerializeField]
    private GameObject ResumeCanvas;
    [SerializeField]
    private GameObject MaingameCanvas;
    [SerializeField]
    private GameObject MenuCanvas;
    public  bool ButtonCheck = false;

   public string ComponentName;

    private GameObject target;

    private GameObject objtodelete;

    void Awake()
   {
      instance = this;
   }

    void Start()
   {
   
   }

   void Update()
   {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                Debug.Log(target.name);
                objtodelete = target;
            }
        }
   }

   // Update is called once per frame
   
   public void ButtonInfo()
   {
        if (EventSystem.current.currentSelectedGameObject.tag == "Components")
        {
            ComponentName = EventSystem.current.currentSelectedGameObject.name;
            ButtonCheck = true;
        }
        Debug.Log(ComponentName); 
        Debug.Log(ButtonCheck);
    }

    public void OnclickClear()
    {
        Debug.Log(objtodelete.name);
        string objtodelete_string = objtodelete.name.Split('(')[0];
        Destroy(objtodelete);
        GlobalScript.instance.ComponentList[objtodelete_string] -= 1;
        Debug.Log(GlobalScript.instance.ComponentList[objtodelete_string]);
        GlobalScript.instance.Component_Count_text.text = objtodelete_string + " " + GlobalScript.instance.ComponentList[objtodelete_string];
    }

    public void OnclickClearAll()
    {
        GameObject[] toClearAll = GameObject.FindGameObjectsWithTag("3DObjects");

        foreach(GameObject clear in toClearAll)
        {
            Destroy(clear);
        }
        // Destroy(GameObject.FindGameObjectWithTag("3DObjects"));
    }

    public void OnclickResume()
    {
        ResumeCanvas.SetActive(false);
    }

    public void OnclickMenu()
    {
        MenuCanvas.SetActive(true);
        
        ResumeCanvas.SetActive(false);
        MaingameCanvas.SetActive(false);
        OnclickClearAll();
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit The Game run");
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
