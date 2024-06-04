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

public class AIPlayer : Player
{
	public AIPlayer(int id, XElement data) : base(id,data)
	{
		// Spawners.Add(new Portal(new Vector2(50, 50), id));
		// Spawners.Add(new Portal(new Vector2(Globals.ScreenWidth / 2, 50), id));
		// Spawners[^1].SpawnTimer.AddToTimer(500);
		// Spawners.Add(new Portal(new Vector2(Globals.ScreenWidth - 50, 50), id));
		// Spawners[^1].SpawnTimer.AddToTimer(1000);
	}

	public override void Update(Player enemy, Vector2 offset)
	{
		base.Update(enemy, offset);
	}

	public override void ChangeScore(int score)
	{
		GameGlobals.Score += score;
	}
}