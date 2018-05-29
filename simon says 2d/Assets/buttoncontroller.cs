using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttoncontroller : MonoBehaviour {

    private SpriteRenderer sprite;
    public int thisbuttonnemmer;
    private gamemanger thegm;

    private AudioSource thesound;

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        thegm = FindObjectOfType<gamemanger>();
        thesound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        thesound.Play();
    }

    void OnMouseUp()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
        thegm.colorpressed(thisbuttonnemmer);
        thesound.Stop();
    }
}
