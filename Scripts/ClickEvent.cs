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
            GameManager.instance.BallMoveMethod(this.gameObject);
        }
    }
}
