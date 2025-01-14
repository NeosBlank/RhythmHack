using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    public KeyCode secondKeyToPress;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(secondKeyToPress)) {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress) || Input.GetKeyUp(secondKeyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}
