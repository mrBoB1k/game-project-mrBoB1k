using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GameProject;

public class McTimer
{
	public bool GoodToGo;
	protected int mSec;
	protected TimeSpan timer = new TimeSpan();


	public McTimer(int m)
	{
		GoodToGo = false;
		mSec = m;
	}

	public McTimer(int m, bool startloaded)
	{
		GoodToGo = startloaded;
		mSec = m;
	}

	public int MSec
	{
		get { return mSec; }
		set { mSec = value; }
	}

	public int Timer
	{
		get { return (int)timer.TotalMilliseconds; }
	}


	public void UpdateTimer()
	{
		timer += Globals.GameTime.ElapsedGameTime;
	}

	public void UpdateTimer(float speed)
	{
		timer += TimeSpan.FromTicks((long)(Globals.GameTime.ElapsedGameTime.Ticks * speed));
	}

	public virtual void AddToTimer(int msec)
	{
		timer += TimeSpan.FromMilliseconds((long)(msec));
	}

	public bool Test()
	{
		if (timer.TotalMilliseconds >= mSec || GoodToGo)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void Reset()
	{
		timer = timer.Subtract(new TimeSpan(0, 0, mSec / 60000, mSec / 1000, mSec % 1000));
		if (timer.TotalMilliseconds < 0)
		{
			timer = TimeSpan.Zero;
		}

		GoodToGo = false;
	}

	public void Reset(int newTimer)
	{
		timer = TimeSpan.Zero;
		MSec = newTimer;
		GoodToGo = false;
	}

	public void ResetToZero()
	{
		timer = TimeSpan.Zero;
		GoodToGo = false;
	}

	public virtual XElement ReturnXML()
	{
		XElement xml = new XElement("Timer",
			new XElement("mSec", mSec),
			new XElement("timer", Timer));


		return xml;
	}

	public void SetTimer(TimeSpan time)
	{
		timer = time;
	}

	public virtual void SetTimer(int msec)
	{
		timer = TimeSpan.FromMilliseconds((long)(msec));
	}
}