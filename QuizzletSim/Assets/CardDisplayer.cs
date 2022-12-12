using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplayer : MonoBehaviour
{
    public List<string> playTerms = new List<string>();
    public List<string> playShort = new List<string>();

    public GameObject TermText;
    public GameObject ShortText;
    public GameObject questionsLeft;

    void Start()
    {
        for (int i = 0; i < playTerms.Count; i++)
        {
            string temp = playTerms[i];
            string temp2 = playShort[i];
            int randomIndex = Random.Range(i, playTerms.Count);
            playTerms[i] = playTerms[randomIndex];
            playShort[i] = playShort[randomIndex];
            playTerms[randomIndex] = temp;
            playShort[randomIndex] = temp2;
        }
        //initial term without deletion
        TermText.GetComponent<TMP_Text>().text = playTerms[0];
        ShortText.GetComponent<TMP_Text>().text = playShort[0];

        TermText.SetActive(true);
        ShortText.SetActive(false);
    }

    void Update()
    {
        questionsLeft.GetComponent<TMP_Text>().text = "Questions Left: " + playTerms.Count;
        if (Input.GetKeyDown("space"))
            FlipCard();
        if (Input.GetKeyDown(KeyCode.Return))
            NewCard();
    }
    void NewCard()
    {
        if(playTerms.Count != 0 && playShort.Count !=0)
        {
            playTerms.RemoveAt(0);
            playShort.RemoveAt(0);

            TermText.GetComponent<TMP_Text>().text = playTerms[0];
            ShortText.GetComponent<TMP_Text>().text = playShort[0];

            TermText.SetActive(true);
            ShortText.SetActive(false);
        }
    }
    void FlipCard()
    {
        TermText.SetActive(!TermText.active);
        ShortText.SetActive(!ShortText.active);
    }
}
