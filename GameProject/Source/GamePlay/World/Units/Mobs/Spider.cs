#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

#endregion

namespace GameProject;

public class Spider : Mob
{
	public McTimer SpawnTimer;

	public Spider(Vector2 position, int ownerId) : base("Spider", position, new Vector2(45, 45), ownerId)
	{
		Speed = 1.5f;

		Health = 3;
		HealthMax = Health;

		SpawnTimer = new McTimer(8000);
		SpawnTimer.AddToTimer(4000);
	}

	public override void Update(Vector2 offset, Player enemy)
	{
		SpawnTimer.UpdateTimer();
		if (SpawnTimer.Test())
		{
			SpawnEggSac();
			SpawnTimer.ResetToZero();
		}

		base.Update(offset, enemy);
	}

	public virtual void SpawnEggSac()
	{
		GameGlobals.PassSpawner(new SpiderEggSec(new Vector2(Pos.X, Pos.Y), OwnerId, null));
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}