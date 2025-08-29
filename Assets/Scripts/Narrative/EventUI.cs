using UnityEngine;
using TMPro;

public class EventUI : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject eventPanelPrefab;
    public EventUI Instance { get; private set; }

   public void Awake()
   {
    if (Instance != null && Instance != this)
    {
        Destroy(this);
    }
    else
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
   }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("RefreseUI", 5f);
    }

    /// <summary>
    /// Actualiza la lista de eventos que se muestran en el UI
    /// </summary>
    public void RefreseUI()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        if (EventController.Instance.activedEvents != null)
        {
            foreach( Events events in EventController.Instance.activedEvents)
            {
                GameObject newEvent = Instantiate(eventPanelPrefab, contentPanel);
                TMP_Text text = newEvent.GetComponent<TMP_Text>();
                text.text = events.name;
            }
        }
    }
}
