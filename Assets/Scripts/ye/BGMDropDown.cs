using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMDropDown : MonoBehaviour {

    public List<string> names = new List<string>() { "None" };

    public AudioClip[] ClipList;

    public AudioSource BgmSource;

    Dropdown dropDown;

    public void changBgm(int index)
    {
        BgmSource.clip = ClipList[index];
        BgmSource.Play(0);
    }

    void Start()
    {
        dropDown = GetComponent<Dropdown>();
        PopulateList();
    }

    void PopulateList()
    {
        dropDown.AddOptions(names);
    }
}
