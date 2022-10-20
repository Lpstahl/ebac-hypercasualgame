using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public Collider collider;
    public bool collect = false;
    public float lerp = 5f;
    public float miniDistance = 1f;

    protected override void Collect()
    {
        base.Collect();
        collider.enabled = false;
        collect = true;
    }
    protected override void OnCollect()
    {
        OnCollect();
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < miniDistance)
            {
                HideItens();
                Destroy(gameObject);
            }
        }
    }
}
