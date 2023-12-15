using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickEvent : MonoBehaviour
{
    public static ClickEvent instance;
    GameObject FifthObject;
    int ch;
    private void OnMouseUp()
    {
       
        if(this.gameObject.transform.childCount >= 5)
        {
            ch = this.gameObject.transform.childCount - 1;
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.1179951f, 0.1179951f), 0.5f);
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.95f, 0.1179951f), 0.5f);
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.85f, 0.1179951f), 0.5f);
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.75f, 0.1179951f), 0.5f);
            //this.gameObject.transform.GetChild(ch).DOMove(this.gameObject.transform.GetChild(4).position, 0.6F);
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.75f, 0.1179951f), 0.5f);
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.85f, 0.1179951f), 0.5f);
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.95f, 0.1179951f), 0.5f);
            //this.gameObject.transform.GetChild(ch).DOScale(new Vector3(0.1179951f, 0.1179951f, 0.1179951f), 0.5f);
            GameManager.instance.BallMoveMethod(this.gameObject);
        }
    }
}
