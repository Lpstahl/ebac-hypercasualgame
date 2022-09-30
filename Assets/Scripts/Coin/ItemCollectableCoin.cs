using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public CoinType coinType;
    
    protected override void OnCollect()
    {
        base.OnCollect();
        if (coinType == CoinType.Normal)
        {
            ItemManager.instance.AddCoins();
        }
        else if (coinType == CoinType.Red)
        {
            ItemManager.instance.AddCoinsRed();
        }
    }

    public enum CoinType
    {
        Normal,
        Red
    }
}
