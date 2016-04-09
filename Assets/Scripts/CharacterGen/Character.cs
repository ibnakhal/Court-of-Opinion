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
    public int coefficient;
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
        int rando1 = Random.Range(0, witness.Length);
        int rando2 = Random.Range(0, evidence.Length);
        int rando3 = Random.Range(minValue, maxValue);
        Class fooClass = (Class)Random.Range(0, (int)Class.max);
        Gender fooGender = (Gender)Random.Range(0, (int)Gender.stop);
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

        eviText.text = (
            "Name: " + finalName + nLast[rando5] + "\n" +
            "Gender: " + fooGender.ToString() + "\n" +
            classText + fooClass.ToString() + "\n" +
            credText + witness[rando1].witness + "\n" +
            evText + evidence[rando2].level + "\n" +
            "Children: " + rando3 + "\n"



            );
        coefficient = witness[rando1].value + evidence[rando2].value;
    }



}
