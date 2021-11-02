using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityMeter : MonoBehaviour
{

    public GameObject scriptHolder;
    public minigame mgScript;

    public SpriteRenderer qualityChanger;
    public Sprite quality0;
    public Sprite quality1;
    public Sprite quality2;
    public Sprite quality3;
    public Sprite quality4;
    public Sprite quality5;
    public Sprite quality6;
    public Sprite quality7;
    public Sprite quality8;
    public Sprite quality9;
    public Sprite quality10;
    // Start is called before the first frame update
    void Start()
    {
        scriptHolder = GameObject.Find("character");
        mgScript = scriptHolder.GetComponent<minigame>();
        qualityChanger = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        switch (mgScript.getQuality())
        {
            case 0:
                qualityChanger.sprite = quality0;
                break;
            case 1:
                qualityChanger.sprite = quality1;
                break;
            case 2:
                qualityChanger.sprite = quality2;
                break;
            case 3:
                qualityChanger.sprite = quality3;
                break;
            case 4:
                qualityChanger.sprite = quality4;
                break;
            case 5:
                qualityChanger.sprite = quality5;
                break;
            case 6:
                qualityChanger.sprite = quality6;
                break;
            case 7:
                qualityChanger.sprite = quality7;
                break;
            case 8:
                qualityChanger.sprite = quality8;
                break;
            case 9:
                qualityChanger.sprite = quality9;
                break;
            case 10:
                qualityChanger.sprite = quality10;
                break;
        }

    }
}
