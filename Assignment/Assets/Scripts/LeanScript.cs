using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeanScript : MonoBehaviour
{
    public float TweenTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tween(GameObject obj)
    {
        Vector3 Pos = obj.GetComponent<RectTransform>().position;
        LeanTween.cancel(obj);

        obj.GetComponent<RectTransform>().position = Pos;

        LeanTween.scale(obj , Vector3.one * 1.5f , TweenTime).setEasePunch();
    }

    public void moveAnim(Transform obj)
    {
        Debug.Log("MoveAnimationRun");
        Vector3 currentPos = obj.GetComponent<RectTransform>().localPosition;
        Vector3 initialPos = new Vector3(-240f,0f,0f);
        Vector3 endPos = new Vector3(240f,0f,0f);
        Debug.Log(currentPos);

        if(currentPos.x < -720f)
        {
            Debug.Log("currentPos <= initialPos");
            LeanTween.move(obj.GetComponent<RectTransform>(), endPos, 1f).setDelay(0.5f);
        }
        else
            LeanTween.move(obj.GetComponent<RectTransform>(), initialPos, 1f).setDelay(0.5f);
    }

}
