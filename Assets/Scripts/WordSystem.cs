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

	// Use this for initialization
	void Start ()
    {
        Generate();
        Sentence();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("e"))
        {
            Generate();
        }
        string inputThisFrame = Input.inputString;
        try
        {

            int inputAsInt = Convert.ToInt32(inputThisFrame);

            if (inputAsInt >= 1 && inputAsInt <= m_sentence.Length)
            {
                sentenceText.text = closer + m_sentence[inputAsInt - 1].sentence;
                for (int x = 0; x < m_sentence[inputAsInt - 1].punishment.Length; x++)
                {
                    sentenceText.text += "\n" + (x + 1) + " : " + m_sentence[inputAsInt - 1].punishment[x];
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
        for (int x = 0; x < m_sentence.Length; x++)
        {
            sentenceText.text += ("\n" + (x+1) + " : " + m_sentence[x].sentence);
        }
       
    }

    public void Generate()
    {
        int rando = UnityEngine.Random.Range(0, m_crime.Length);
        int cRando = UnityEngine.Random.Range(0, m_crime[rando].com.Length);
        int sRando = UnityEngine.Random.Range(0, m_crime[rando].subject.Length);
        crimeText.text = (opener + " " + m_crime[rando].com[cRando].committance + " " + m_crime[rando].subject[sRando]);
   }
}
