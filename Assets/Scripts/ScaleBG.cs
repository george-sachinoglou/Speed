using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBG : MonoBehaviour
{
    public GameObject backgroundImage;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        
        ScaleBackgroundImage();
    }

    private void ScaleBackgroundImage()
    {
        //--
        Vector2 deviceScreenResolution = new Vector2(Screen.width, Screen.height);
        print(deviceScreenResolution);

        float srcHeight = Screen.height;
        float srcWidth = Screen.width;

        float DEVICE_SCREEN_ASPECT = srcWidth / srcHeight;
        print(DEVICE_SCREEN_ASPECT.ToString());

        mainCam.aspect = DEVICE_SCREEN_ASPECT;

        float camHeight = 100.0f * mainCam.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_SCREEN_ASPECT;

        SpriteRenderer backgroundImageSR = backgroundImage.GetComponent<SpriteRenderer>();
        float bgH = backgroundImageSR.sprite.rect.height;
        float bgW = backgroundImageSR.sprite.rect.width;

        float bg_scr_h = camHeight / bgH;
        float bg_scr_w = camWidth / bgW;

        backgroundImage.transform.localScale = new Vector3(bg_scr_w, bg_scr_h, 1);


    }
}
