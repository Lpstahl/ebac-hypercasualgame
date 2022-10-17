using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpSpeed : POwerUpBase
{
    [Header("Powe Up Speed")]
    public float amountToSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.PowerUpSpeedUP(amountToSpeed);
        PlayerController.instance.SetPowerUptext("Speed up");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetSpeed();
        PlayerController.instance.SetPowerUptext("");
    }
}
