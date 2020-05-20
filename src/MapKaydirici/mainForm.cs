using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace MapKaydirici
{
	/// <summary>
	/// Kullanacağımız Form tipinde nesnemiz
	/// </summary>
	public partial class mainForm : Form
	{
		/// <summary>
		/// Ana Formumuz oluşurken işleyeceği satırlar bu fonksiyonda tutuluyor
		/// </summary>
		public mainForm()
		{
			InitializeComponent();
			NumberFormatInfo nfi = new NumberFormatInfo();
			nfi.NumberDecimalSeparator = ".";
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
		}

		/// <summary>
		/// CreateObject fonksiyonu ile oluşturulan obje
		/// </summary>
		class Object
		{
			public int model;
			public decimal posX;
			public decimal posY;
			public decimal posZ;
			public decimal rotX;
			public decimal rotY;
			public decimal rotZ;
			public decimal drawDistance = 300;
		}
		/// <summary>
		/// CreateDynamicObject fonksiyonu ile oluşturulan obje
		/// </summary>
		class DynamicObject : Object
		{
			public decimal streamDistance = 300;
			public int worldid = -1;
			public int interiorid = -1;
			public int playerid = -1;
			public int areaid = -1;
			public int priority = 0;
		}
		/// <summary>
		/// CreateDynamicObjectEx fonksiyonu ile oluşturulan obje
		/// </summary>
		class DynamicObjectEx : Object
		{
			public decimal streamDistance = 300;
			public int[] worlds = { -1 };
			public int[] interiors = { -1 };
			public int[] players = { -1 };
			public int[] areas = { -1 };
			public int priority = 0;
		}

		/// <summary>
		/// Hatalarımız hangi satırda, ne mesajı içeriyor onu göstermek için Hata sınıfı
		/// </summary>
		class Hata
		{
			public int satir;
			public string mesaj;
		}

		StringBuilder sg = new StringBuilder();
		List<Hata> hataListesi = new List<Hata>();
		static bool defaultDrawDistance = true, defaultStreamDistance = true, defaultPlayerId = true, defaultWorldId = true, defaultInteriorId = true, defaultAreaId = true;

		/// <summary>
		/// Kaydır butonuna basınca olacaklar
		/// </summary>
		/// <param name="sender">Gönderen, bu durumda Kaydır butonumuz</param>
		/// <param name="e">Olay argümanları</param>
		private void btnKaydir_Click(object sender, EventArgs e)
		{
			int currentPos = 0, endPos = 0;

			if (txtMap.Text.Trim() == string.Empty) MessageBox.Show("Lütfen metin alanını boş bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
			{
				if (MessageBox.Show($"Girdiğiniz haritanın pozisyonuna ({nupX.Value}, {nupY.Value}, {nupZ.Value}) koordinatı eklenip kaydırılacaktır.\nOnaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					for (int i = 0; i < txtMap.Lines.Count; i++)
					{
						string satir = txtMap.Lines[i];
						if (satir.Contains("CreateObject("))
						{
							currentPos = satir.IndexOf("CreateObject(") + 13;
							endPos = satir.IndexOf(")", 13);
							string degerler = satir.Substring(currentPos, endPos - currentPos);
							degerler = degerler.Replace(" ", "");
							Object obj = ParseRegularCoordinate(degerler.Split(','));
							if (obj != null)
							{
								string newdegerler = $"{obj.model}, {obj.posX + nupX.Value}, {obj.posY + nupY.Value}, {obj.posZ + nupZ.Value}, {obj.rotX}, {obj.rotY}, {obj.rotZ}";
								if (!defaultDrawDistance) newdegerler += $", {obj.drawDistance}";
								newdegerler += ");";
								defaultDrawDistance = true;
								satir = satir.Substring(0, currentPos) + newdegerler;
							}
							else
							{
								Hata hata = new Hata();
								hata.satir = i + 1;
								hata.mesaj = "[SATIR: " + (hata.satir) + "] CreateObject fonksiyonu hatalı!";
								hataListesi.Add(hata);
							}
						}
						else if (satir.Contains("CreateDynamicObject("))
						{
							currentPos = satir.IndexOf("CreateDynamicObject(") + 20;
							endPos = satir.IndexOf(")", 20);
							string degerler = satir.Substring(currentPos, endPos - currentPos);
							degerler = degerler.Replace(" ", "");
							DynamicObject obj = ParseDynamicCoordinate(degerler.Split(','));
							if (obj != null)
							{
								// Değerleri yazılış biçimine ve sırasına göre bir metine yazıyoruz
								string newdegerler = $"{obj.model}, {obj.posX + nupX.Value}, {obj.posY + nupY.Value}, {obj.posZ + nupZ.Value}, {obj.rotX}, {obj.rotY}, {obj.rotZ}";

								// Eğer fonksiyonun tüm nimetlerinden faydalanmışsa onları da buraya yazıyoruz
								newdegerler += $", {obj.worldid}";
								newdegerler += $", {obj.interiorid}";
								newdegerler += $", {obj.playerid}";
								newdegerler += $", {obj.streamDistance}";
								newdegerler += $", {obj.drawDistance}";
								if (!defaultAreaId) newdegerler += $", {obj.areaid}";
								else newdegerler += ", -1";

								// Son olarak yazılış biçimi doğru olması için parantezi kapıyoruz
								newdegerler += ");";

								// Default değerleri sıfırla
								defaultDrawDistance = true;
								defaultStreamDistance = true;
								defaultPlayerId = true;
								defaultWorldId = true;
								defaultInteriorId = true;

								// Satırı mevcut pozisyona göre kırp ve yeni değerleri ekle
								satir = satir.Substring(0, currentPos) + newdegerler;
							}
							else
							{
								Hata hata = new Hata();
								hata.satir = i + 1;
								hata.mesaj = "[SATIR: " + (hata.satir) + "] CreateObject fonksiyonu hatalı!";
								hataListesi.Add(hata);
							}
						}
						sg.AppendLine(satir);
					}
					
					if (hataListesi.Count > 0)
					{
						string HataMesaji = "";
						foreach (Hata h in hataListesi) HataMesaji += h.mesaj + "\n";
						MessageBox.Show(HataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
						sg.Clear();
						return;
					}

					txtMap.Text = sg.ToString();
					Clipboard.SetText(txtMap.Text);
					MessageBox.Show("Kaydırdığınız harita panoya kopyalandı.");
					sg.Clear();
				}
			}
		}

		/// <summary>
		/// Gelen bilgiye göre işleme yapar ve Object tipinde nesne döndürür.
		/// </summary>
		/// <param name="row">Gelecek string dizisi</param>
		/// <returns>Varsayılan değerleriyle birlikte Object döndürür</returns>
		static Object ParseRegularCoordinate(string[] row)
		{
			Object o = new Object();
			if (!int.TryParse(row[0], out o.model)) return null;
			if (!decimal.TryParse(row[1],NumberStyles.Float,CultureInfo.CreateSpecificCulture("en-GB"),out o.posX)) return null;
			if (!decimal.TryParse(row[2], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.posY)) return null;
			if (!decimal.TryParse(row[3], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.posZ)) return null;
			if (!decimal.TryParse(row[4], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.rotX)) return null;
			if (!decimal.TryParse(row[5], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.rotY)) return null;
			if (!decimal.TryParse(row[6], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.rotZ)) return null;
			if (row.Length > 7) {
				if (!decimal.TryParse(row[7], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.drawDistance)) return null;
				defaultDrawDistance = false;
			};
			return o;
		}

		static DynamicObject ParseDynamicCoordinate(string[] row)
		{
			DynamicObject o = new DynamicObject();
			if (!int.TryParse(row[0], out o.model)) return null;
			if (!decimal.TryParse(row[1], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.posX)) return null;
			if (!decimal.TryParse(row[2], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.posY)) return null;
			if (!decimal.TryParse(row[3], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.posZ)) return null;
			if (!decimal.TryParse(row[4], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.rotX)) return null;
			if (!decimal.TryParse(row[5], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.rotY)) return null;
			if (!decimal.TryParse(row[6], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.rotZ)) return null;
			if (row.Length > 7)
			{
				if (!int.TryParse(row[7], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.worldid)) return null;
				defaultWorldId = false;
			};
			if (row.Length > 8)
			{
				if (!int.TryParse(row[8], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.interiorid)) return null;
				defaultInteriorId = false;
			};
			if (row.Length > 9)
			{
				if (!int.TryParse(row[9], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.playerid)) return null;
				defaultPlayerId = false;
			};
			if (row.Length > 10)
			{
				if (!decimal.TryParse(row[10], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.streamDistance)) return null;
				defaultStreamDistance = false;
			};
			if (row.Length > 11)
			{
				if (!decimal.TryParse(row[11], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.drawDistance)) return null;
				defaultDrawDistance = false;
			};
			if (row.Length > 12)
			{
				if (!int.TryParse(row[12], NumberStyles.Float, CultureInfo.CreateSpecificCulture("en-GB"), out o.areaid)) return null;
				defaultAreaId = false;
			};
			return o;
		}

		/*
		CreateDynamicObjectEx(
		modelid, 
		Float:x, Float:y, Float:z, 
		Float:rx, Float:ry, Float:rz, 
		Float:streamdistance = STREAMER_OBJECT_SD, Float:drawdistance = STREAMER_OBJECT_DD, 
		worlds[] = { -1 }, interiors[] = { -1 }, players[] = { -1 }, 
		areas[] = { -1 }, priority = 0, 
		maxworlds = sizeof worlds, maxinteriors = sizeof interiors, maxplayers = sizeof players, maxareas = sizeof areas
		);
		*/
		Style Golden = new TextStyle(Brushes.Gold, null, FontStyle.Bold);
		Style GreenStyle = new TextStyle(Brushes.LimeGreen, null, FontStyle.Italic);

		private void fctxtMap_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
		{
			Range range = (sender as FastColoredTextBox).VisibleRange;

			//clear style of changed range
			range.ClearStyle(Golden);
			range.ClearStyle(GreenStyle);

			// Yorumlar
			range.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
			range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
			range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);

			// Map oluşturma fonksiyonlarını altın renkli yap
			range.SetStyle(Golden, @"([C][r][e][a][t][e][O][b][j][e][c][t])");
			range.SetStyle(Golden, @"([C][r][e][a][t][e][D][y][n][a][m][i][c][O][b][j][e][c][t])");
			range.SetStyle(Golden, @"([C][r][e][a][t][e][D][y][n][a][m][i][c][O][b][j][e][c][t][E][x])");
		}

		private void txtMap_Pasting(object sender, TextChangingEventArgs e)
		{
			Range range = (sender as FastColoredTextBox).VisibleRange;

			//clear style of changed range
			range.ClearStyle(Golden);
			range.ClearStyle(GreenStyle);

			// Yorumlar
			range.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
			range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
			range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);

			// Map oluşturma fonksiyonlarını altın renkli yap
			range.SetStyle(Golden, @"([C][r][e][a][t][e][O][b][j][e][c][t])");
			range.SetStyle(Golden, @"([C][r][e][a][t][e][D][y][n][a][m][i][c][O][b][j][e][c][t])");
			range.SetStyle(Golden, @"([C][r][e][a][t][e][D][y][n][a][m][i][c][O][b][j][e][c][t][E][x])");
		}
	}
}
