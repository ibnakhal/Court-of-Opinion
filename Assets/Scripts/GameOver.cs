using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    [SerializeField]
    private Text gText;
    private Stats stat;
    [SerializeField]
    private string fail;
    [SerializeField]
    private string wrong;
    // Use this for initialization
    void Start () {

        stat = GameObject.FindGameObjectWithTag("Stat").GetComponent<Stats>();
        stat.GameOver();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (stat.Condition == Stats.loss.fail)
        {
            gText.text = ("On the night of day " + stat.Day + ", " + fail);
        }
        if(stat.Condition == Stats.loss.wrong)
        {
            gText.text = ("On the night of day " + stat.Day + ", " + wrong);
        }
    }
}
