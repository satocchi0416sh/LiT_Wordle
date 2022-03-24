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
    
}
