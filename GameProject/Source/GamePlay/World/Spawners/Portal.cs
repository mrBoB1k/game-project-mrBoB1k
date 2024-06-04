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

public class Portal : Spawner
{
	public Portal(Vector2 position, int ownerId, XElement data) : base("Portal", position, new Vector2(45, 45), ownerId,
		data)
	{
		Health = 15;
		HealthMax = Health;
	}

	public override void Update(Vector2 offset)
	{
		base.Update(offset);
	}

	public override void SpawnMob()
	{
		var num = Globals.Rand.Next(0, 101);

		Mob tempMob = null;
		var total = 0;

		for (var i = 0; i < MobChoices.Count; i++)
		{
			total += MobChoices[i].Rate;
			if (num < total)
			{
				var sType = Type.GetType($"GameProject.{MobChoices[i].MobStr}", true);

				tempMob = (Mob)(Activator.CreateInstance(sType, new Vector2(Pos.X, Pos.Y), OwnerId));
				break;
			}
		}

		if (tempMob != null)
		{
			GameGlobals.PassMob(tempMob);
		}
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}