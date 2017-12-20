using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariambaParent : MonoBehaviour {

    public GameObject[] mariabaChildren;

    MariambaChilren[] mc ;

	// Use this for initialization
	void Start () {
        mc = new MariambaChilren[mariabaChildren.Length];
        for (int i = 0; i < mariabaChildren.Length; i++)
        {
            //mc.SetValue(mariabaChildren[i].GetComponent<MariambaChilren>(), i);
            mc[i] = mariabaChildren[i].GetComponentInChildren<MariambaChilren>();
            Debug.Log(mariabaChildren[i].transform.localScale);
            mariabaChildren[i].transform.localScale = new Vector3( (float) (i+1) / mariabaChildren.Length * mariabaChildren[i].transform.localScale.x, mariabaChildren[i].transform.localScale.y, mariabaChildren[i].transform.localScale.z);
            Debug.Log(mariabaChildren[i].transform.localScale);
            mc[i].pitch = ((float)3 * (i+1)) / mariabaChildren.Length;
        }
    }
	// Update is called once per frame
	void Update () {
        
    }
}
