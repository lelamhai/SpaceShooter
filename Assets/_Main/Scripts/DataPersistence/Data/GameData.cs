using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int Level;
    public Player Player;
    public List<AttributeSlot> Inventory;

    public GameData()
    {
        this.Level = 0;
        this.Player = new Player(TypeBulletPlayer.RedBulletPlayer, TypePlayer.Player);
        this.Inventory = new List<AttributeSlot>();
    }
}

[Serializable]
public struct Player
{
    public TypeBulletPlayer Bullet;
    public TypePlayer Plane;

    public Player(TypeBulletPlayer bullet, TypePlayer plane)
    {
        this.Bullet = bullet;
        this.Plane = plane;
    }
}