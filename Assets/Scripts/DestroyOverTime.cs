using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    private void OnBecameVisible()
    {
        Destroy(this.gameObject, 0.3f);
    }
}
