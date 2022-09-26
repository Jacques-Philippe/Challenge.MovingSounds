using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Car : MonoBehaviour
{
    [Range(0, 10)]
    public float Speed;

    [Range(0, 5)]
    public float TimeToDeath;

    private float timer = 0.0f;

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
        StartCoroutine("DriveAndDie");
    }

    IEnumerator DriveAndDie()
    {
        yield return new WaitUntil(() =>
        {
            if (this.timer >= this.TimeToDeath)
            {
                return true;
            }
            this.timer += Time.deltaTime;
            this.transform.position += this.transform.forward * this.Speed * Time.deltaTime;
            return false;
        });
        //GameObject.Destroy(this);
        yield return null;
    }

}
