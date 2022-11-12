using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class NewBehaviourScript : MonoBehaviour
{
    public CardDisplayer cardDisplayer;
    string filePath = "Unit 2 Test Review";
    void Awake()
    {
        //string readFromFilelPath = Application.streamingAssestsPath
        List<string> terms = new List<string>(File.ReadAllLines("Assets/customfiles/" + filePath + "/" + filePath + " Terms.txt"));
        List<string> Short = new List<string>(File.ReadAllLines("Assets/customfiles/" + filePath + "/" + filePath + " Short.txt"));
        List<string> notes = new List<string>();
        List<string> notesTemp = new List<string>(File.ReadAllLines("Assets/customfiles/" + filePath + "/" + filePath + " Notes.txt"));

        string notesRun = "";
        for (int i = 0; i < notesTemp.Count; i++)
        {
            if (notesTemp[i] == "")
            {
                notes.Add(notesRun);
                notesRun = "";
            }
            else
                notesRun += notesTemp[i];
        }

        //Removing All the Blanks
        
        for (int i = 0; i < terms.Count; i++)
        {
            if(terms[i] == "")
                terms.RemoveAt(i);
        }

        for (int i = 0; i < Short.Count; i++)
        {
            if (Short[i] == "")
                Short.RemoveAt(i);
        }

        for (int i = 0; i < notes.Count; i++)
        {
            if (notes[i] == "")
                notes.RemoveAt(i);
        }
        
        Debug.Log(terms.Count);
        Debug.Log(Short.Count);
        Debug.Log(notes.Count);

        cardDisplayer.playTerms = terms;
        cardDisplayer.playShort = Short;
    }

    // Update is called once per frame
    void Update()
    {
            
    }

}
