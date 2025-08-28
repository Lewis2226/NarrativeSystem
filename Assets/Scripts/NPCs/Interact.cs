
using UnityEngine;

public class Interact : MonoBehaviour
{
    public int NPCEvent;
    public Action.playerActions action;
    public GameObject dialgueCanvas;
    // Start is called before the first frame update
    

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
