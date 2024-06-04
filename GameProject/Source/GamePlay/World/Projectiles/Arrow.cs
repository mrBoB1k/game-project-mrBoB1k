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

public class Arrow : Projectile2d
{
	public Arrow(Vector2 position, AttackableObject owner, Vector2 target) : base("Arrow", position, new Vector2(30, 30),
		owner, target)
	{
		Speed = 10.0f;
		Timer = new McTimer(800);

	}

	public override void Update(Vector2 offset, List<AttackableObject> units)
	{
		base.Update(offset, units);
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}