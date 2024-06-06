using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins = 0;

    public void TakeCoin()
    {
        _coins++;
    }
}
