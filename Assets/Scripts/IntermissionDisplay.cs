using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntermissionDisplay : MonoBehaviour {
    private Stats stat;
    private Text statText;
    [SerializeField]
    private AudioSource tickSource;
    [SerializeField]
    private GameObject[] buttons;
    // Use this for initialization
    void Start () {
        stat = GameObject.FindGameObjectWithTag("Stat").GetComponent<Stats>();
        statText = this.GetComponent<Text>();
        StartCoroutine(Work());
	}


    public IEnumerator Work()
    {

        statText.text = ("Day : " + stat.Day);
        yield return new WaitForSeconds(tickSource.clip.length);
        tickSource.Play();
        statText.text += ("\n" + "Executions Today : " + stat.execution);
        tickSource.Play();
        yield return new WaitForSeconds(tickSource.clip.length);
        tickSource.Play();
        statText.text += ("\n" + "Innocent People Executed : " + stat.wrongExe);
        yield return new WaitForSeconds(tickSource.clip.length);
        tickSource.Play();
        statText.text += ("\n" + "Imprisonments Today : " + stat.jail);
        yield return new WaitForSeconds(tickSource.clip.length);
        tickSource.Play();
        statText.text += ("\n" + "Innocent Imprisonments : " + stat.wrongJail);
        yield return new WaitForSeconds(tickSource.clip.length);
        tickSource.Play();
        statText.text += ("\n" + "Guilty Not Imprisoned : " + stat.failJailed);
        yield return new WaitForSeconds(tickSource.clip.length);
        tickSource.Play();
        statText.text += ("\n" + "Absolutions : " + stat.absolved);
        yield return new WaitForSeconds(tickSource.clip.length);
        tickSource.Pause();
        statText.text += ("\n" + "Guilty Not Punished : " + (stat.failedAbsolution));
        this.GetComponent<AudioSource>().Play();
        for(int x = 0; x<buttons.Length;x++)
        {
            buttons[x].gameObject.SetActive(true);
        }
    }


}
