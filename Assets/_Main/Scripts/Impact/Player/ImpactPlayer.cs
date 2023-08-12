using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPlayer : BaseImpact
{
    [SerializeField] private PlayerInventory _playerInventory;
    protected override void ReceiveReward(Collision2D collision)
    {
        base.ReceiveReward(collision);

        Debug.Log("ReceiveReward: " + collision.gameObject.name);

        InfoItem item = collision.gameObject.GetComponent<InfoItem>();
        if (item == null) return;

        _playerInventory.AddItem(item._ItemSO);
    }

    protected override void ReceiveCoin(Collision2D collision)
    {
        base.ReceiveCoin(collision);

        Debug.Log("ReceiveCoin: " + collision.gameObject.name);

        Coin coin = collision.gameObject.GetComponent<Coin>();

        if (coin == null) return;

        _playerInventory.AddCoin(coin._Price);
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
