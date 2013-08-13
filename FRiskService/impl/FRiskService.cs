using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FRiskService.api;
using System.ServiceModel;
using System.ServiceModel.Activation;
using FRiskService.model;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Xml;
using System.IO;

namespace FRiskService.impl
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
				 ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class FRiskAPI : IFRiskAPI
	{
		private string strServerXmlPath = "xml/servers.xml";
		private string strServerXmlFullPath;

		private XmlDocument getServerXmlDocument()
		{
			XmlDocument xmldoc = new XmlDocument();
			strServerXmlFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strServerXmlPath);
			if (!File.Exists(strServerXmlFullPath))
			{
				xmldoc.LoadXml("<?xml version='1.0' encoding='UTF-8'?><Root/>");
			}
			else
			{
				xmldoc.Load(strServerXmlFullPath);
			}
			return xmldoc;
		}

		private string strTradeXmlPath = "xml/trade.xml";
		private string strTradeXmlFullPath;

		private XmlDocument getTradeXmlDocument()
		{
			XmlDocument xmldoc = new XmlDocument();
			strTradeXmlFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strTradeXmlPath);
			if (!File.Exists(strTradeXmlFullPath))
			{
				xmldoc.LoadXml("<?xml version='1.0' encoding='UTF-8'?><Root/>");
			}
			else
			{
				xmldoc.Load(strTradeXmlFullPath);
			}
			return xmldoc;
		}

		private string strSecurityXmlPath = "xml/security.xml";
		private string strSecurityXmlFullPath;

		private XmlDocument getSecurityXmlDocument()
		{
			XmlDocument xmldoc = new XmlDocument();
			strSecurityXmlFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strSecurityXmlPath);
			if (!File.Exists(strSecurityXmlFullPath))
			{
				xmldoc.LoadXml("<?xml version='1.0' encoding='UTF-8'?><Root/>");
			}
			else
			{
				xmldoc.Load(strSecurityXmlFullPath);
			}
			return xmldoc;
		}

		private string strAccountXmlPath = "xml/account.xml";
		private string strAccountXmlFullPath;

		private XmlDocument getAccountXmlDocument()
		{
			XmlDocument xmldoc = new XmlDocument();
			strAccountXmlFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strAccountXmlPath);
			if (!File.Exists(strAccountXmlFullPath))
			{
				xmldoc.LoadXml("<?xml version='1.0' encoding='UTF-8'?><Root/>");
			}
			else
			{
				xmldoc.Load(strAccountXmlFullPath);
			}
			return xmldoc;
		}

		private string strDayXmlPath = "xml/day.xml";
		private string strDayXmlFullPath;

		private XmlDocument getDayXmlDocument()
		{
			XmlDocument xmldoc = new XmlDocument();
			strDayXmlFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strDayXmlPath);
			if (!File.Exists(strDayXmlFullPath))
			{
				xmldoc.LoadXml("<?xml version='1.0' encoding='UTF-8'?><Root/>");
			}
			else
			{
				xmldoc.Load(strDayXmlFullPath);
			}
			return xmldoc;
		}

		private string strWaveXmlPath = "xml/wave.xml";
		private string strWaveXmlFullPath;

		private XmlDocument getWaveXmlDocument()
		{
			XmlDocument xmldoc = new XmlDocument();
			strWaveXmlFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strWaveXmlPath);
			if (!File.Exists(strWaveXmlFullPath))
			{
				xmldoc.LoadXml("<?xml version='1.0' encoding='UTF-8'?><Root/>");
			}
			else
			{
				xmldoc.Load(strWaveXmlFullPath);
			}
			return xmldoc;
		}

		public IList<Server> GetServerList()
		{
			XmlDocument xmldoc = this.getServerXmlDocument();
			XmlNodeList items = xmldoc.SelectNodes("//Item");

			IList<Server> list = new List<Server>();
			foreach (XmlNode item in items)
			{
				Server server = new Server();
				server.Id = item.SelectSingleNode("./Id").InnerText;
				server.Name = item.SelectSingleNode("./Name").InnerText;
				server.BrokerId = item.SelectSingleNode("./BrokerId").InnerText;
				server.ExchangeId = item.SelectSingleNode("./ExchangeId").InnerText;
				server.UserId = item.SelectSingleNode("./UserId").InnerText;
				server.Password = item.SelectSingleNode("./Password").InnerText;
				server.MarketAddress = item.SelectSingleNode("./MarketAddress").InnerText;
				server.TradeAddress = item.SelectSingleNode("./TradeAddress").InnerText;
				list.Add(server);
			}
			return list;
		}

		public Server GetServer(string id)
		{
			//DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Employee));
			//Employee result = obj.ReadObject(stream) as Employee;

			XmlDocument xmldoc = this.getServerXmlDocument();
			XmlNode item = xmldoc.SelectSingleNode(string.Format("//Item[./Id/text()='{0}']", id));
			if (item == null)
				return null;

			Server server = new Server();
			server.Id = item.SelectSingleNode("./Id").InnerText;
			server.Name = item.SelectSingleNode("./Name").InnerText;
			server.BrokerId = item.SelectSingleNode("./BrokerId").InnerText;
			server.ExchangeId = item.SelectSingleNode("./ExchangeId").InnerText;
			server.UserId = item.SelectSingleNode("./UserId").InnerText;
			server.Password = item.SelectSingleNode("./Password").InnerText;
			server.MarketAddress = item.SelectSingleNode("./MarketAddress").InnerText;
			server.TradeAddress = item.SelectSingleNode("./TradeAddress").InnerText;

			return server;
		}

		public Server AddServer(Server server)
		{
			XmlDocument xmldoc = this.getServerXmlDocument();
			XmlNode rootNode = xmldoc.SelectSingleNode("/Root");
			XmlNode item = xmldoc.CreateElement("Item");

			XmlNode childNode = xmldoc.CreateElement("Id");
			childNode.InnerText = server.Id;
			item.AppendChild(childNode);

			childNode = xmldoc.CreateElement("Name");
			childNode.InnerText = server.Name;
			item.AppendChild(childNode);

			childNode = xmldoc.CreateElement("BrokerId");
			childNode.InnerText = server.BrokerId;
			item.AppendChild(childNode);

			childNode = xmldoc.CreateElement("ExchangeId");
			childNode.InnerText = server.ExchangeId;
			item.AppendChild(childNode);

			childNode = xmldoc.CreateElement("UserId");
			childNode.InnerText = server.UserId;
			item.AppendChild(childNode);

			childNode = xmldoc.CreateElement("Password");
			childNode.InnerText = server.Password;
			item.AppendChild(childNode);

			childNode = xmldoc.CreateElement("MarketAddress");
			childNode.InnerText = server.MarketAddress;
			item.AppendChild(childNode);

			childNode = xmldoc.CreateElement("TradeAddress");
			childNode.InnerText = server.TradeAddress;
			item.AppendChild(childNode);

			rootNode.AppendChild(item);
			xmldoc.Save(this.strServerXmlFullPath);
			return server;
		}

		public Server UpdateServer(Server server)
		{
			XmlDocument xmldoc = this.getServerXmlDocument();
			XmlNode item = xmldoc.SelectSingleNode(string.Format("//Item[./Id/text()='{0}']", server.Id));
			if (item == null)
				return null;

			XmlNode childNode = item.SelectSingleNode("./Name");
			childNode.InnerText = server.Name;

			childNode = item.SelectSingleNode("./BrokerId");
			childNode.InnerText = server.BrokerId;

			childNode = item.SelectSingleNode("./ExchangeId");
			childNode.InnerText = server.ExchangeId;

			childNode = item.SelectSingleNode("./UserId");
			childNode.InnerText = server.UserId;

			childNode = item.SelectSingleNode("./Password");
			childNode.InnerText = server.Password;

			childNode = item.SelectSingleNode("./MarketAddress");
			childNode.InnerText = server.MarketAddress;

			childNode = item.SelectSingleNode("./TradeAddress");
			childNode.InnerText = server.TradeAddress;

			xmldoc.Save(this.strServerXmlFullPath);
			return server;
		}

		public bool DeleteServer(string id)
		{
			XmlDocument xmldoc = this.getServerXmlDocument();
			XmlNode item = xmldoc.SelectSingleNode(string.Format("//Item[./Id/text()='{0}']", id));
			if (item == null)
				return false;
			item.ParentNode.RemoveChild(item);
			xmldoc.Save(this.strServerXmlFullPath);
			return true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public Trade GetTrade()
		{
			XmlDocument xmldoc = this.getTradeXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			Trade param = new Trade();
			param.InstrumentID = rootNode.SelectSingleNode("./InstrumentID").InnerText;
			param.VolumeMultiple = int.Parse(rootNode.SelectSingleNode("./VolumeMultiple").InnerText);
			param.PriceTick = double.Parse(rootNode.SelectSingleNode("./PriceTick").InnerText);
			param.OpenRatioByMoney = double.Parse(rootNode.SelectSingleNode("./OpenRatioByMoney").InnerText);
			param.CloseRatioByMoney = double.Parse(rootNode.SelectSingleNode("./CloseRatioByMoney").InnerText);
			param.CloseTodayRatioByMoney = double.Parse(rootNode.SelectSingleNode("./CloseTodayRatioByMoney").InnerText);

			param.DefaultVolume = int.Parse(rootNode.SelectSingleNode("./DefaultVolume").InnerText);
			param.BuyStopPoint = int.Parse(rootNode.SelectSingleNode("./BuyStopPoint").InnerText);
			param.BuyAddPoint = int.Parse(rootNode.SelectSingleNode("./BuyAddPoint").InnerText);
			param.SellStopPoint = int.Parse(rootNode.SelectSingleNode("./SellStopPoint").InnerText);
			param.SellAddPoint = int.Parse(rootNode.SelectSingleNode("./SellAddPoint").InnerText);

			return param;
		}

		public Trade UpdateTrade(Trade param)
		{
			XmlDocument xmldoc = this.getTradeXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			rootNode.SelectSingleNode("./InstrumentID").InnerText = param.InstrumentID;
			rootNode.SelectSingleNode("./VolumeMultiple").InnerText = param.VolumeMultiple.ToString();
			rootNode.SelectSingleNode("./PriceTick").InnerText = param.PriceTick.ToString();
			rootNode.SelectSingleNode("./OpenRatioByMoney").InnerText = param.OpenRatioByMoney.ToString();
			rootNode.SelectSingleNode("./CloseRatioByMoney").InnerText = param.CloseRatioByMoney.ToString();
			rootNode.SelectSingleNode("./CloseTodayRatioByMoney").InnerText = param.CloseTodayRatioByMoney.ToString();

			rootNode.SelectSingleNode("./DefaultVolume").InnerText = param.DefaultVolume.ToString();
			rootNode.SelectSingleNode("./BuyStopPoint").InnerText = param.BuyStopPoint.ToString();
			rootNode.SelectSingleNode("./BuyAddPoint").InnerText = param.BuyAddPoint.ToString();
			rootNode.SelectSingleNode("./SellStopPoint").InnerText = param.SellStopPoint.ToString();
			rootNode.SelectSingleNode("./SellStopPoint").InnerText = param.SellStopPoint.ToString();

			xmldoc.Save(strTradeXmlFullPath);
			return param;
		}

		public string GetPassword(string type)
		{
			XmlDocument xmldoc = this.getSecurityXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;
			string pwd = null;
			switch(type)
			{
				case "owner":
					pwd = rootNode.SelectSingleNode("./OwnerPassword").InnerText;
					break;
				case "operator":
					pwd = rootNode.SelectSingleNode("./OperatorPassword").InnerText;
					break;
				case "admin":
					pwd = rootNode.SelectSingleNode("./AdminPassword").InnerText;
					break;
			}
			return pwd; 
		}

		public string UpdatePassword(string type, string password)
		{
			XmlDocument xmldoc = this.getSecurityXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;
			switch (type)
			{
				case "owner":
					rootNode.SelectSingleNode("./OwnerPassword").InnerText = password;
					break;
				case "operator":
					rootNode.SelectSingleNode("./OperatorPassword").InnerText = password;
					break;
				case "admin":
					rootNode.SelectSingleNode("./AdminPassword").InnerText = password;
					break;
			}
			xmldoc.Save(strSecurityXmlFullPath);
			return password; 
		}

		public AccountRisk GetAccountRisk()
		{
			XmlDocument xmldoc = this.getAccountXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			AccountRisk accountRisk = new AccountRisk();
			accountRisk.StartMoney = double.Parse(rootNode.SelectSingleNode("./StartMoney").InnerText);
			accountRisk.TotalLossAmount = double.Parse(rootNode.SelectSingleNode("./TotalLossAmount").InnerText);
			accountRisk.TotalLossRatio = double.Parse(rootNode.SelectSingleNode("./TotalLossRatio").InnerText);
			accountRisk.MinimalQuanyi = double.Parse(rootNode.SelectSingleNode("./MinimalQuanyi").InnerText);
			return accountRisk;
		}

		public AccountRisk UpdateAccountRisk(AccountRisk param)
		{
			XmlDocument xmldoc = this.getAccountXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			rootNode.SelectSingleNode("./StartMoney").InnerText = string.Format("{0:0.00}", param.StartMoney);
			rootNode.SelectSingleNode("./TotalLossAmount").InnerText = string.Format("{0:0.00}", param.TotalLossAmount);
			rootNode.SelectSingleNode("./TotalLossRatio").InnerText = string.Format("{0:0.0000}", param.TotalLossRatio);
			rootNode.SelectSingleNode("./MinimalQuanyi").InnerText = string.Format("{0:0.00}", param.MinimalQuanyi);

			xmldoc.Save(strAccountXmlFullPath);
			return param;
		}

		public DayRisk GetDayRisk()
		{
			XmlDocument xmldoc = this.getDayXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			DayRisk dayRisk = new DayRisk();
			dayRisk.DayLossAmount = double.Parse(rootNode.SelectSingleNode("./DayLossAmount").InnerText);
			dayRisk.DayLossTimes = int.Parse(rootNode.SelectSingleNode("./DayLossTimes").InnerText);
			dayRisk.StopMinutes = int.Parse(rootNode.SelectSingleNode("./StopMinutes").InnerText);
			return dayRisk;
		}

		public DayRisk UpdateDayRisk(DayRisk param)
		{
			XmlDocument xmldoc = this.getDayXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			rootNode.SelectSingleNode("./DayLossAmount").InnerText = string.Format("{0:0.00}", param.DayLossAmount);
			rootNode.SelectSingleNode("./DayLossTimes").InnerText = param.DayLossTimes.ToString();
			rootNode.SelectSingleNode("./StopMinutes").InnerText = param.StopMinutes.ToString();

			xmldoc.Save(strDayXmlFullPath);
			return param;
		}

		public WaveRisk GetWaveRisk()
		{
			XmlDocument xmldoc = this.getWaveXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			WaveRisk param = new WaveRisk();

			param.Spread = double.Parse(rootNode.SelectSingleNode("./Spread").InnerText);
			param.SmallEnable = int.Parse(rootNode.SelectSingleNode("./SmallEnable").InnerText);
			param.SmallRepeat = int.Parse(rootNode.SelectSingleNode("./SmallRepeat").InnerText);
			param.SmallFullAmount = double.Parse(rootNode.SelectSingleNode("./SmallFullAmount").InnerText);
			param.SmallFullTimes = int.Parse(rootNode.SelectSingleNode("./SmallFullTimes").InnerText);
			param.SmallPartialBuyAmount = double.Parse(rootNode.SelectSingleNode("./SmallPartialBuyAmount").InnerText);
			param.SmallPartialBuyTimes = int.Parse(rootNode.SelectSingleNode("./SmallPartialBuyTimes").InnerText);
			param.SmallPartialSellAmount = double.Parse(rootNode.SelectSingleNode("./SmallPartialSellAmount").InnerText);
			param.SmallPartialSellTimes = int.Parse(rootNode.SelectSingleNode("./SmallPartialSellTimes").InnerText);
			param.SmallUnlockCase1Ratio1 = double.Parse(rootNode.SelectSingleNode("./SmallUnlockCase1Ratio1").InnerText);
			param.SmallUnlockCase2Ratio2 = double.Parse(rootNode.SelectSingleNode("./SmallUnlockCase2Ratio2").InnerText);
			param.SmallUnlockCase2Times = int.Parse(rootNode.SelectSingleNode("./SmallUnlockCase2Times").InnerText);
			param.SmallUnlockCase3NRecord = int.Parse(rootNode.SelectSingleNode("./SmallUnlockCase3NRecord").InnerText);
			param.SmallUnlockCase3DiffValue = double.Parse(rootNode.SelectSingleNode("./SmallUnlockCase3DiffValue").InnerText);

			param.BigEnable = int.Parse(rootNode.SelectSingleNode("./BigEnable").InnerText);
			param.BigRepeat = int.Parse(rootNode.SelectSingleNode("./BigRepeat").InnerText);
			param.BigFullAmount = double.Parse(rootNode.SelectSingleNode("./BigFullAmount").InnerText);
			param.BigFullTimes = int.Parse(rootNode.SelectSingleNode("./BigFullTimes").InnerText);
			param.BigPartialBuyAmount = double.Parse(rootNode.SelectSingleNode("./BigPartialBuyAmount").InnerText);
			param.BigPartialBuyTimes = int.Parse(rootNode.SelectSingleNode("./BigPartialBuyTimes").InnerText);
			param.BigPartialSellAmount = double.Parse(rootNode.SelectSingleNode("./BigPartialSellAmount").InnerText);
			param.BigPartialSellTimes = int.Parse(rootNode.SelectSingleNode("./BigPartialSellTimes").InnerText);
			param.BigUnlockCase1DiffPrice = double.Parse(rootNode.SelectSingleNode("./BigUnlockCase1DiffPrice").InnerText);
			param.BigUnlockCase2Multiple = double.Parse(rootNode.SelectSingleNode("./BigUnlockCase2Multiple").InnerText);
			param.BigUnlockCase2DiffPrice = double.Parse(rootNode.SelectSingleNode("./BigUnlockCase2DiffPrice").InnerText);

			return param;
		}

		public WaveRisk UpdateWaveRisk(WaveRisk param)
		{
			XmlDocument xmldoc = this.getWaveXmlDocument();
			XmlNode rootNode = xmldoc.DocumentElement;
			if (rootNode == null)
				return null;

			rootNode.SelectSingleNode("./Spread").InnerText = param.Spread.ToString();
			rootNode.SelectSingleNode("./SmallEnable").InnerText = param.SmallEnable.ToString();
			rootNode.SelectSingleNode("./SmallRepeat").InnerText = param.SmallRepeat.ToString();
			rootNode.SelectSingleNode("./SmallFullAmount").InnerText = param.SmallFullAmount.ToString();
			rootNode.SelectSingleNode("./SmallFullTimes").InnerText = param.SmallFullTimes.ToString();
			rootNode.SelectSingleNode("./SmallPartialBuyAmount").InnerText = param.SmallPartialBuyAmount.ToString();
			rootNode.SelectSingleNode("./SmallPartialBuyTimes").InnerText = param.SmallPartialBuyTimes.ToString();
			rootNode.SelectSingleNode("./SmallPartialSellAmount").InnerText = param.SmallPartialSellAmount.ToString();
			rootNode.SelectSingleNode("./SmallPartialSellTimes").InnerText = param.SmallPartialSellTimes.ToString();
			rootNode.SelectSingleNode("./SmallUnlockCase1Ratio1").InnerText = param.SmallUnlockCase1Ratio1.ToString();
			rootNode.SelectSingleNode("./SmallUnlockCase2Ratio2").InnerText = param.SmallUnlockCase2Ratio2.ToString();
			rootNode.SelectSingleNode("./SmallUnlockCase2Times").InnerText = param.SmallUnlockCase2Times.ToString();
			rootNode.SelectSingleNode("./SmallUnlockCase3NRecord").InnerText = param.SmallUnlockCase3NRecord.ToString();
			rootNode.SelectSingleNode("./SmallUnlockCase3DiffValue").InnerText = param.SmallUnlockCase3DiffValue.ToString();

			rootNode.SelectSingleNode("./BigEnable").InnerText = param.BigEnable.ToString();
			rootNode.SelectSingleNode("./BigRepeat").InnerText = param.BigRepeat.ToString();
			rootNode.SelectSingleNode("./BigFullAmount").InnerText = param.BigFullAmount.ToString();
			rootNode.SelectSingleNode("./BigFullTimes").InnerText = param.BigFullTimes.ToString();
			rootNode.SelectSingleNode("./BigPartialBuyAmount").InnerText = param.BigPartialBuyAmount.ToString();
			rootNode.SelectSingleNode("./BigPartialBuyTimes").InnerText = param.BigPartialBuyTimes.ToString();
			rootNode.SelectSingleNode("./BigPartialSellAmount").InnerText = param.BigPartialSellAmount.ToString();
			rootNode.SelectSingleNode("./BigPartialSellTimes").InnerText = param.BigPartialSellTimes.ToString();
			rootNode.SelectSingleNode("./BigUnlockCase1DiffPrice").InnerText = param.BigUnlockCase1DiffPrice.ToString();
			rootNode.SelectSingleNode("./BigUnlockCase2Multiple").InnerText = param.BigUnlockCase2Multiple.ToString();
			rootNode.SelectSingleNode("./BigUnlockCase2DiffPrice").InnerText = param.BigUnlockCase2DiffPrice.ToString();

			xmldoc.Save(strWaveXmlFullPath);
			return param;
		}
	}
}
