using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using UnityEngine.UI;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer speech;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    Animator animator;
    private bool move = false;
    private AudioSource barking;
    public Text textVoice;


    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        actions.Add("Stop", Stop);
        actions.Add("Bounce", Bounce);
        actions.Add("Roll", Roll);
        actions.Add("Jump", Jump);
        actions.Add("Spin", Spin);
        actions.Add("Left", Left);
        actions.Add("Right", Right);
        actions.Add("Backward", Up);
        actions.Add("Forward", Down);
        actions.Add("Bark", Bark);
        actions.Add("Walk", Walk);
        speech = new KeywordRecognizer(actions.Keys.ToArray());
        speech.OnPhraseRecognized += Recognized;
        speech.Start();
        barking = gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if(move == true)
        {
            transform.position += transform.forward * 1 * Time.deltaTime;
        }

        if(transform.position.y < -5)
        {
            transform.position = new Vector3(0, 5, 0);
        }

    }

    private void Recognized(PhraseRecognizedEventArgs talk)
    {
        Debug.Log(talk.text);
        textVoice.text = (talk.text).ToString();
        actions[talk.text].Invoke();
    }


    private void Stop()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 210, 0);
        animator.SetInteger("movement", 0);
        move = false;
    }
    private void Bounce()
    {
        animator.SetInteger("movement", 1);
    }
    private void Roll()
    {
        animator.SetInteger("movement", 2);
    }
    private void Jump()
    {
        animator.SetInteger("movement", 3);
    }
    private void Spin()
    {
        animator.SetInteger("movement", 5);
    }
    private void Left()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        if(animator.GetInteger("movement") == 0)
        {
            animator.SetInteger("movement", 6);
        }
        move = true;
    }

    private void Right()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (animator.GetInteger("movement") == 0)
        {
            animator.SetInteger("movement", 6);
        }
        move = true;
    }

    private void Up()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (animator.GetInteger("movement") == 0)
        {
            animator.SetInteger("movement", 6);
        }
        move = true;
    }

    private void Down()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (animator.GetInteger("movement") == 0)
        {
            animator.SetInteger("movement", 6);
        }
        move = true;
    }

    private void Walk()
    {
        if (move == false)
        {
            animator.SetInteger("movement", 6);
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            move = true;
        }

        else
        {

            animator.SetInteger("movement", 6);
        }
    }

    private void Bark()
    {
        barking.Play();
    }
}
