
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SurfaceCollision : MonoBehaviour
{
    public AudioClip hitClip;
    AudioSource drumAudio;
    public float MAXAUDIOV = 8f;
    private bool hit = false;
    private float colorVolumn;
    public int colorDelayCycle=35;

    private void Awake()
    {
        drumAudio = GetComponent<AudioSource>();
        drumAudio.clip = hitClip;

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true) {
            StopCoroutine("ColorFade");
            StartCoroutine(ColorFade(colorVolumn));
            hit = false;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        //other.gameObject.SetActive(false);
        // Debug.Log(other.gameObject);
        //up 
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f) * transform.rotation;
        Vector3 up =rotation* new Vector3(0, 1, 0);
        float angle = Vector3.Angle(up, other.relativeVelocity);
        if (transform.gameObject.name == "upSurface" && angle>90)
        {
            //sound
            drumAudio.volume = other.relativeVelocity.magnitude / MAXAUDIOV;
            Debug.Log(drumAudio.volume);
            Debug.Log(drumAudio.volume);
            drumAudio.Play();

            //vision
            Debug.Log(transform.gameObject.name + ": v:" + other.relativeVelocity+" "+angle);
            colorVolumn= (other.relativeVelocity.magnitude / MAXAUDIOV)*0.8f;
            hit = true;



        }

    }

    IEnumerator ColorFade(float colorVolumn)
    {
        
        int count = 0;
        Color startColor = new Color((1f - colorVolumn), 1f,(1f - colorVolumn), 0.5f);
        transform.gameObject.GetComponent<MeshRenderer>().material.color = startColor;
        while (startColor.r < 1f) {
            Debug.Log("runing "+startColor.r);
            count++;
            if (count > colorDelayCycle && (count%10==0)) {
                startColor.r += (1f * colorVolumn) / 15;
                startColor.b += (1f * colorVolumn) / 15;
            
                transform.gameObject.GetComponent<MeshRenderer>().material.color = startColor;
            }
            yield return 0;
        }

        //for (int i = 0; i < progress; i++) { 
        //    transform.gameObject.GetComponent<MeshRenderer>().material.color = startColor;
        //    //float tmp = (float)i / 1000 * 20;
        //    if (i < progress / 4) {; }
        //    else if (i % (progress - (progress / 4 )/ 15) == 0) {
        //        startColor.g += (1f * colorVolumn) / 15;
        //        startColor.b += (1f * colorVolumn) / 15;
        //       // Debug.Log("runing");
        //    }
            
        //    yield return 0;
        //}
        //startColor.g = 1f ;
        //startColor.b = 1f;


    }
}
