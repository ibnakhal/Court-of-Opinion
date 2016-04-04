using UnityEngine;
using System.Collections;

public class SkinRandomizer : MonoBehaviour {
    [SerializeField]
    private Material[] skin;
	// Use this for initialization
	void Start () {
        int rando = Random.Range(0, skin.Length);
        this.GetComponent<Renderer>().material = skin[rando];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
