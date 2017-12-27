using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariambaParent : MonoBehaviour {
    [HideInInspector]public List<GameObject> testChildren;
    MariambaChilren[] mc ;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            testChildren.Add(child.gameObject);
        }
        mc = new MariambaChilren[testChildren.Count];
        for (int i = 0; i < testChildren.Count; i++)
            {       
            mc[i] = testChildren[i].GetComponentInChildren<MariambaChilren>();
            testChildren[i].transform.localScale = new Vector3((float)(i + 1) / testChildren.Count * testChildren[i].transform.localScale.x, testChildren[i].transform.localScale.y, testChildren[i].transform.localScale.z);
            mc[i].pitch = ((float)3 * (i + 1)) / testChildren.Count;
        }
    }
	// Update is called once per frame
	void Update () {
        
    }
}
