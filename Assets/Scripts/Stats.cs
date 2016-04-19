using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
    public enum loss
    {
        clear,
        wrong,
        fail,
        stop,
    }
    public loss Condition;
    [SerializeField]
    public int execution;               //have a nice dirt nap
    public int wrongExe;                //killed the wrong fool
    public int TotalExecutions;         //careerwise total executions
    public int executiontotal;
    public int jail;                    //jailed, bitch!
    public int wrongJail;               //jailed the wrong fool
    public int failJailed;              //failed to jail the fool
    public int totalFailJail;           //total fail jailed
    public int totalWrongJail;          //total wrong jailed
    public int jailtotal;
    public int absolved;                //let him go this accusation is stupid!
    public int failedAbsolution;        //you let the wrong guy go
    public int totalFailedAbsolution;   //total Criminals not punished
    public int absolutionTotal;
    public int Day;
    public float favor;
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        float top = (TotalExecutions + totalFailedAbsolution + totalFailJail + totalWrongJail);
        float bot = (executiontotal + jailtotal + absolutionTotal);
        favor = ((( top/bot )*100)-100)*(-1) ;

    }

    public void clearDaily()
    {
        execution = 0;
        wrongExe = 0;
        jail = 0;
        wrongJail = 0;
        failJailed = 0;
        absolved = 0;
        failedAbsolution = 0;
        Day++;
    }
    public void GameOver()
    {
        execution = 0;
        wrongExe = 0;
        jail = 0;
        wrongJail = 0;
        failJailed = 0;
        absolved = 0;
        failedAbsolution = 0;
        Day = 0;
        totalFailJail = 0;
        totalWrongJail = 0;
        totalFailedAbsolution = 0;
        TotalExecutions = 0;
    }


}
