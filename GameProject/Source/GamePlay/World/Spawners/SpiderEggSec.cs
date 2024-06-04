#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

#endregion

namespace GameProject;

public class SpiderEggSec : Spawner
{
	public int MaxSpawns, TotalSpawns;

	public SpiderEggSec(Vector2 position, int ownerId, XElement data) : base("SpiderEgg", position, new Vector2(45, 45),
		ownerId, data)
	{
		TotalSpawns = 0;
		MaxSpawns = 3;
		Health = 3;
		HealthMax = Health;
		SpawnTimer = new McTimer(3000);
	}

	public override void Update(Vector2 offset)
	{
		base.Update(offset);
	}

	public override void SpawnMob()
	{
		Mob tempMob = new SpiderSmall(new Vector2(Pos.X, Pos.Y), OwnerId);

		if (tempMob != null)
		{
			GameGlobals.PassMob(tempMob);
			TotalSpawns++;
			if (TotalSpawns == MaxSpawns)
			{
				Dead = true;
			}
		}
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}