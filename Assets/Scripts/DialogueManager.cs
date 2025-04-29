using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DialogueManager : MonoBehaviour
{
    public TextAsset Dialogues;
    public List<HistoryDialogue> dialoguesHistory;

    [System.Serializable]
    public class HistoryDialogue
    {
        public int id;
        public string goodDialogue;
        public string badDialogue;
    }



    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void ReadCSV()
    {
        string[] lines = Dialogues.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if(string.IsNullOrEmpty(line)) continue;
            string[] data = line.Split(',');

            HistoryDialogue dialogue = new HistoryDialogue();
            dialogue.id = int.Parse(data[0]);
            dialogue.goodDialogue = data[1];
            dialogue.badDialogue = data[2];

            dialoguesHistory.Add(dialogue);
        }

        Debug.Log("Se encontraron : " +  dialoguesHistory.Count + " lineas de dialogo");
    }

    public string GetDialogue(int id, States.playerStates types)
    {
        HistoryDialogue dialogue = dialoguesHistory.Find(d => d.id == id);

        if(dialogue == null)
        {
            Debug.Log("No se encontro se diálogo con el " + id);
            return "";
        }

        switch (types)
        {
            case States.playerStates.Good:
                return dialogue.goodDialogue;

            case States.playerStates.Bad:
                return dialogue.badDialogue;

            default:
                Debug.Log("Tipo inválido, no se reconoce");
                return "";
        }
    }

    public string ShowDialogue(int dialogueId, States.playerStates dialogueType)
    {
        string dialogueToShow = GetDialogue(dialogueId, dialogueType);
        Debug.Log("Diálogo: " + dialogueToShow);
        return dialogueToShow;
    }

}
