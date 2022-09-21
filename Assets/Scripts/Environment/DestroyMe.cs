using System.Collections;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyNow());
    }

    IEnumerator DestroyNow()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
