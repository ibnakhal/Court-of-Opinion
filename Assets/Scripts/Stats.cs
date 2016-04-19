using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
    [SerializeField]
    public int execution; //have a nice dirt nap
    [SerializeField]
    public int wrongExe; //killed the wrong fool
    [SerializeField]
    public int TotalExecutions; //careerwise total executions
    [SerializeField]
    public int jail; //jailed, bitch!
    [SerializeField]
    public int wrongJail; //jailed the wrong fool
    public int failJailed; //failed to jail the fool
    public int absolved;
    public int failedAbsolution;
    public int Day;
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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

}
