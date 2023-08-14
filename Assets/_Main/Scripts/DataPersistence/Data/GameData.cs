using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int Level;
    public Player Player;
    public List<AttributeItem> Inventories;

    public GameData()
    {
        this.Level = 0;
        this.Player = new Player(TypeBulletPlayer.RedBulletPlayer, TypePlayer.Player);
        this.Inventories = new List<AttributeItem>();
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