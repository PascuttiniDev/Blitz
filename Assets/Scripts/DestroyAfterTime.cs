using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroyTime = 1f;
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

}
