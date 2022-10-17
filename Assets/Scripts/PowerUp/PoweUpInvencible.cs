using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpInvencible : POwerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.SetPowerUptext("Invencible");
        PlayerController.instance.SetInvencible();
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.SetInvencible(false);
        PlayerController.instance.SetPowerUptext("");
    }
}
