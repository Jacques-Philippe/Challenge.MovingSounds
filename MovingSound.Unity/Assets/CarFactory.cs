using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    [SerializeField]
    private Car CarPrefab;

    
    public IEnumerator SpawnLoop()
    {
        var car = GameObject.Instantiate(this.CarPrefab, position: this.transform.position, rotation: this.transform.rotation, parent: this.transform).gameObject;

        var duration = Random.Range(2,5);
        yield return new WaitForSeconds(duration);
        GameObject.Destroy(car);
        yield return SpawnLoop();
    }

    private void Start()
    {
        StartCoroutine("SpawnLoop");
    }


}
