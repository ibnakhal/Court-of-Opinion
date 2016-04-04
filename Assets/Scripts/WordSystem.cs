using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class WordSystem : MonoBehaviour {
    [SerializeField]
    private Text crimeText;
    [SerializeField]
    private Text sentenceText;
    [SerializeField]
    private string opener;
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
	void Update () {
	if(Input.GetKeyDown("e"))
        {
            Generate();
        }
	}

    public void Sentence()
    {
        sentenceText.text = ("You are sentenced to " + "\n" + "1 : " + m_sentence[0].sentence + "\n" + "2 : " + m_sentence[1].sentence + "\n" + "3 : " + m_sentence[2].sentence + "\n" + "4 : " + m_sentence[3].sentence);
    }

    public void Generate()
    {
        int rando = Random.Range(0, m_crime.Length);
        int cRando = Random.Range(0, m_crime[rando].committance.Length);
        int sRando = Random.Range(0, m_crime[rando].subject.Length);
        crimeText.text = ("" + opener + " " + m_crime[rando].committance[cRando] + " " + m_crime[rando].subject[sRando]);
   }
}
