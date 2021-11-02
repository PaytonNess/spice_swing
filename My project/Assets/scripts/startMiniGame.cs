using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startMiniGame : MonoBehaviour
{
    public GameObject miniGameBG;
    public GameObject outOfBounds;
    public GameObject leftPressZone;
    public GameObject upPressZone;
    public GameObject downPressZone;
    public GameObject rightPressZone;
    public GameObject qualityMeter;
    private bool activateObjects = false;

    // Start is called before the first frame update
    void Start()
    {
        activateObjects = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activateObjects)
        {
            miniGameBG.SetActive(true);
            outOfBounds.SetActive(true);
            leftPressZone.SetActive(true);
            upPressZone.SetActive(true);
            downPressZone.SetActive(true);
            rightPressZone.SetActive(true);
            qualityMeter.SetActive(true);
        }
        else
        {
            miniGameBG.SetActive(false);
            outOfBounds.SetActive(false);
            leftPressZone.SetActive(false);
            upPressZone.SetActive(false);
            downPressZone.SetActive(false);
            rightPressZone.SetActive(false);
            qualityMeter.SetActive(false);
        }
    }

    //When player collides with counter, activate mini game screen
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("CookingArea"))
        {
            activateObjects = true;
        }
    }

    public void setActivateObjects(bool decision)
    {
        activateObjects = decision;
    }
}
