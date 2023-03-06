using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

namespace GarticBot
{
	public class Settings
	{


		public Point OpenPalette { get; set; } = new Point(0, 0);
		public Point EmptySpace { get; set; } = new Point(0, 0);
		public Point RedValue { get; set; } = new Point(0, 0);
		public Point GreenValue { get; set; } = new Point(0, 0);
		public Point BlueValue { get; set; } = new Point(0, 0);

		public Rectangle DrawingPlace { get; set; } = new Rectangle(400, 400, 300, 200);
		public bool OnTop { get; set; } = false;

		public uint SkipColorKeycode { get; set; } = 0x74; //Default: F5
		public uint CloseThreadKeycode { get; set; } = 0x1B; //Default: Esc

		public Settings(bool load)
		{
			try
			{
				using (StreamReader file = File.OpenText(@"settings.json"))
				{
					JsonSerializer serializer = new JsonSerializer();
					Settings tmp = (Settings)serializer.Deserialize(file, typeof(Settings));

					OpenPalette = tmp.OpenPalette;
					EmptySpace = tmp.EmptySpace;
					RedValue = tmp.RedValue;
					GreenValue = tmp.GreenValue;
					BlueValue = tmp.BlueValue;
					DrawingPlace = tmp.DrawingPlace;
					OnTop = tmp.OnTop;
					SkipColorKeycode = tmp.SkipColorKeycode;
					CloseThreadKeycode = tmp.CloseThreadKeycode;
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Error reading settings file...");
			}
		}

		public Settings()
		{

		}

		public void Save()
		{
			using (StreamWriter file = File.CreateText(@"settings.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Serialize(file, this);
			}
		}

	}
}
