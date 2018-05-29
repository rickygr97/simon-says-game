using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanger : MonoBehaviour {
    // dit is een array [] is nodig om een array aan te maken.  geeft aan dat het een array is .
    public SpriteRenderer[] kleuren;

    public AudioSource[] buttonsounds;

    private int kleurenselectie;

    public float staylit;
    private float staylitcounter;


    public float waitbetweenlights;
    private float waitbetweencounter;

    private bool shoutbelit;
    private bool shoutbedark;

    public List<int> activesequence;
    private int positioninsequence;

    private bool gameactive;
    private int inputinsequence;

    public AudioSource correct;
    public AudioSource incorrect;

    public Text scoretext;

	// Use this for initialization
	void Start () {

        if (!PlayerPrefs.HasKey("hiscore"))
        {
            PlayerPrefs.SetInt("hiscore", 0);
        }

        scoretext.text = "score: 0 - high score: " + PlayerPrefs.GetInt("hiscore");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shoutbelit)
        {
            staylitcounter -= Time.deltaTime;

            if (staylitcounter < 0)
            {
                kleuren[activesequence[positioninsequence]].color = new Color(kleuren[activesequence[positioninsequence]].color.r, kleuren[activesequence[positioninsequence]].color.g, kleuren[activesequence[positioninsequence]].color.b, 0.5f);

                buttonsounds[activesequence[positioninsequence]].Stop();

                shoutbelit = false;

                shoutbedark = true;
                waitbetweencounter = waitbetweenlights;

                positioninsequence++; 
            }
        }

        if (shoutbedark)
        {
            waitbetweencounter -= Time.deltaTime;
            if (positioninsequence >= activesequence.Count)
            {
                shoutbedark = false;
                gameactive = true;
            }else
            {
                if (waitbetweencounter < 0)
                {

                    kleuren[activesequence[positioninsequence]].color = new Color(kleuren[activesequence[positioninsequence]].color.r, kleuren[activesequence[positioninsequence]].color.g, kleuren[activesequence[positioninsequence]].color.b, 1f);

                    buttonsounds[activesequence[positioninsequence]].Play();

                    staylitcounter = staylit;

                    shoutbelit = true;
                    shoutbedark = false;
                }
            }
        }
	}

    public void startgame()
    {
        activesequence.Clear();

        positioninsequence = 0;
        inputinsequence = 0;

        kleurenselectie = Random.Range(0, kleuren.Length);

        activesequence.Add(kleurenselectie);

        kleuren[activesequence[positioninsequence]].color = new Color(kleuren[activesequence[positioninsequence]].color.r, kleuren[activesequence[positioninsequence]].color.g, kleuren[activesequence[positioninsequence]].color.b, 1f);

        buttonsounds[activesequence[positioninsequence]].Play(); 

        staylitcounter = staylit;

        shoutbelit = true;   
        
        scoretext.text = "score: 0 - high score: " + PlayerPrefs.GetInt("hiscore");
             
    }

    public void colorpressed(int whichbutton)
    {
        if (gameactive)
        {




            if (activesequence[inputinsequence] == whichbutton)
            {
              
                inputinsequence++;

                if (inputinsequence >= activesequence.Count)
                {
                    if (activesequence.Count >= activesequence.Count)
                    {
                        PlayerPrefs.SetInt("hiscore", activesequence.Count);
                    }
                    scoretext.text = "score: " + activesequence.Count + " - high score: " + PlayerPrefs.GetInt("hiscore");

                    positioninsequence = 0;

                    inputinsequence = 0;

                    kleurenselectie = Random.Range(0, kleuren.Length);

                    activesequence.Add(kleurenselectie);

                    kleuren[activesequence[positioninsequence]].color = new Color(kleuren[activesequence[positioninsequence]].color.r, kleuren[activesequence[positioninsequence]].color.g, kleuren[activesequence[positioninsequence]].color.b, 1f);

                    buttonsounds[activesequence[positioninsequence]].Play();

                    staylitcounter = staylit;

                    shoutbelit = true;

                    gameactive = false;

                    correct.Play();
                  
                }


                Debug.Log("goed");
            }
            else
            {
                Debug.Log("fout");
                incorrect.Play();
                gameactive = false;

            }

        }

    }



}
