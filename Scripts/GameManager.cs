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
    GameObject GlobClickedObject;
    public List<GameObject> GlobTubeArray;
    public int Counter = 0;
    public List<GameObject> LevelList;

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
        ////for (int i = 0; i < SelectBall.Count; i++)
        ////{
        ////    int val = Random.Range(0, BallColors.Length);
        ////    UsedColor.Add(BallColors[val]);
        ////    do
        ////    {
        ////        for (int j = 0; j < 4; j++)
        ////        {

        ////            int RandomValue = Random.Range(0, SelectBall.Count);
        ////            SelectBall[RandomValue].GetComponent<MeshRenderer>().material.color = BallColors[val];
        ////            SelectBall.Remove(SelectBall[RandomValue]);

        ////        }
        ////    } while (UsedColor[val] == BallColors[val]);
        ////}


        for (int i = 0; i < SelectBall.Count; i++)
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
        GlobClickedObject = ClickedObjct;


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
            if (ClickedObjct.transform.childCount >= 9)
            {

                FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).transform.position = FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 6).transform.position;
                flag = false;
                if (ClickedObjct.transform.childCount >= 9)
                {
                    GlobTubeArray.Add(ClickedObjct);
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
                    GlobTubeArray.Add(ClickedObjct);
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
                        GlobTubeArray.Add(ClickedObjct);
                    }
                    flag = false;
                }
                else
                {
                    FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 1).transform.position = FirstClicked.transform.GetChild(FirstClicked.transform.childCount - 6).transform.position;
                    if (ClickedObjct.transform.childCount >= 9)
                    {
                        GlobTubeArray.Add(ClickedObjct);
                    }
                    flag = false;
                }

            }
        }
        CheckMethod();
    }
    public void CheckMethod()
    {
        for (int i = 0; i < Tubes.Count; i++)
        {


            if (GlobTubeArray[i].transform.childCount == 9)
            {
                if (GlobTubeArray[i].transform.GetChild(5).transform.tag == GlobTubeArray[i].transform.GetChild(6).transform.tag)
                {
                    if (GlobTubeArray[i].transform.GetChild(5).transform.tag == GlobTubeArray[i].transform.GetChild(7).transform.tag)
                    {
                        if (GlobTubeArray[i].transform.GetChild(5).transform.tag == GlobTubeArray[i].transform.GetChild(8).transform.tag)
                        {
                           
                           
                            WinList.Add(GlobTubeArray[i]);
                            GlobTubeArray.Remove(GlobTubeArray[i]);
                            quicktest();
                        }
                    }
                }
            }
            else
            {
                GlobTubeArray.Remove(GlobTubeArray[i]);
                Debug.Log("Game Is Running");
            }
        }

      

    }

    void quicktest()
    {
        if (WinList.Count == SelectTubes.Count)
        {
            Counter++;
            if(Counter >= 2)
            {
                Debug.Log("Counter ++");
                //SceneManager.LoadScene(0);
                LevelList[0].SetActive(false);
                LevelList[1].SetActive(true);
            }
            else if(Counter == 3)
            {
                Debug.Log("Counter ---");
                SceneManager.LoadScene("3To5Level");
            }
            Debug.Log("Game Is Over");
        }
        else
        {
            Debug.Log("Game Is Not Over");
        }
    }
}
