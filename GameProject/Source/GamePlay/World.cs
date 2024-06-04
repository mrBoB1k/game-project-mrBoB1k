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

public class World
{
	public Vector2 Offset;

	public UI Ui;

	public User User;
	public AIPlayer AiPlayer;

	public List<Projectile2d> Projectiles = new List<Projectile2d>();
	public List<AttackableObject> AllObjects = new List<AttackableObject>();

	public PassObject ResetWorld;

	public World(PassObject resetWorld)
	{
		ResetWorld = resetWorld;

		GameGlobals.PassProjectile = AddProjectile;
		GameGlobals.PassMob = AddMob;
		GameGlobals.PassSpawner = AddSpawner;
		GameGlobals.CheckScroll = CheckScroll;

		GameGlobals.Paused = false;
		
		Offset = new Vector2(0, 0);

		LoadDate(1);

		Ui = new UI();
	}

	public virtual void Update()
	{
		if (!User.Hero.Dead && User.Buildings.Count > 0 && !GameGlobals.Paused)
		{
			AllObjects.Clear();
			AllObjects.AddRange(User.GetAllObjects());
			AllObjects.AddRange(AiPlayer.GetAllObjects());

			User.Update(AiPlayer, Offset);
			AiPlayer.Update(User, Offset);

			for (int i = 0; i < Projectiles.Count; i++)
			{
				Projectiles[i].Update(Offset, AllObjects);

				if (Projectiles[i].Done)
				{
					Projectiles.RemoveAt(i);
					i--;
				}
			}
		}
		else
		{
			if (Globals.Keyboard.GetPress("Enter") && (User.Hero.Dead || User.Buildings.Count <= 0))
			{
				ResetWorld(null);
			}
		}
		
		if (Globals.Keyboard.GetSinglePress("Escape"))
		{
			GameGlobals.Paused = !GameGlobals.Paused;
		}

		Ui.Update(this);
	}

	public virtual void AddMob(object info)
	{
		var tempUnit = (Unit)info;

		if (User.Id == tempUnit.OwnerId)
		{
			User.AddUnit(tempUnit);
		}
		else if (AiPlayer.Id == tempUnit.OwnerId)
		{
			AiPlayer.AddUnit(tempUnit);
		}

		// AiPlayer.AddUnit((Mob)info);
	}

	public virtual void AddProjectile(object info)
	{
		Projectiles.Add((Projectile2d)info);
	}

	public virtual void AddSpawner(object info)
	{
		var tempSpawner = (Spawner)info;

		if (User.Id == tempSpawner.OwnerId)
		{
			User.AddSpawner(tempSpawner);
		}
		else if (AiPlayer.Id == tempSpawner.OwnerId)
		{
			AiPlayer.AddSpawner(tempSpawner);
		}
	}

	#region CheckScroll

	public virtual void CheckScroll(object info)
	{
		var tempPos = (Vector2)info;
		var targetOffset = Offset;

		var lerpAmount = 0.01f; // Скорость интерполяции, 0.1 означает 10% приближение к целевому значению за один кадр

		var leftBoundary = -Offset.X + (Globals.ScreenWidth * 0.4f);
		var rightBoundary = -Offset.X + (Globals.ScreenWidth * 0.6f);
		var topBoundary = -Offset.Y + (Globals.ScreenHeight * 0.4f);
		var bottomBoundary = -Offset.Y + (Globals.ScreenHeight * 0.6f);

		if (tempPos.X < leftBoundary)
		{
			float distance = leftBoundary - tempPos.X;
			targetOffset.X += distance;
		}

		if (tempPos.X > rightBoundary)
		{
			float distance = tempPos.X - rightBoundary;
			targetOffset.X -= distance;
		}

		if (tempPos.Y < topBoundary)
		{
			float distance = topBoundary - tempPos.Y;
			targetOffset.Y += distance;
		}

		if (tempPos.Y > bottomBoundary)
		{
			float distance = tempPos.Y - bottomBoundary;
			targetOffset.Y -= distance;
		}

		Offset = Vector2.Lerp(Offset, targetOffset, lerpAmount);
	}

	#endregion

	public virtual void LoadDate(int level)
	{
		var xml = XDocument.Load($"XML\\Saves\\Save{level}.xml");

		XElement tempElement = null;
		if (xml.Element("Root").Element("User") != null)
		{
			tempElement = xml.Element("Root").Element("User");
		}

		User = new User(1, tempElement);

		tempElement = null;
		if (xml.Element("Root").Element("AIPlayer") != null)
		{
			tempElement = xml.Element("Root").Element("AIPlayer");
		}

		AiPlayer = new AIPlayer(2, tempElement);
	}

	public virtual void Draw(Vector2 offset)
	{
		User.Draw(Offset);
		AiPlayer.Draw(Offset);

		for (int i = 0; i < Projectiles.Count; i++)
		{
			Projectiles[i].Draw(Offset);
		}

		Ui.Draw(this);
	}
}