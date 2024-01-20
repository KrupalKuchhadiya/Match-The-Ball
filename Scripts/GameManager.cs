using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Tubes;
    [SerializeField]
    Color[] BallColors;
    [SerializeField]
    List<GameObject> SelectTubes, SelectBall;
    [SerializeField]
    GameObject PrefabBall;
    bool flag;
    GameObject FirstClicked, SecondClicked;
    [SerializeField]
    string[] BallTags;
    public static GameManager instance;
    List<Color> ListName;
    public List<GameObject> WinList;
    //public List<GameObject> WinList;
    public int Counter = 0;
    public List<GameObject> LevelList;
    public GameObject GameOverPanel,GameWinPanel;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for(int i = 0; i < LevelList.Count; i++)
        {
            if(i == Counter)
            {
                LevelList[i].SetActive(true);
            }
            else
            {
                LevelList[i].SetActive(false);
            }
        }
        
        foreach(Transform child in LevelList[Counter].transform)
        {
            Tubes.Add(child.gameObject);
            
        }

        TubesSelection();
    }
    public void TubesSelection()
    {
        int val;
        for (int i = 0; i < Tubes.Count-2; i++)
        {
            do
            {
                val = Random.Range(0, Tubes.Count);
            } while (SelectTubes.Contains(Tubes[val]));
            SelectTubes.Add(Tubes[val]);
        }
        DisplayBall();
    }
    public void DisplayBall()
    {
        for (int i = 0; i < SelectTubes.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject Temp = Instantiate(PrefabBall, SelectTubes[i].transform.GetChild(j).position, Quaternion.identity, SelectTubes[i].transform);
                SelectBall.Add(Temp);
            }
        }
        ApplyColor();
    }
    public void ApplyColor()
    {
        List<Color> shuffledColors = BallColors.OrderBy(x => Random.value).ToList();
        List<string> shuffledTag = BallTags.OrderBy(x => Random.value).ToList();
        //ListName = ListName.Add(BallColors);
        ////    do
        ////    {
        ////        for (int j = 0; j < 4; j++)
        ////        {

        ////            int RandomValue = Random.Range(0, SelectBall.Count);
        ////            SelectBall[RandomValue].GetComponent<MeshRenderer>().material.color = BallColors[val];
        ////            SelectBall.Remove(SelectBall[RandomValue]);

        ////        }
        ////    } while (UsedColor[val] == BallColors[val]);
        for (int i = 0; i < SelectTubes.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                int randomValue = Random.Range(0, SelectBall.Count);
                SelectBall[randomValue].GetComponent<MeshRenderer>().material.color = shuffledColors[i];
                SelectBall[randomValue].GetComponent<MeshRenderer>().tag = BallTags[i];
                SelectBall.RemoveAt(randomValue);
            }
        }
    }
    public void BallMoveMethod(GameObject ClickedObjct)
    {
        if (!flag)
        {
            if (ClickedObjct.transform.childCount > 5)
            {
                FirstClicked = ClickedObjct;
                FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).transform.position = FirstClicked.transform.GetChild(4).transform.position;
                flag = true;
            }
        }
        else
        {
            SecondClicked = ClickedObjct;
            if (ClickedObjct.transform.childCount >= 9)
            {
                FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).transform.position = FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 6).transform.position;
                flag = false;
                if (ClickedObjct.transform.childCount >= 9)
                {
                    if (ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(6).tag &&
                        ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(7).tag &&
                        ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(8).tag)
                    {
                        WinList.Add(ClickedObjct);
                    }
                }
            }
            else if (ClickedObjct.transform.childCount == 5)
            {
                SecondClicked = ClickedObjct;
                FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).transform.parent = SecondClicked.transform;
                SecondClicked.transform.GetChild(SecondClicked.transform.childCount - 1).transform.position = SecondClicked.transform.GetChild(0).transform.position;
                flag = false;
                if (ClickedObjct.transform.childCount >= 9)
                {
                    if (ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(6).tag &&
                        ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(7).tag &&
                        ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(8).tag)
                    {
                        WinList.Add(ClickedObjct);
                    }
                }
            }
            else
            {
                SecondClicked = ClickedObjct;
                if (SecondClicked.transform.GetChild(SecondClicked.transform.childCount - 1).tag == FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).tag)
                {
                    FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).transform.parent = SecondClicked.transform;
                    SecondClicked.transform.GetChild(SecondClicked.transform.childCount - 1).transform.position = SecondClicked.transform.GetChild(SecondClicked.transform.childCount - 6).transform.position;
                    if (ClickedObjct.transform.childCount >= 9)
                    {
                        if (ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(6).tag &&
                            ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(7).tag &&
                            ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(8).tag)
                        {
                            WinList.Add(ClickedObjct);
                        }
                    }
                    flag = false;
                }
                else
                {
                    FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).transform.position = FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 6).transform.position;
                    if (ClickedObjct.transform.childCount >= 9)
                    {
                       if(ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(6).tag  &&
                          ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(7).tag  &&
                          ClickedObjct.transform.GetChild(5).tag == ClickedObjct.transform.GetChild(8).tag)
                       {
                         WinList.Add(ClickedObjct);
                       }
                        
                    }
                    flag = false;
                }
            }
        }
        CheckMethod();
    }
    public void CheckMethod()
    {
        if (WinList.Count == SelectTubes.Count)
        {
            for(int i = 0;i < Tubes.Count;i++)
            {
              Tubes[i].GetComponent<MeshCollider>().enabled = false;
            }
            Debug.Log("Game Is Over" );
            GameWinPanel.SetActive(true);
            PlayerPrefScript.pref.Value++;
            PlayerPrefScript.pref.RefreshData();
        }
        else
        {
            Debug.Log("Game Is Not Over");
        }
    }

    public void AllLevelPanelOpen()
    {
        SceneManager.LoadScene("AllLevelScene");
    }
}
