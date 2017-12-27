using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour {

    public List<string> names = new List<string>() {"None"};

    public GameObject[] InstrumentList;

    Dropdown dropDown;

    public void showInstrument(int index){
        if (index == 0)
        {
            foreach (GameObject k in InstrumentList)
            {
                k.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject k in InstrumentList)
            {
                k.SetActive(false);
            }
            InstrumentList[index - 1].SetActive(true);
        }
    }


    void Start () {
        dropDown = GetComponent<Dropdown>();
        PopulateList();
	}

    void PopulateList()
    {
        dropDown.AddOptions(names);
    }

}
