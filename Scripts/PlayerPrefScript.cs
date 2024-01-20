using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefScript : MonoBehaviour
{
    [SerializeField]
    Button[] AllButton;
    public static PlayerPrefScript pref;
    public int Value = PlayerPrefs.GetInt("Level", 0);

    private void Awake()
    {
        PlayerPrefs.SetInt("Level",0);
    }
    //private void Start()
    //{
    //     Value = PlayerPrefs.GetInt("Level", 0);
    //    for(int i = 0;i <= Value;i++)
    //    {
    //        AllButton[i].interactable = true;
    //        AllButton[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
    //    }
    //}

    public void SetAllLevel(int ClickedButton)
    {
         Value = PlayerPrefs.GetInt("Level", 0);
        if (ClickedButton == Value)
        {
            //Value++;
            PlayerPrefs.SetInt("Level", Value);
        }
   
        PlayerPrefs.SetInt("Level", Value);
        RefreshData();
    }

    public void RefreshData()
    {
        for (int i = 0; i <= Value; i++)
        {
            AllButton[i].interactable = true;
            AllButton[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }

}
