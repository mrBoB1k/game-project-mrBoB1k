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

public class Player
{
	public int Id;
	public Hero Hero;
	public List<Unit> Units = new List<Unit>();
	public List<Spawner> Spawners = new List<Spawner>();
	public List<Building> Buildings = new List<Building>();

	public Player(int id, XElement data)
	{
		Id = id;

		LoadDate(data);
	}

	public virtual void Update(Player enemy, Vector2 offset)
	{
		if (Hero != null)
		{
			Hero.Update(offset);
		}

		for (int i = 0; i < Spawners.Count; i++)
		{
			Spawners[i].Update(offset);

			if (Spawners[i].Dead)
			{
				Spawners.RemoveAt(i);
				i--;
			}
		}

		for (int i = 0; i < Units.Count; i++)
		{
			Units[i].Update(offset, enemy);

			if (Units[i].Dead)
			{
				ChangeScore(1);
				Units.RemoveAt(i);
				i--;
			}
		}

		for (int i = 0; i < Buildings.Count; i++)
		{
			Buildings[i].Update(offset, enemy);

			if (Buildings[i].Dead)
			{
				Buildings.RemoveAt(i);
				i--;
			}
		}
	}

	public virtual void AddUnit(object info)
	{
		var tempUnit = (Unit)info;
		tempUnit.OwnerId = Id;
		Units.Add(tempUnit);
	}

	public void AddSpawner(object info)
	{
		var tempSpawner = (Spawner)info;
		tempSpawner.OwnerId = Id;
		Spawners.Add(tempSpawner);
	}

	public virtual void ChangeScore(int score)
	{
	}

	public virtual List<AttackableObject> GetAllObjects()
	{
		var tempObjects = new List<AttackableObject>();
		tempObjects.AddRange(Units.ToList<AttackableObject>());
		tempObjects.AddRange(Spawners.ToList<AttackableObject>());
		tempObjects.AddRange(Buildings.ToList<AttackableObject>());

		return tempObjects;
	}

	public virtual void LoadDate(XElement data)
	{
		var spawnList = data.XPathSelectElements("Spawner").ToList<XElement>();

		Type sType = null;
		for (var i = 0; i < spawnList.Count; i++)
		{
			sType = Type.GetType($"GameProject.{spawnList[i].Element("type").Value}", true);

			Spawners.Add((Spawner)(Activator.CreateInstance(sType,
				new Vector2(Convert.ToInt32(spawnList[i].Element("Pos").Element("x").Value, Globals.Culture),
					Convert.ToInt32(spawnList[i].Element("Pos").Element("y").Value, Globals.Culture)),
				Id, spawnList[i])));
		}

		var buildingList = data.XPathSelectElements("Buildings").ToList<XElement>();

		foreach (var building in buildingList)
		{
			sType = Type.GetType($"GameProject.{building.Element("type").Value}", true);

			Buildings.Add((Building)(Activator.CreateInstance(sType, new Vector2(
					Convert.ToInt32(building.Element("Pos").Element("x").Value, Globals.Culture),
					Convert.ToInt32(building.Element("Pos").Element("y").Value, Globals.Culture)),
				Id)));
		}

		if (data.Element("Hero") != null)
		{
			Hero = new Hero("Player",
				new Vector2(Convert.ToInt32(data.Element("Hero").Element("Pos").Element("x").Value, Globals.Culture),
					Convert.ToInt32(data.Element("Hero").Element("Pos").Element("y").Value, Globals.Culture)),
				new Vector2(64, 112), Id);
		}
	}

	public virtual void Draw(Vector2 offset)
	{
		if (Hero != null)
		{
			Hero.Draw(offset);
		}

		for (int i = 0; i < Units.Count; i++)
		{
			Units[i].Draw(offset);
		}

		for (int i = 0; i < Buildings.Count; i++)
		{
			Buildings[i].Draw(offset);
		}

		for (int i = 0; i < Spawners.Count; i++)
		{
			Spawners[i].Draw(offset);
		}
	}
}