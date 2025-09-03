using UnityEngine;
using TMPro;

public class EventUI : MonoBehaviour
{
    [Tooltip("Es necesario tener un canvas, donde se tenga un gameObject como contenedor.")]
    public Transform contentPanel;
    [Tooltip("Es necesario que este tengo un Text Mesh Pro como componete hijo.")]
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

    /// <summary>
    /// Actualiza la lista de eventos que se muestran en el UI
    /// </summary>
    public void RefreshUI()
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
                TextMeshProUGUI text = newEvent.GetComponentInChildren<TextMeshProUGUI>();
                if(text != null)
                {
                    text.text = events.eventName;
                }
                else
                {
                    Debug.Log("No se encontro el Text Mesh Pro");
                }
            }
        }
    }
}
