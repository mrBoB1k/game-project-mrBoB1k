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

public class McKey
{
	public int State;
	public string Key, Print, Display;


	public McKey(string key, int state)
	{
		this.Key = key;
		this.State = state;
		MakePrint(this.Key);
	}

	public virtual void Update()
	{
		State = 2;
	}


	public void MakePrint(string key)
	{
		Display = key;

		string tempStr = "";

		if (key == "A" || key == "B" || key == "C" || key == "D" || key == "E" || key == "F" || key == "G" ||
		    key == "H" || key == "I" || key == "J" || key == "K" || key == "L" || key == "M" || key == "N" ||
		    key == "O" || key == "P" || key == "Q" || key == "R" || key == "S" || key == "T" || key == "U" ||
		    key == "V" || key == "W" || key == "X" || key == "Y" || key == "Z")
		{
			tempStr = key;
		}

		// if (key == "А" || key == "Б" || key == "В" || key == "Г" || key == "Д" || key == "Е" || key == "Ё" ||
		//     key == "Ж" || key == "З" || key == "И" || key == "Й" || key == "К" || key == "Л" || key == "М" ||
		//     key == "Н" || key == "О" || key == "П" || key == "Р" || key == "С" || key == "Т" || key == "У" ||
		//     key == "Ф" || key == "Х" || key == "Ц" || key == "Ч" || key == "Ш" || key == "Щ" || key == "Ъ" ||
		//     key == "Ы" || key == "Ь" || key == "Э" || key == "Ю" || key == "Я")
		// {
		// 	tempStr = key;
		// }

		if (key == "Space")
		{
			tempStr = " ";
		}

		if (key == "OemCloseBrackets")
		{
			tempStr = "]";
			Display = tempStr;
		}

		if (key == "OemOpenBrackets")
		{
			tempStr = "[";
			Display = tempStr;
		}

		if (key == "OemMinus")
		{
			tempStr = "-";
			Display = tempStr;
		}

		if (key == "OemPeriod" || key == "Decimal")
		{
			tempStr = ".";
		}

		if (key == "D1" || key == "D2" || key == "D3" || key == "D4" || key == "D5" || key == "D6" || key == "D7" ||
		    key == "D8" || key == "D9" || key == "D0")
		{
			tempStr = key.Substring(1);
		}
		else if (key == "NumPad1" || key == "NumPad2" || key == "NumPad3" || key == "NumPad4" || key == "NumPad5" ||
		         key == "NumPad6" || key == "NumPad7" || key == "NumPad8" || key == "NumPad9" || key == "NumPad0")
		{
			tempStr = key.Substring(6);
		}


		Print = tempStr;
	}
}