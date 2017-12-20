
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class SurfaceCollision : MonoBehaviour
{
    //public AudioClip hitClip;
    //AudioSource drumAudio;
    SoundPlayer sp;
    public float VelocityUpLimit = 8f;
    public int colorDelayCycle=35;
    public Color DrumColor;
    //public string name;
    public Transform Recorder;

    private float colorVolumn;
    private float ColorChangeRate = 1/15;

    //IEnumerator coroutine;

    private void Awake()
    {
        sp = this.GetComponent<SoundPlayer>();
       // drumAudio = GetComponent<AudioSource>();
       // drumAudio.clip = hitClip;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        //other.gameObject.SetActive(false);
         //Debug.Log(other.gameObject);
        //up 
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f) * transform.rotation;
        Vector3 up =rotation* new Vector3(0, 1, 0);
        float angle = Vector3.Angle(up, other.GetComponent<FakeVelocity>().velocity);
       // Debug.Log(other.gameObject+" "+angle);
        if (angle >= 90f)
        {

            //sound
            float volume = other.GetComponent<FakeVelocity>().velocity.magnitude / VelocityUpLimit * 0.5f;
            sp.play( volume);
            Recorder.GetComponent<Recorder>().doRecord(sp, volume);
            //drumAudio.Play();

            //vision
           // Debug.Log(transform.gameObject.name + ": v:" + other.GetComponent<FakeVelocity>().velocity + " " + angle);
            colorVolumn = (other.GetComponent<FakeVelocity>().velocity.magnitude / VelocityUpLimit) * 0.8f;

            StopAllCoroutines();
            StartCoroutine(ColorFade(colorVolumn));
        }

    }

    

    IEnumerator ColorFade(float colorVolumn)
    {
        
        int count = 0;
        
        float deltaR = 1f - DrumColor.r;
        float deltaG = 1f - DrumColor.g;
        float deltaB = 1f - DrumColor.b;
        Color tmpColor = new Color((1f - colorVolumn*deltaR), (1f - colorVolumn * deltaG), (1f - colorVolumn * deltaB), 0.5f);

        transform.gameObject.GetComponent<MeshRenderer>().material.color = tmpColor;
        while (tmpColor.r < 1f|| tmpColor.g < 1f|| tmpColor.b < 1f) {
            //Debug.Log("runing "+ tmpColor.r);
            count++;
            if (count > colorDelayCycle && (count%10==0)) {
                tmpColor.r = ((tmpColor.r + deltaR / 15) >= 1) ? 1 : tmpColor.r + deltaR / 15;
                tmpColor.g = ((tmpColor.g + deltaG / 15) >= 1) ? 1 : tmpColor.g + deltaG / 15;
                tmpColor.b = ((tmpColor.b + deltaB / 15) >= 1) ? 1 : tmpColor.b + deltaB / 15;
                transform.gameObject.GetComponent<MeshRenderer>().material.color = tmpColor;
            }
            yield return 0;
        }
    }
}
