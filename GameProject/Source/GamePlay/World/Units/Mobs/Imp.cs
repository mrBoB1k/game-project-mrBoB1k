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

public class Imp : Mob
{
	public Imp(Vector2 position, int ownerId) : base("Imp", position, new Vector2(40, 40), ownerId)
	{
		Speed = 2.0f;
	}

	public override void Update(Vector2 offset, Player enemy)
	{
		base.Update(offset, enemy);
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}