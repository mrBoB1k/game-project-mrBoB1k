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

public class Mob : Unit
{
	public Mob(string path, Vector2 position, Vector2 dims, int ownerId) : base(path, position, dims, ownerId)
	{
		Speed = 2.0f;
	}

	public override void Update(Vector2 offset, Player enemy)
	{
		AI(enemy);

		base.Update(offset);
	}

	public virtual void AI(Player enemy)
	{
		Pos += Globals.RadialMovement(enemy.Hero.Pos, Pos, Speed);
		Rot = Globals.RotateTowards(Pos, enemy.Hero.Pos);

		if (Globals.GetDistance(Pos, enemy.Hero.Pos) < 15)
		{
			enemy.Hero.GetHit(1);
			Dead = true;
		}
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}