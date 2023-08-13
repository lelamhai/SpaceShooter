using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPlayer : BaseImpact
{
    [SerializeField] private PlayerInventory _playerInventory;
    protected override void ReceiveReward(Collision2D collision)
    {
        base.ReceiveReward(collision);

        BaseItem item = collision.gameObject.GetComponent<BaseItem>();
        if (item == null) return;

        _playerInventory.AddItem(item);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayerInventory();
    }

    private void LoadPlayerInventory()
    {
        _playerInventory = this.transform.GetComponent<PlayerInventory>();
    }
}
