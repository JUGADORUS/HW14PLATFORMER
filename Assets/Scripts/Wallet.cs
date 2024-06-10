using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins = 0;

    public void TakeCoin()
    {
        _coins++;
    }
}
