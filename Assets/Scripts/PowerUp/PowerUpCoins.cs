using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : POwerUpBase
{
    [Header("coin Collector")]
    public float sizeAmount = 7;

  protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.ChangeCoinCollectableSize(sizeAmount);
        PlayerController.instance.SetPowerUptext("Gotta Catch ’Em All");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.SetPowerUptext("");
    }
}
