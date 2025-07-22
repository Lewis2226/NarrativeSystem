using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public Stages[] GameStages;
    int currentStage = 0;
    private int maxPhase;
    private int currentPhase;

    // Start is called before the first frame update
    void Start()
    {
        SetStage(currentStage, GameStages[currentStage].phases, GameStages[currentStage].name);
        Debug.Log("La fase Maxima es: " + maxPhase);
        InvokeRepeating("NextPhase", 4f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        if (StageCheck())
        {
            Debug.Log("Se completo la etapa");
        }
        
    }

    bool StageCheck()
    {
        return GameStages[currentStage].completed;
    }

    void NextPhase()
    {
        if(currentPhase < maxPhase)
        {
            currentPhase++;
            Debug.Log("La fase actual es: " + currentPhase);
        }
        else
        {
            currentPhase = maxPhase;
            CompleteStage();
            Debug.Log("La fase actual es: " + currentPhase);
        }
        
    }

    void CompleteStage()
    {
        if (currentPhase == maxPhase)
        {
            GameStages[currentStage].completed = true;
        }

    }

    void SetStage(int Phase, int maxphase, string StageName)
    {
        currentPhase = Phase;
        maxPhase = maxphase;
        string name = StageName;
    }
}
