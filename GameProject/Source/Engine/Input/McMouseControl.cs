#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

#endregion

namespace GameProject;

public class McMouseControl
{
	public bool Dragging, RightDrag;
	public Vector2 NewMousePos, OldMousePos, FirstMousePos, NewMouseAdjustedPos, SystemCursorPos, ScreenLoc;
	public MouseState NewMouse, OldMouse, FirstMouse;

	public McMouseControl()
	{
		Dragging = false;

		NewMouse = Mouse.GetState();
		OldMouse = NewMouse;
		FirstMouse = NewMouse;

		NewMousePos = new Vector2(NewMouse.Position.X, NewMouse.Position.Y);
		OldMousePos = new Vector2(NewMouse.Position.X, NewMouse.Position.Y);
		FirstMousePos = new Vector2(NewMouse.Position.X, NewMouse.Position.Y);

		GetMouseAndAdjust();

		//screenLoc = new Vector2((int)(systemCursorPos.X/Globals.screenWidth), (int)(systemCursorPos.Y/Globals.screenHeight));
	}

	#region Properties

	public MouseState First
	{
		get { return FirstMouse; }
	}

	public MouseState New
	{
		get { return NewMouse; }
	}

	public MouseState Old
	{
		get { return OldMouse; }
	}

	#endregion

	public void Update()
	{
		GetMouseAndAdjust();


		if (NewMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
		    OldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
		{
			FirstMouse = NewMouse;
			FirstMousePos = NewMousePos = GetScreenPos(FirstMouse);
		}
	}

	public void UpdateOld()
	{
		OldMouse = NewMouse;
		OldMousePos = GetScreenPos(OldMouse);
	}

	public virtual float GetDistanceFromClick()
	{
		return Globals.GetDistance(NewMousePos, FirstMousePos);
	}

	public virtual void GetMouseAndAdjust()
	{
		NewMouse = Mouse.GetState();
		NewMousePos = GetScreenPos(NewMouse);
	}


	public int GetMouseWheelChange()
	{
		return NewMouse.ScrollWheelValue - OldMouse.ScrollWheelValue;
	}


	public Vector2 GetScreenPos(MouseState mouse)
	{
		Vector2 tempVec = new Vector2(mouse.Position.X, mouse.Position.Y);


		return tempVec;
	}

	public virtual bool LeftClick()
	{
		if (NewMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
		    OldMouse.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed && NewMouse.Position.X >= 0 &&
		    NewMouse.Position.X <= Globals.ScreenWidth && NewMouse.Position.Y >= 0 &&
		    NewMouse.Position.Y <= Globals.ScreenHeight)
		{
			return true;
		}

		return false;
	}

	public virtual bool LeftClickHold()
	{
		bool holding = false;

		if (NewMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
		    OldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && NewMouse.Position.X >= 0 &&
		    NewMouse.Position.X <= Globals.ScreenWidth && NewMouse.Position.Y >= 0 &&
		    NewMouse.Position.Y <= Globals.ScreenHeight)
		{
			holding = true;

			if (Math.Abs(NewMouse.Position.X - FirstMouse.Position.X) > 8 ||
			    Math.Abs(NewMouse.Position.Y - FirstMouse.Position.Y) > 8)
			{
				Dragging = true;
			}
		}


		return holding;
	}

	public virtual bool LeftClickRelease()
	{
		if (NewMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
		    OldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			Dragging = false;
			return true;
		}

		return false;
	}

	public virtual bool RightClick()
	{
		if (NewMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
		    OldMouse.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed && NewMouse.Position.X >= 0 &&
		    NewMouse.Position.X <= Globals.ScreenWidth && NewMouse.Position.Y >= 0 &&
		    NewMouse.Position.Y <= Globals.ScreenHeight)
		{
			return true;
		}

		return false;
	}

	public virtual bool RightClickHold()
	{
		bool holding = false;

		if (NewMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
		    OldMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && NewMouse.Position.X >= 0 &&
		    NewMouse.Position.X <= Globals.ScreenWidth && NewMouse.Position.Y >= 0 &&
		    NewMouse.Position.Y <= Globals.ScreenHeight)
		{
			holding = true;

			if (Math.Abs(NewMouse.Position.X - FirstMouse.Position.X) > 8 ||
			    Math.Abs(NewMouse.Position.Y - FirstMouse.Position.Y) > 8)
			{
				RightDrag = true;
			}
		}


		return holding;
	}

	public virtual bool RightClickRelease()
	{
		if (NewMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
		    OldMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
		{
			Dragging = false;
			return true;
		}

		return false;
	}

	public void SetFirst()
	{
	}
}