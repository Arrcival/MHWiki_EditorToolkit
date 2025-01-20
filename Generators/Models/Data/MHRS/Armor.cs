﻿// <auto-generated />
using System.Globalization;
using System.Text;
using MediawikiTranslator.Generators;
using MediawikiTranslator.Models.ArmorSets;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace MediawikiTranslator.Models.Data.MHRS
{
	public class SimplifiedArmor
	{
		public string SetName { get; set; }
		public string SetBonus { get; set; }
		public string ArmorPieceName { get; set; }
		public string ArmorType { get; set; }
		public int Rarity { get; set; }
		public SimplifiedSkill[] Skills { get; set; }
	}

	public partial class Armor
	{
		[JsonProperty("snow.data.ArmorBaseUserData", NullValueHandling = NullValueHandling.Ignore)]
		public SnowDataArmorBaseUserData SnowDataArmorBaseUserData { get; set; }

		public static WebToolkitData[] GetWebToolkitData()
		{
			ArmorParam[] allArmor = GetArmors();
			ArmorSeriesParam[] armorSeries = ArmorSeries.GetArmorSeries();
			List<WebToolkitData> ret = [];
			Dictionary<int, string> mhrsColors = Generators.Items.GetMHRSWikiColors();
			foreach (ArmorParam armor in allArmor.Where(x => new long?[] { x.DefVal, x.FireRegVal, x.WaterRegVal, x.IceRegVal, x.ThunderRegVal, x.DragonRegVal }.Sum(y => y) > 0))
			{
				int rarity = Convert.ToInt32(armor.Rare!.Substring(2));
				WebToolkitData newArmor = new()
				{
					Game = "MHRS",
					MaleFrontImg = $"MHRS-{armor.SetName} Set Male Render.png",
					FemaleFrontImg = $"MHRS-{armor.SetName} Set Female Render.png",
					SetName = armor.SetName,
					Rarity = rarity,
					Rank = MediawikiTranslator.Generators.ArmorSets.GetRank("MHRS", rarity),
					OnlyForGender = (armor.SexualEquipable != "Both" ? armor.SexualEquipable.Replace("Only", "") : null)
				};
				if (ret.Any(x => x.SetName == newArmor.SetName && x.OnlyForGender == newArmor.OnlyForGender))
				{
					newArmor = ret.First(x => x.SetName == newArmor.SetName && x.OnlyForGender == newArmor.OnlyForGender);
				}
				List<Piece> pieces = [];
				if (newArmor.Pieces != null)
				{
					pieces = [.. newArmor.Pieces];
				}
				int maxLevel = GetMaxArmorLevel(armor.BuildupTable!);
				Piece newPiece = new Piece()
				{
					Name = armor.Name,
					MaxLevel = maxLevel,
					Defense = armor.DefVal,
					MaxDefense = armor.CraftingData == null ? null : armor.DefVal + ((maxLevel - 1) * 2),
					Description = armor.Explain.Replace("\r\n", " "),
					DragonRes = armor.DragonRegVal,
					FireRes = armor.FireRegVal,
					WaterRes = armor.WaterRegVal,
					IceRes = armor.IceRegVal,
					ThunderRes = armor.ThunderRegVal,
					ForgingCost = armor.Value,
					Rarity = rarity,
					IconType = TranslateArmorTypeToIcon(armor.Id),
					FemaleImage = "MHRS-" + armor.Name + " Female Render.png",
					MaleImage = "MHRS-" + armor.Name + " Male Render.png"
				};
				if (armor.CraftingData != null && armor.CraftingData.Materials != null)
				{
					newPiece.Materials = [.. armor.CraftingData.Materials.Select(x => new Material() {
						Color = x.Item1.WikiIconColor,
						Icon = x.Item1.WikiIconName,
						Name = x.Item1.Name,
						Quantity = x.Item2
					})];
				}
				newPiece.Skills = [..armor.Skills.Where(x => x != null).Select(x => new Skill()
				{
					Level = x.Level,
					Name = x.Name,
					WikiIconColor = mhrsColors[Convert.ToInt32(x.IconColor!.Replace("ITEM_ICON_COLOR_", ""))]
				})];
				newPiece.Decos1 = armor.Level1Decos;
				newPiece.Decos2 = armor.Level2Decos;
				newPiece.Decos3 = armor.Level3Decos;
				newPiece.Decos4 = armor.Level4Decos;
				if (!string.IsNullOrEmpty(newPiece.Name))
				{
					pieces.Add(newPiece);
				}
				newArmor.Pieces = [.. pieces];
				if (!ret.Any(x => x.SetName == newArmor.SetName) && !string.IsNullOrEmpty(newArmor.SetName))
				{
					ret.Add(newArmor);
				}
			}
			return [.. ret];
		}

		public static string TranslateArmorTypeToIcon(string type)
		{
			switch (type)
			{
				case string a when a.Contains("Arm"):
					return "Armguards";
				case string a when a.Contains("Leg"):
					return "Leggings";
				case string a when a.Contains("Chest"):
					return "Chestplate";
				case string a when a.Contains("Waist"):
					return "Waist";
				case string a when a.Contains("Head"):
					return "Helmet";
				default: return "";
			}
		}

		private static int GetMaxArmorLevel(string table)
		{
			return new List<Tuple<string, int>>()
			{
				new Tuple<string, int>("Table01", 3),
				new Tuple<string, int>("Table01", 5),
				new Tuple<string, int>("Table01", 6),
				new Tuple<string, int>("Table01", 9),
				new Tuple<string, int>("Table01", 11),
				new Tuple<string, int>("Table01", 14),
				new Tuple<string, int>("Table01", 16),
				new Tuple<string, int>("Table01", 17),
				new Tuple<string, int>("Table01", 19),
				new Tuple<string, int>("Table01", 22),
				new Tuple<string, int>("Table01", 28),
				new Tuple<string, int>("Table01", 34),
				new Tuple<string, int>("Table01_02", 2),
				new Tuple<string, int>("Table01_02", 4),
				new Tuple<string, int>("Table01_02", 6),
				new Tuple<string, int>("Table01_02", 7),
				new Tuple<string, int>("Table01_02", 8),
				new Tuple<string, int>("Table01_02", 10),
				new Tuple<string, int>("Table01_02", 12),
				new Tuple<string, int>("Table01_02", 14),
				new Tuple<string, int>("Table01_02", 17),
				new Tuple<string, int>("Table01_02", 28),
				new Tuple<string, int>("Table01_02", 30),
				new Tuple<string, int>("Table02", 2),
				new Tuple<string, int>("Table02", 4),
				new Tuple<string, int>("Table02", 5),
				new Tuple<string, int>("Table02", 7),
				new Tuple<string, int>("Table02", 8),
				new Tuple<string, int>("Table02", 9),
				new Tuple<string, int>("Table02", 10),
				new Tuple<string, int>("Table02", 14),
				new Tuple<string, int>("Table02", 16),
				new Tuple<string, int>("Table02", 22),
				new Tuple<string, int>("Table02", 27),
				new Tuple<string, int>("Table02_02", 2),
				new Tuple<string, int>("Table02_02", 5),
				new Tuple<string, int>("Table02_02", 7),
				new Tuple<string, int>("Table02_02", 8),
				new Tuple<string, int>("Table02_02", 10),
				new Tuple<string, int>("Table02_02", 12),
				new Tuple<string, int>("Table02_02", 14),
				new Tuple<string, int>("Table02_02", 19),
				new Tuple<string, int>("Table02_02", 26),
				new Tuple<string, int>("Table03", 4),
				new Tuple<string, int>("Table03", 5),
				new Tuple<string, int>("Table03", 7),
				new Tuple<string, int>("Table03", 9),
				new Tuple<string, int>("Table03", 11),
				new Tuple<string, int>("Table03", 12),
				new Tuple<string, int>("Table03", 23),
				new Tuple<string, int>("Table03_02", 2),
				new Tuple<string, int>("Table03_02", 4),
				new Tuple<string, int>("Table03_02", 7),
				new Tuple<string, int>("Table03_02", 9),
				new Tuple<string, int>("Table03_02", 11),
				new Tuple<string, int>("Table03_02", 12),
				new Tuple<string, int>("Table03_02", 21),
				new Tuple<string, int>("Table03_02", 22),
				new Tuple<string, int>("Table03_03", 1),
				new Tuple<string, int>("Table03_04", 1),
				new Tuple<string, int>("Table03_04", 4),
				new Tuple<string, int>("Table04", 4),
				new Tuple<string, int>("Table04", 7),
				new Tuple<string, int>("Table04", 9),
				new Tuple<string, int>("Table04", 11),
				new Tuple<string, int>("Table04", 18),
				new Tuple<string, int>("Table04", 20),
				new Tuple<string, int>("Table04_02", 4),
				new Tuple<string, int>("Table04_02", 5),
				new Tuple<string, int>("Table04_02", 8),
				new Tuple<string, int>("Table04_02", 10),
				new Tuple<string, int>("Table04_02", 11),
				new Tuple<string, int>("Table04_02", 15),
				new Tuple<string, int>("Table04_02", 16),
				new Tuple<string, int>("Table05", 4),
				new Tuple<string, int>("Table05", 5),
				new Tuple<string, int>("Table05", 8),
				new Tuple<string, int>("Table05", 10),
				new Tuple<string, int>("Table05", 11),
				new Tuple<string, int>("Table05", 15),
				new Tuple<string, int>("Table05", 16),
				new Tuple<string, int>("Table05_02", 3),
				new Tuple<string, int>("Table05_02", 5),
				new Tuple<string, int>("Table05_02", 6),
				new Tuple<string, int>("Table05_02", 10),
				new Tuple<string, int>("Table05_02", 11),
				new Tuple<string, int>("Table06", 3),
				new Tuple<string, int>("Table06", 5),
				new Tuple<string, int>("Table06", 6),
				new Tuple<string, int>("Table06", 10),
				new Tuple<string, int>("Table06", 11),
				new Tuple<string, int>("Table07", 3),
				new Tuple<string, int>("Table07", 5),
				new Tuple<string, int>("Table07", 6),
				new Tuple<string, int>("Table07", 8),
				new Tuple<string, int>("Table07", 9),
				new Tuple<string, int>("Table07", 10),
				new Tuple<string, int>("Table07", 11),
				new Tuple<string, int>("Table06_02", 4),
				new Tuple<string, int>("Table06_02", 5),
				new Tuple<string, int>("Table06_02", 8),
				new Tuple<string, int>("Table06_02", 11),
				new Tuple<string, int>("Table07_02", 4),
				new Tuple<string, int>("Table07_02", 5),
				new Tuple<string, int>("Table07_02", 8),
				new Tuple<string, int>("Table07_02", 11),
				new Tuple<string, int>("Table07_03", 1),
				new Tuple<string, int>("Table07_03", 5),
				new Tuple<string, int>("Table07_03", 8),
				new Tuple<string, int>("Table07_03", 9),
				new Tuple<string, int>("Table07_03", 10),
				new Tuple<string, int>("Table07_03", 11),
				new Tuple<string, int>("Table07_04", 3),
				new Tuple<string, int>("Table07_04", 11),
				new Tuple<string, int>("Table07_05", 3),
				new Tuple<string, int>("Table07_05", 11),
				new Tuple<string, int>("Table08", 3),
				new Tuple<string, int>("Table08", 5),
				new Tuple<string, int>("Table08", 7),
				new Tuple<string, int>("Table08", 9),
				new Tuple<string, int>("Table08", 10),
				new Tuple<string, int>("Table08", 11),
				new Tuple<string, int>("Table08", 15),
				new Tuple<string, int>("Table08", 16),
				new Tuple<string, int>("Table08", 17),
				new Tuple<string, int>("Table08", 18),
				new Tuple<string, int>("Table08", 22),
				new Tuple<string, int>("Table08", 26),
				new Tuple<string, int>("Table08", 29),
				new Tuple<string, int>("Table08", 37),
				new Tuple<string, int>("Table08_02", 4),
				new Tuple<string, int>("Table08_02", 5),
				new Tuple<string, int>("Table08_02", 7),
				new Tuple<string, int>("Table08_02", 8),
				new Tuple<string, int>("Table08_02", 10),
				new Tuple<string, int>("Table08_02", 11),
				new Tuple<string, int>("Table08_02", 12),
				new Tuple<string, int>("Table08_02", 13),
				new Tuple<string, int>("Table08_02", 14),
				new Tuple<string, int>("Table08_02", 16),
				new Tuple<string, int>("Table08_02", 22),
				new Tuple<string, int>("Table08_02", 25),
				new Tuple<string, int>("Table08_02", 33),
				new Tuple<string, int>("Table08_03", 5),
				new Tuple<string, int>("Table08_03", 6),
				new Tuple<string, int>("Table08_03", 7),
				new Tuple<string, int>("Table08_03", 9),
				new Tuple<string, int>("Table08_03", 10),
				new Tuple<string, int>("Table08_03", 11),
				new Tuple<string, int>("Table08_03", 12),
				new Tuple<string, int>("Table08_03", 20),
				new Tuple<string, int>("Table08_03", 23),
				new Tuple<string, int>("Table08_03", 31),
				new Tuple<string, int>("Table09", 4),
				new Tuple<string, int>("Table09", 5),
				new Tuple<string, int>("Table09", 7),
				new Tuple<string, int>("Table09", 9),
				new Tuple<string, int>("Table09", 10),
				new Tuple<string, int>("Table09", 11),
				new Tuple<string, int>("Table09", 12),
				new Tuple<string, int>("Table09", 20),
				new Tuple<string, int>("Table09", 23),
				new Tuple<string, int>("Table09", 31),
				new Tuple<string, int>("Table09_02", 2),
				new Tuple<string, int>("Table09_02", 6),
				new Tuple<string, int>("Table09_02", 8),
				new Tuple<string, int>("Table09_02", 9),
				new Tuple<string, int>("Table09_02", 10),
				new Tuple<string, int>("Table09_02", 11),
				new Tuple<string, int>("Table09_02", 19),
				new Tuple<string, int>("Table09_02", 22),
				new Tuple<string, int>("Table09_02", 30),
				new Tuple<string, int>("Table10", 6),
				new Tuple<string, int>("Table10", 7),
				new Tuple<string, int>("Table10", 8),
				new Tuple<string, int>("Table10", 9),
				new Tuple<string, int>("Table10", 10),
				new Tuple<string, int>("Table10", 18),
				new Tuple<string, int>("Table10", 21),
				new Tuple<string, int>("Table10", 29),
				new Tuple<string, int>("Table07_06", 2),
				new Tuple<string, int>("Table07_06", 3),
				new Tuple<string, int>("Table07_06", 4)
			}.Where(x => x.Item1 == table).Max(x => x.Item2);
		}

		public static ArmorParam[] GetArmors()
		{
			ArmorCraftingDataParam[] craftingData = ArmorCraftingData.GetCraftingData();
			SkillsParam[] allSkills = Skills.GetSkills();
			ArmorSeriesParam[] allSeries = ArmorSeries.GetArmorSeries();
			Dictionary<string, ArmorMsgMsg> armMessages = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\arm\a_arm_name.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> armMessagesMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\arm\a_arm_name_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> armMessagesExplain = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\arm\a_arm_explain.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> armMessagesExplainMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\arm\a_arm_explain_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> chestMessages = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\chest\a_chest_name.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> chestMessagesMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\chest\a_chest_name_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> chestMessagesExplain = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\chest\a_chest_explain.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> chestMessagesExplainMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\chest\a_chest_explain_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> headMessages = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\head\a_head_name.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> headMessagesMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\head\a_head_name_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> headMessagesExplain = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\head\a_head_explain.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> headMessagesExplainMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\head\a_head_explain_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> legMessages = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\leg\a_leg_name.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> legMessagesMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\leg\a_leg_name_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> legMessagesExplain = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\leg\a_leg_explain.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> legMessagesExplainMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\leg\a_leg_explain_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> waistMessages = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\waist\a_waist_name.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> waistMessagesMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\waist\a_waist_name_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> waistMessagesExplain = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\waist\a_waist_explain.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> waistMessagesExplainMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\waist\a_waist_explain_mr.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> seriesNames = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\armorseries_hunter_name.msg.539100710.json")).Msgs;
			Dictionary<string, ArmorMsgMsg> seriesNamesMR = ArmorMsg.FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\armorseries_hunter_name_mr.msg.539100710.json")).Msgs;
			ArmorParam[] armorData = FromJson(File.ReadAllText(@"D:\MH_Data Repo\MH_Data\Raw Data\MHRS\natives\stm\data\define\player\armor\armorbasedata.user.2.json")).SnowDataArmorBaseUserData.Param;
			foreach (ArmorParam armor in armorData)
			{
				int armorIdNum = Convert.ToInt32(armor.Id.Substring(armor.Id.LastIndexOf("_") + 1));
				int seriesIdNum = Convert.ToInt32(armor.Series.Substring(armor.Series.LastIndexOf("_") + 1));
				string rank = Generators.ArmorSets.GetRank("MHRS", Convert.ToInt32(armor.Rare!.Substring(2)));
				if (rank == "Master Rank" || armorIdNum == 457)
				{
					armorIdNum -= 300;
					seriesIdNum -= 300;
					armor.SetName = seriesNamesMR.Values.ToArray()[seriesIdNum].Content.English;
					switch (armor.Id)
					{
						case string a when a.Contains("Arm"):
							armor.Name = armMessagesMR.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = armMessagesExplainMR.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Leg"):
							armor.Name = legMessagesMR.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = legMessagesExplainMR.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Waist"):
							armor.Name = waistMessagesMR.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = waistMessagesExplainMR.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Head"):
							armor.Name = headMessagesMR.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = headMessagesExplainMR.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Chest"):
							armor.Name = chestMessagesMR.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = chestMessagesExplainMR.Values.ToArray()[armorIdNum].Content.English;
							break;
					}
				}
				else
				{
					armor.SetName = seriesNames.Values.ToArray()[seriesIdNum].Content.English;
					switch (armor.Id)
					{
						case string a when a.Contains("Arm"):
							armor.Name = armMessages.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = armMessagesExplain.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Leg"):
							armor.Name = legMessages.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = legMessagesExplain.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Waist"):
							armor.Name = waistMessages.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = waistMessagesExplain.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Head"):
							armor.Name = headMessages.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = headMessagesExplain.Values.ToArray()[armorIdNum].Content.English;
							break;
						case string a when a.Contains("Chest"):
							armor.Name = chestMessages.Values.ToArray()[armorIdNum].Content.English;
							armor.Explain = chestMessagesExplain.Values.ToArray()[armorIdNum].Content.English;
							break;
					}
				}
				if (armor.Name.StartsWith("Silver Sol"))
				{
					armor.SetName = "Silver Sol";
				}
				else if (armor.Name.StartsWith("Golden Lune"))
				{
					armor.SetName = "Golden Lune";
				}
				armor.Level1Decos = (int)armor.DecorationsNumList[0];
				armor.Level2Decos = (int)armor.DecorationsNumList[1];
				armor.Level3Decos = (int)armor.DecorationsNumList[2];
				armor.Level4Decos = (int)armor.DecorationsNumList[3];
				armor.Skills = new SkillsParam[armor.SkillList.Length];
				for (int i = 0; i < armor.SkillList.Length; i++)
				{
					if (armor.SkillList[i] != "Pl_EquipSkill_None")
					{
						SkillsParam toAdd = allSkills.FirstOrDefault(x => x.Id == armor.SkillList[i]);
						toAdd.Level = (int)armor.SkillLvList[i];
						armor.Skills[i] = toAdd;
					}
				}
				armor.CraftingData = craftingData.FirstOrDefault(x => x.Id == armor.Id);
			}
			return armorData;
		}

		public static void GetSimplifiedArmorData()
		{
			SimplifiedSkill[] skills = Generators.Skills.GetSimplifiedSkillsMHRS();
			ArmorParam[] armorData = GetArmors();
			SkillsParam[] allSkills = Skills.GetSkills();
			ArmorSeriesParam[] allSeries = ArmorSeries.GetArmorSeries();
			List<SimplifiedArmor> allArmor = [];
			foreach (ArmorParam armor in armorData)
			{
				SimplifiedArmor simpleArmor = new SimplifiedArmor()
				{
					ArmorPieceName = armor.Name,
					ArmorType = GetArmorType(armor.Id!),
					Rarity = Convert.ToInt32(armor.Rare!.Substring(2)),
					SetName = armor.SetName
				};
				if (!(string.IsNullOrEmpty(simpleArmor.SetName) && allArmor.Any(x => x.ArmorPieceName == simpleArmor.ArmorPieceName)) && !simpleArmor.ArmorPieceName.Contains("<COLOR FF0000>#Rejected#</COLOR>") && !string.IsNullOrEmpty(simpleArmor.ArmorPieceName) && !allArmor.Any(x => x.ArmorPieceName == simpleArmor.ArmorPieceName && x.SetName == simpleArmor.SetName))
				{
					List<SimplifiedSkill> armorSkills = new List<SimplifiedSkill>();
					int cntr = 0;
					foreach (string skillId in armor.SkillList)
					{
#nullable enable
						SkillsParam? skill = allSkills.FirstOrDefault(x => x.Id == skillId);
#nullable disable
						if (skill != null)
						{
							SimplifiedSkill simpleSkill = skills.First(x => x.Id == Skills.GetSkillId(skillId));
							if (simpleSkill.LevelDetails.Any())
								armorSkills.Add(new SimplifiedSkill()
								{
									Description = simpleSkill.Description,
									Id = simpleSkill.Id,
									Level = (int)armor.SkillLvList[cntr],
									MaxLevel = simpleSkill.MaxLevel,
									LevelDetails = simpleSkill.LevelDetails,
									Name = simpleSkill.Name,
									WikiIconColor = simpleSkill.WikiIconColor
								});
						}
						cntr++;
					}
					simpleArmor.Skills = [.. armorSkills];
					if (armorSkills.Any())
					{
						allArmor.Add(simpleArmor);
					}
				}
			}
			File.WriteAllText(@"D:\MH_Data Repo\MH_Data\Parsed Files\MHRS\mhrs simple armor data.json", JsonConvert.SerializeObject(allArmor, Formatting.Indented));
		}

		private static string GetArmorType(string armorName)
		{
			armorName = armorName.Substring(2);
			return armorName.Substring(0, armorName.IndexOf("_"));
		}
	}

	public partial class SnowDataArmorBaseUserData
	{
		[JsonProperty("_Param", NullValueHandling = NullValueHandling.Ignore)]
		public ArmorParam[] Param { get; set; }
	}

	public partial class ArmorParam
	{
		[JsonProperty("_Id", NullValueHandling = NullValueHandling.Ignore)]
		public string Id { get; set; }

		[JsonProperty("_IsValid", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IsValid { get; set; }

		[JsonProperty("_Series", NullValueHandling = NullValueHandling.Ignore)]
		public string Series { get; set; }

		[JsonProperty("_SortId", NullValueHandling = NullValueHandling.Ignore)]
		public long? SortId { get; set; }

		[JsonProperty("_ModelId", NullValueHandling = NullValueHandling.Ignore)]
		public string ModelId { get; set; }

		[JsonProperty("_Rare", NullValueHandling = NullValueHandling.Ignore)]
		public string Rare { get; set; }

		[JsonProperty("_Value", NullValueHandling = NullValueHandling.Ignore)]
		public long? Value { get; set; }

		[JsonProperty("_BuyValue", NullValueHandling = NullValueHandling.Ignore)]
		public long? BuyValue { get; set; }

		[JsonProperty("_SexualEquipable", NullValueHandling = NullValueHandling.Ignore)]
		public string SexualEquipable { get; set; }

		[JsonProperty("_SymbolColor1", NullValueHandling = NullValueHandling.Ignore)]
		public bool? SymbolColor1 { get; set; }

		[JsonProperty("_SymbolColor2", NullValueHandling = NullValueHandling.Ignore)]
		public bool? SymbolColor2 { get; set; }

		[JsonProperty("_DefVal", NullValueHandling = NullValueHandling.Ignore)]
		public long? DefVal { get; set; }

		[JsonProperty("_FireRegVal", NullValueHandling = NullValueHandling.Ignore)]
		public long? FireRegVal { get; set; }

		[JsonProperty("_WaterRegVal", NullValueHandling = NullValueHandling.Ignore)]
		public long? WaterRegVal { get; set; }

		[JsonProperty("_IceRegVal", NullValueHandling = NullValueHandling.Ignore)]
		public long? IceRegVal { get; set; }

		[JsonProperty("_ThunderRegVal", NullValueHandling = NullValueHandling.Ignore)]
		public long? ThunderRegVal { get; set; }

		[JsonProperty("_DragonRegVal", NullValueHandling = NullValueHandling.Ignore)]
		public long? DragonRegVal { get; set; }

		[JsonProperty("_BuildupTable", NullValueHandling = NullValueHandling.Ignore)]
		public string BuildupTable { get; set; }

		[JsonProperty("_BuffFormula", NullValueHandling = NullValueHandling.Ignore)]
		public string BuffFormula { get; set; }

		[JsonProperty("_DecorationsNumList", NullValueHandling = NullValueHandling.Ignore)]
		public long[] DecorationsNumList { get; set; }

		[JsonProperty("_SkillList", NullValueHandling = NullValueHandling.Ignore)]
		public string[] SkillList { get; set; }

		[JsonProperty("_SkillLvList", NullValueHandling = NullValueHandling.Ignore)]
		public long[] SkillLvList { get; set; }

		[JsonProperty("_IdAfterExChange", NullValueHandling = NullValueHandling.Ignore)]
		public string IdAfterExChange { get; set; }

		[JsonProperty("_CustomTableNo", NullValueHandling = NullValueHandling.Ignore)]
		public long? CustomTableNo { get; set; }

		[JsonProperty("_CustomCost", NullValueHandling = NullValueHandling.Ignore)]
		public long? CustomCost { get; set; }

		[JsonIgnore]
		public string Name { get; set; }

		[JsonIgnore]
		public string SetName { get; set; }

		[JsonIgnore]
		public string Explain { get; set; }

		[JsonIgnore]
		public MHRS.SkillsParam[] Skills { get; set; }

		[JsonIgnore]
		public int Level1Decos { get; set; }

		[JsonIgnore]
		public int Level2Decos { get; set; }

		[JsonIgnore]
		public int Level3Decos { get; set; }

		[JsonIgnore]
		public int Level4Decos { get; set; }

		[JsonIgnore]
		public ArmorCraftingDataParam CraftingData { get; set; }
	}

	public partial class Armor
	{
		public static Armor FromJson(string json) => JsonConvert.DeserializeObject<Armor>(json, MediawikiTranslator.Models.Data.MHRS.ArmorConverter.Settings);
	}

	internal static class ArmorConverter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}
}
