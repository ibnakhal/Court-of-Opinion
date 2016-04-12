using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
public class WordSystem : MonoBehaviour {
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
    private Sentence[] m_sentence = new Sentence[4];
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



    private Stats stat;

    public Character chara;
	// Use this for initialization
	public void Start ()
    {
        Generate();
        Sentence();
        chara = this.gameObject.GetComponent<Character>();
        stat = GameObject.FindGameObjectWithTag("Stat").GetComponent<Stats>();
    }

    // Update is called once per frame
    public void Update() {
        if (Input.GetKeyDown("e"))
        {
            Generate();
            Sentence();
        }
        string inputThisFrame = Input.inputString;
        try
        {

            int inputAsInt = Convert.ToInt32(inputThisFrame);

            if (firstSelection)
            {
                if (inputAsInt >= 1 && inputAsInt <= m_sentence.Length)
                {
                    if (m_sentence[inputAsInt - 1].sentenced.spectrumValue >= upperRange)
                    {
                        stat.execution++;
                        if(crimeAccusationCoefficient < 40)
                        {
                            stat.wrongExe++;
                        }
                    }
                    firstSelection = false;
                    Generate();
                    Sentence();
                }
            }
           else if (!firstSelection)
            {
                if (inputAsInt >= 1 && inputAsInt <= m_sentence.Length)
                {
                    sentenceText.text = closer + m_sentence[inputAsInt - 1].sentence;
                    for (int x = 0; x < m_sentence[inputAsInt - 1].punish.Length; x++)
                    {
                        sentenceText.text += "\n" + (x + 1) + " : " + m_sentence[inputAsInt - 1].punish[x].committance;
                    }




                    firstSelection = true;
                }
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
        if (!firstSelection)
        {
            for (int x = 0; x < m_sentence.Length; x++)
            {
                sentenceText.text += ("\n" + (x + 1) + " : " + m_sentence[x].sentenced.committance);
            }

        }
       
    }

    public void Generate()
    {
        int rando = UnityEngine.Random.Range(0, m_crime.Length);
        int cRando = UnityEngine.Random.Range(0, m_crime[rando].com.Length);
        int sRando = UnityEngine.Random.Range(0, m_crime[rando].subjecte.Length);
        crimeText.text = (opener + " " + m_crime[rando].com[cRando].committance + " " + m_crime[rando].subjecte[sRando].committance);

        float temp = m_crime[rando].com[cRando].spectrumValue + m_crime[rando].subjecte[sRando].spectrumValue;
        crimeAccusationCoefficient = (temp * chara.WCoefficient) + (temp * chara.ECoefficient);
        print(crimeAccusationCoefficient + " = " + temp + "*" + chara.WCoefficient + " + " + temp + "*" + chara.ECoefficient);

        print(m_crime[rando].com[cRando].spectrumValue);
        print(m_crime[rando].subjecte[sRando].spectrumValue);
        print(temp);
        print(chara.ECoefficient);
        print(temp * chara.WCoefficient);
        print(chara.WCoefficient);
        print(temp * chara.ECoefficient);
    }
}
