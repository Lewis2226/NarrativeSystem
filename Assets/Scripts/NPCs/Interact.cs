
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    public int NPCEvent;
    public Action.playerActions action;
    public GameObject dialgueCanvas;
    public TextAsset dialogueNarrative;
    public TextAsset dialogueSequences;
    public TextMeshProUGUI textoNPCs;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialgueCanvas.SetActive(true);
            EventController.Instance.ShowEvent(NPCEvent, 2, 1, action);
        }
    }
}
