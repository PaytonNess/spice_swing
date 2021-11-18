using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songs : MonoBehaviour
    {
        public AudioClip song1;
        public AudioClip song2;
        public AudioSource player;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Example());
        }

        IEnumerator Example()
        {
//            Debug.Log("working");
            yield return new WaitForSeconds(120);//120
            player.clip = song2;
            player.Play(0);
    //        Debug.Log("new song");
            yield return new WaitForSeconds(180);//240
            player.clip = song1;
            player.Play(0);
  //          Debug.Log("old song");
        }
        // Update is called once per frame
        void Update()
        {

        }
    }

