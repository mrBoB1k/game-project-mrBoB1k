#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

#endregion

namespace GameProject;

public class Spawner : AttackableObject
{
	public List<MobChoice> MobChoices = new List<MobChoice>();

	public McTimer SpawnTimer = new McTimer(2400);

	public Spawner(string path, Vector2 position, Vector2 dims, int ownerId, XElement data) : base(path, position, dims,
		ownerId)
	{
		Dead = false;
		Health = 3;
		HealthMax = Health;

		LoadData(data);

		HitDist = 35.0f;
	}

	public override void Update(Vector2 offset)
	{
		SpawnTimer.UpdateTimer();
		if (SpawnTimer.Test())
		{
			SpawnMob();
			SpawnTimer.ResetToZero();
		}

		base.Update(offset);
	}

	public virtual void LoadData(XElement data)
	{
		if (data != null)
		{
			SpawnTimer.AddToTimer(Convert.ToInt32(data.Element("timerAdd").Value, Globals.Culture));

			var mobList = data.XPathSelectElements("mob").ToList<XElement>();

			for (var i = 0; i < mobList.Count; i++)
			{
				MobChoices.Add(new MobChoice(mobList[i].Value,
					Convert.ToInt32(mobList[i].Attribute("rate").Value, Globals.Culture)));
			}
		}
	}

	public virtual void SpawnMob()
	{
		GameGlobals.PassMob(new Imp(new Vector2(Pos.X, Pos.Y), OwnerId));
	}

	public override void Draw(Vector2 offset)
	{
		Globals.NormalFlatEffect.Parameters["xSize"].SetValue((float)Model.Bounds.Width);
		Globals.NormalFlatEffect.Parameters["ySize"].SetValue((float)Model.Bounds.Height);
		Globals.NormalFlatEffect.Parameters["xDraw"].SetValue((float)((int)Dims.X));
		Globals.NormalFlatEffect.Parameters["yDraw"].SetValue((float)((int)Dims.Y));
		Globals.NormalFlatEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
		Globals.NormalFlatEffect.CurrentTechnique.Passes[0].Apply();

		base.Draw(offset);
	}
}