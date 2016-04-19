using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public enum State
{
    Type,
    Method
}

public class WordSystem : MonoBehaviour {
    [SerializeField]
    private int upperFailureThreshold;
    [SerializeField]
    private int lowerFailureThreshold;
    [SerializeField]
    private Text crimeText;
    [SerializeField]
    private Text sentenceText;
    [SerializeField]
    private string opener;
    [SerializeField]
    private string closer;
    [SerializeField]
    private Crime[] m_crime = new Crime[3];
    [SerializeField]
    private Sentence[] m_sentence = new Sentence[5];
    [SerializeField]
    private float crimeAccusationCoefficient;
    [SerializeField]
    private int upperRange;
    [SerializeField]
    private int upperMidRange;
    [SerializeField]
    private int lowerMidRange;
    [SerializeField]
    private int zero;
    [SerializeField]
    private bool firstSelection;

    public State status;

    private Stats stat;

    public Character chara;
	

    
    // Use this for initialization
	public void Start ()
    {
        chara = this.gameObject.GetComponent<Character>();
        stat = GameObject.FindGameObjectWithTag("Stat").GetComponent<Stats>();
        GameCheck();
        stat.clearDaily();
        chara.Rand();
        Generate();
        Sentence();

    }

    public void GameCheck()
    {
        int fail = (stat.totalFailedAbsolution + stat.totalFailJail);
        int wrong = (stat.totalWrongJail + stat.TotalExecutions);
        if (wrong >= upperFailureThreshold)
        {
            stat.Condition = Stats.loss.wrong;
            Application.LoadLevel(4);
        }
        if(fail >= lowerFailureThreshold)
        {
            stat.Condition = Stats.loss.fail;
            Application.LoadLevel(4);

        }

    }


    // Update is called once per frame
    public void Update() {
        //if (Input.GetKeyDown("e"))
        //{
        //    chara.Rand();
        //    Generate();
        //    Sentence();

        //}
        string inputThisFrame = Input.inputString;
        try
        {

            int inputAsInt = Convert.ToInt32(inputThisFrame);


            if (status == State.Type)
            {

                commit sentencing = m_sentence[inputAsInt - 1].sentenced;

                if (inputAsInt >= 1 && inputAsInt <= m_sentence.Length)
                {
                    if (sentencing.spectrumValue >= upperRange)
                    {
                        stat.execution++;
                        stat.executiontotal++;

                        if (crimeAccusationCoefficient < upperRange)
                        {
                            stat.wrongExe++;
                            stat.TotalExecutions++;
                        }
                    }
                    if (sentencing.spectrumValue >= upperMidRange && sentencing.spectrumValue < upperRange)
                    {
                        stat.jail++;
                        stat.jailtotal++;

                        if (crimeAccusationCoefficient < upperMidRange)
                        {
                            stat.wrongJail++;
                            stat.totalWrongJail++;
                        }
                        if(crimeAccusationCoefficient > upperMidRange)
                        {
                            stat.failJailed++;
                            stat.totalFailJail++;
                        }
                    }
                    if ( sentencing.spectrumValue <= zero)
                    {
                        stat.absolved++;
                        stat.absolutionTotal++;


                        if (crimeAccusationCoefficient > zero)
                        {
                            stat.failedAbsolution++;
                            stat.totalFailedAbsolution++;
                        }
                    }
                    status = State.Method;

                    sentenceText.text = closer + sentencing.committance;
                    for (int x = 0; x < m_sentence[inputAsInt - 1].punish.Length; x++)
                    {
                        sentenceText.text += "\n" + (x + 1) + " : " + m_sentence[inputAsInt - 1].punish[x].committance;
                    }


                }
            }
           else if (status == State.Method)
            {
                if (inputAsInt >= 1 && inputAsInt <= m_sentence.Length)
                {
                    status = State.Type;
                }
                chara.Rand();
                Generate();
                Sentence();
            }
       
        }
        catch (FormatException)
        {
            //did not hit a number key
        }
    }

    public void Sentence()
    {
        sentenceText.text = closer;


        for (int x = 0; x < 5; x++)
        {
            sentenceText.text += ("\n" + (x + 1) + " : " + m_sentence[x].sentenced.committance);
            print(m_sentence[x].sentenced.committance);
        }
        sentenceText.text += "\n" ;


    }

    public void Generate()
    {
        
        int rando = UnityEngine.Random.Range(0, m_crime.Length);
        int cRando = UnityEngine.Random.Range(0, m_crime[rando].com.Length);
        int sRando = UnityEngine.Random.Range(0, m_crime[rando].subjecte.Length);
        crimeText.text = (opener + " " + m_crime[rando].com[cRando].committance + " " + m_crime[rando].subjecte[sRando].committance);

        float temp = m_crime[rando].com[cRando].spectrumValue + m_crime[rando].subjecte[sRando].spectrumValue;
        crimeAccusationCoefficient = (temp * chara.WCoefficient) + (temp * chara.ECoefficient);
    }
}
