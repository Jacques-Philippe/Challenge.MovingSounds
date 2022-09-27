using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Car : MonoBehaviour
{
    [Range(5, 25)]
    public float Speed;

    private void OnEnable()
    {
        //ensure sound is on
        var source = this.GetComponent<AudioSource>();
        if (!source.isActiveAndEnabled)
        {
            throw new System.Exception("Audio source should be active and enabled");
        }
        if (!source.isPlaying)
        {
            throw new System.Exception("Audio source should be playing");
        }
    }

    private void Start()
    {
        //Drive
        StartCoroutine("Drive");
    }

    IEnumerator Drive()
    {
        yield return new WaitUntil(() =>
        {
            this.transform.position += this.transform.forward * this.Speed * Time.deltaTime;
            return false;
        });
    }

}
