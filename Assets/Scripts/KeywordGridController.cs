using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeywordGridController : MonoBehaviour
{
    [SerializeField]
    GameObject keyPrefab;
    [SerializeField]
    Sprite keyGreen;
    [SerializeField]
    Sprite keyOrange;
    [SerializeField]
    Sprite keyBlack;
    [SerializeField]
    Sprite keyWhite;

    string answer = "ばいおりん";

    GameObject[] keys = new GameObject[30];
    int keyRow = 0;
    int keyColumn = 0;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            keys[i] = Instantiate(keyPrefab, transform);
            keys[i].GetComponent<Image>().sprite = keyWhite;
            keys[i].transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }

    public void OnClickKeyButton(string key)
    {
        if (keyColumn < 5)
        {
            keys[5 * keyRow + keyColumn].transform.GetChild(0).GetComponent<Text>().text = key;
            keyColumn++;
        }
    }

    public void OnClickEnter()
    {
        if(keyColumn < 5)
        {
            NotEnough();
        }
        else
        {
            string input = "";
            for(int i = 0; i < 5; i++)
            {
                input += keys[5 * keyRow + i].transform.GetChild(0).GetComponent<Text>().text;
            }
            if (input == answer)
            {
                Clear();
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    char key_ = input[i];
                    for (int j = 0; j < 5; j++)
                    {
                        if (key_ == answer[j])
                        {
                            if (i == j)
                            {
                                TurnGreen(keys[5 * keyRow + i]);
                                break;
                            }
                            else
                            {
                                TurnOrange(keys[5 * keyRow + i]);
                                break;
                            }

                        }
                        else
                        {
                            TurnBlack(keys[5 * keyRow + i]);
                        }
                    }
                }
                keyColumn = 0;
                keyRow++;
            }
        }
    }

    public void OnClickBack()
    {
        if(keyColumn > 0)
        {
            keyColumn--;
            keys[5 * keyRow + keyColumn].transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }

    void TurnOrange(GameObject key)
    {
        key.GetComponent<Image>().sprite = keyOrange;
    }
    void TurnGreen(GameObject key)
    {
        key.GetComponent<Image>().sprite = keyGreen;
    }
    void TurnBlack(GameObject key)
    {
        key.GetComponent<Image>().sprite = keyBlack;
    }



    void Clear()
    {
        Debug.Log("やったあ！");
    }

    void NotEnough()
    {
        Debug.Log("足りないぜ");
    }
}
