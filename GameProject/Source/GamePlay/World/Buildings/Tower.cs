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

public class Tower : Building
{
	public Tower(Vector2 position, int ownerId) : base("Tower", position, new Vector2(125, 125), ownerId)
	{
		Health = 20;
		HealthMax = Health;
		HitDist = 35;
		Speed = 0;
	}

	public virtual void Update(Vector2 offset, Player enemy)
	{
		base.Update(offset);
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}