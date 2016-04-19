using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Character : MonoBehaviour {
    public Text eviText;
    public string credText;
    public Witess[] witness = new Witess[3];
    public string evText;
    public Evidence[] evidence = new Evidence[5];
    public string family;
    public int minValue, maxValue;
    public string classText;
    public string[] mFirst;
    public string[] wFirst;
    public string[] nLast;
    private string finalName;
    public float ECoefficient;
    public float WCoefficient;
    public int infractionMin, infractoonMax;
    public enum Class
    {
        Pleb,
        Low,
        Middle,
        Upper,
        Government,
        stop,
        max=stop
    }
    public enum Gender
    {
        Male,
        Female, 
        stop,
    }


    public void Start()
    {
        Rand();

    }

    public void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            Rand();
        }
    }

    public void Rand()
    {
        int rando1 = Random.Range(0, witness.Length); //randomly selects witness type
        int rando2 = Random.Range(0, evidence.Length); // randomly selects evidence type
        int rando3 = Random.Range(minValue, maxValue); // randomly selects number of children
        int rando6 = Random.Range(infractionMin, infractoonMax); //randomized previous crimes
        Class fooClass = (Class)Random.Range(0, (int)Class.max); //randomizes social class
        Gender fooGender = (Gender)Random.Range(0, (int)Gender.stop); //randomizes gender
        //randomizes name based on gender
        if (fooGender == Gender.Male)
        {
            int rando4 = Random.Range(0, mFirst.Length);
            finalName = mFirst[rando4];
        }
        else if (fooGender == Gender.Female)
        {
            int rando4 = Random.Range(0, wFirst.Length);
            finalName = wFirst[rando4];

        }
        int rando5 = Random.Range(0, nLast.Length);

        eviText.text = 
            (
            "Name: " + finalName + nLast[rando5] + "\n" +
            "Gender: " + fooGender.ToString() + "\n" +
            classText + fooClass.ToString() + "\n" +
            credText + witness[rando1].witness + "\n" +
            evText + evidence[rando2].level + "\n" +
            "Previous Infractions: " + rando6 + "\n" +
            family + rando3          
            );
        //assigns values belonging to random witness and evidence for later use.
        ECoefficient = evidence[rando2].value;
        WCoefficient = witness[rando1].value;
    }



}
