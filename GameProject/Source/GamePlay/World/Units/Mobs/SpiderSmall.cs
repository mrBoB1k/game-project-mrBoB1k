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

public class SpiderSmall : Mob
{
	public McTimer SpawnTimer;

	public SpiderSmall(Vector2 position, int ownerId) : base("Spider", position, new Vector2(25, 25), ownerId)
	{
		Speed = 2.5f;

		Health = 1;
		HealthMax = Health;
	}

	public override void Update(Vector2 offset, Player enemy)
	{
		base.Update(offset, enemy);
	}

	public override void AI(Player enemy)
	{
		Building temp = null;

		for (int i = 0; i < enemy.Buildings.Count; i++)
		{
			if (enemy.Buildings[i].GetType().ToString() == "GameProject.Tower")
			{
				temp = enemy.Buildings[i];
			}
		}

		if (temp == null)
		{
			Pos += Globals.RadialMovement(enemy.Hero.Pos, Pos, Speed);
			Rot = Globals.RotateTowards(Pos, enemy.Hero.Pos);

			if (Globals.GetDistance(Pos, enemy.Hero.Pos) < 15)
			{
				enemy.Hero.GetHit(1);
				Dead = true;
			}
		}
		else
		{
			Pos += Globals.RadialMovement(temp.Pos, Pos, Speed);
			Rot = Globals.RotateTowards(Pos, temp.Pos);

			if (Globals.GetDistance(Pos, temp.Pos) < 15)
			{
				temp.GetHit(1);
				Dead = true;
			}
		}
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}