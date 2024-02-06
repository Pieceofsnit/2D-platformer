using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СollectingСoins : MonoBehaviour
{
    private int _coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<AppleCoin>(out AppleCoin appleCoin))
        {
            _coin++;
        }
    }
}
