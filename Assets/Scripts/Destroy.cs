using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Destroyy());
    }

    IEnumerator Destroyy()
    {
        yield return new WaitForSeconds(2f);
        ObjectPooling.instance.AddToPool(gameObject);
    }
}
