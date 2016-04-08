using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Character : MonoBehaviour {
    public string credText;
    public Witess[] witness = new Witess[3];
    public string evText;
    public Text eviText;
    public Evidence[] evidence = new Evidence[5];
    public string family;
    public int minValue, maxValue;
    public string classText;
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
        int rando1 = Random.Range(0, witness.Length);
        int rando2 = Random.Range(0, evidence.Length);

        Class fooClass = (Class) Random.Range(0, (int)Class.max);
        eviText.text = (

            credText + witness[rando1].witness + "\n" + evText + evidence[rando2].level + "\n" +
            classText + fooClass.ToString()
            
            
            );

    }






}
