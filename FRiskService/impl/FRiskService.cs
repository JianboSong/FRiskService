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
using System.Data.SQLite;

namespace FRiskService.impl
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
				 ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class FRiskAPI : IFRiskAPI
	{
		public IList<Account> GetAccountList()
		{
			IList<Account> list = new List<Account>();
			using (var conn = new SQLiteConnection(Global.connstr))
			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = "SELECT * from trade_account";
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						Account account = new Account();
						account.Id = reader.IsDBNull(reader.GetOrdinal("id")) ? null : reader.GetString(reader.GetOrdinal("id"));
						account.Name = reader.IsDBNull(reader.GetOrdinal("name")) ? null : reader.GetString(reader.GetOrdinal("name"));
						account.ExchangeId = reader.IsDBNull(reader.GetOrdinal("exchange_id")) ? null : reader.GetString(reader.GetOrdinal("exchange_id"));
						account.BrokerId = reader.IsDBNull(reader.GetOrdinal("broker_id")) ? null : reader.GetString(reader.GetOrdinal("broker_id"));
						account.UserId = reader.IsDBNull(reader.GetOrdinal("user_id")) ? null : reader.GetString(reader.GetOrdinal("user_id"));
						account.Password = reader.IsDBNull(reader.GetOrdinal("password")) ? null : reader.GetString(reader.GetOrdinal("password"));
						account.TradeAddress = reader.IsDBNull(reader.GetOrdinal("trade_addr")) ? null : reader.GetString(reader.GetOrdinal("trade_addr"));
						account.MarketAddress = reader.IsDBNull(reader.GetOrdinal("market_addr")) ? null : reader.GetString(reader.GetOrdinal("market_addr"));
						account.InstrumentId = reader.IsDBNull(reader.GetOrdinal("instrument_id")) ? null : reader.GetString(reader.GetOrdinal("instrument_id"));

						account.OwnerPassword = reader.IsDBNull(reader.GetOrdinal("owner_password")) ? null : reader.GetString(reader.GetOrdinal("owner_password"));
						account.TeamPassword = reader.IsDBNull(reader.GetOrdinal("team_password")) ? null : reader.GetString(reader.GetOrdinal("team_password"));
						account.AdminPassword = reader.IsDBNull(reader.GetOrdinal("admin_password")) ? null : reader.GetString(reader.GetOrdinal("admin_password"));
						account.OperatorPassword = reader.IsDBNull(reader.GetOrdinal("operator_password")) ? null : reader.GetString(reader.GetOrdinal("operator_password"));

						account.StartMoney = reader.GetDouble(reader.GetOrdinal("start_money"));
						account.TotalLossRatio = reader.GetDouble(reader.GetOrdinal("total_loss_ratio"));
						account.TotalLossAmount = reader.GetDouble(reader.GetOrdinal("total_loss_amount"));
						account.MinimalQuanyi = reader.GetDouble(reader.GetOrdinal("minimal_money"));

						account.DayLossAmount = reader.GetDouble(reader.GetOrdinal("day_loss_amount"));
						account.DayLossTimes = reader.GetInt32(reader.GetOrdinal("day_loss_times"));
						account.StopMinutes = reader.GetInt32(reader.GetOrdinal("stop_minutes"));
						account.StopTime = reader.IsDBNull(reader.GetOrdinal("stop_time")) ? null : reader.GetString(reader.GetOrdinal("stop_time"));

						list.Add(account);
					}
				}
			}
			return list;
		}

		public Account GetAccount(string id)
		{
			//DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Employee));
			//Employee result = obj.ReadObject(stream) as Employee;

			using (var conn = new SQLiteConnection(Global.connstr))
			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = "SELECT * from trade_account where id = @id";
				cmd.Parameters.AddWithValue("@id", id);
				using (var reader = cmd.ExecuteReader())
				{
					Account account = new Account();
					while (reader.Read())
					{
						account.Id = reader.IsDBNull(reader.GetOrdinal("id")) ? null : reader.GetString(reader.GetOrdinal("id"));
						account.Name = reader.IsDBNull(reader.GetOrdinal("name")) ? null : reader.GetString(reader.GetOrdinal("name"));
						account.ExchangeId = reader.IsDBNull(reader.GetOrdinal("exchange_id")) ? null : reader.GetString(reader.GetOrdinal("exchange_id"));
						account.BrokerId = reader.IsDBNull(reader.GetOrdinal("broker_id")) ? null : reader.GetString(reader.GetOrdinal("broker_id"));
						account.UserId = reader.IsDBNull(reader.GetOrdinal("user_id")) ? null : reader.GetString(reader.GetOrdinal("user_id"));
						account.Password = reader.IsDBNull(reader.GetOrdinal("password")) ? null : reader.GetString(reader.GetOrdinal("password"));
						account.TradeAddress = reader.IsDBNull(reader.GetOrdinal("trade_addr")) ? null : reader.GetString(reader.GetOrdinal("trade_addr"));
						account.MarketAddress = reader.IsDBNull(reader.GetOrdinal("market_addr")) ? null : reader.GetString(reader.GetOrdinal("market_addr"));
						account.InstrumentId = reader.IsDBNull(reader.GetOrdinal("instrument_id")) ? null : reader.GetString(reader.GetOrdinal("instrument_id"));

						account.OwnerPassword = reader.IsDBNull(reader.GetOrdinal("owner_password")) ? null : reader.GetString(reader.GetOrdinal("owner_password"));
						account.TeamPassword = reader.IsDBNull(reader.GetOrdinal("team_password")) ? null : reader.GetString(reader.GetOrdinal("team_password"));
						account.AdminPassword = reader.IsDBNull(reader.GetOrdinal("admin_password")) ? null : reader.GetString(reader.GetOrdinal("admin_password"));
						account.OperatorPassword = reader.IsDBNull(reader.GetOrdinal("operator_password")) ? null : reader.GetString(reader.GetOrdinal("operator_password"));

						account.StartMoney = reader.GetDouble(reader.GetOrdinal("start_money"));
						account.TotalLossRatio = reader.GetDouble(reader.GetOrdinal("total_loss_ratio"));
						account.TotalLossAmount = reader.GetDouble(reader.GetOrdinal("total_loss_amount"));
						account.MinimalQuanyi = reader.GetDouble(reader.GetOrdinal("minimal_money"));

						account.DayLossAmount = reader.GetDouble(reader.GetOrdinal("day_loss_amount"));
						account.DayLossTimes = reader.GetInt32(reader.GetOrdinal("day_loss_times"));
						account.StopMinutes = reader.GetInt32(reader.GetOrdinal("stop_minutes"));
						account.StopTime = reader.IsDBNull(reader.GetOrdinal("stop_time")) ? null : reader.GetString(reader.GetOrdinal("stop_time"));

					}
					return account;
				}
			}
		}

		public Account AddAccount(Account account)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"insert into trade_account (id, name, exchange_id, broker_id, user_id
						, password, trade_addr, market_addr, instrument_id, owner_password, team_password
						, admin_password, operator_password, start_money, total_loss_ratio, total_loss_amount, minimal_money
						, day_loss_amount, day_loss_times, stop_minutes, stop_time
						) values (@id, @name, @exchangeId, @brokerId, @userId
						, @password, @tradeAddr, @marketAddr, @instrumentId, @ownerPassword, @teamPassword
						, @adminPassword, @operatorPassword, @startMoney, @totalLossRatio, @totalLossAmount, @minimalMoney
						, @dayLossAmount, @dayLossTimes, @stopMinutes, @stopTime
						)";
				cmd.Parameters.AddWithValue("@id", account.Id);
				cmd.Parameters.AddWithValue("@name", account.Name);
				cmd.Parameters.AddWithValue("@exchangeId", account.ExchangeId);
				cmd.Parameters.AddWithValue("@brokerId", account.BrokerId);
				cmd.Parameters.AddWithValue("@userId", account.UserId);
				cmd.Parameters.AddWithValue("@password", account.Password);
				cmd.Parameters.AddWithValue("@tradeAddr", account.TradeAddress);
				cmd.Parameters.AddWithValue("@marketAddr", account.MarketAddress);
				cmd.Parameters.AddWithValue("@instrumentId", account.InstrumentId);

				cmd.Parameters.AddWithValue("@ownerPassword", account.OwnerPassword);
				cmd.Parameters.AddWithValue("@teamPassword", account.TeamPassword);
				cmd.Parameters.AddWithValue("@adminPassword", account.AdminPassword);
				cmd.Parameters.AddWithValue("@operatorPassword", account.OperatorPassword);

				cmd.Parameters.AddWithValue("@startMoney", account.StartMoney);
				cmd.Parameters.AddWithValue("@totalLossRatio", account.TotalLossRatio);
				cmd.Parameters.AddWithValue("@totalLossAmount", account.TotalLossAmount);
				cmd.Parameters.AddWithValue("@minimalMoney", account.MinimalQuanyi);

				cmd.Parameters.AddWithValue("@dayLossAmount", account.DayLossAmount);
				cmd.Parameters.AddWithValue("@dayLossTimes", account.DayLossTimes);
				cmd.Parameters.AddWithValue("@stopMinutes", account.StopMinutes);
				cmd.Parameters.AddWithValue("@stopTime", account.StopTime);

				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return null;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return account;
			}
		}

		public Account UpdateAccount(Account account)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"update trade_account set name = @name, exchange_id = @exchangeId, broker_id = @brokerId, user_id = @userId
						, password = @password, trade_addr =  @tradeAddr, market_addr = @marketAddr, instrument_id = @instrumentId, owner_password = @ownerPassword, team_password = @teamPassword
						, admin_password = @adminPassword, operator_password = @operatorPassword, start_money = @startMoney, total_loss_ratio = @totalLossRatio, total_loss_amount = @totalLossAmount, minimal_money = @minimalMoney
						, day_loss_amount = @dayLossAmount, day_loss_times = @dayLossTimes, stop_minutes = @stopMinutes, stop_time = @stopTime
						where id = @id";
				cmd.Parameters.AddWithValue("@id", account.Id);
				cmd.Parameters.AddWithValue("@name", account.Name);
				cmd.Parameters.AddWithValue("@exchangeId", account.ExchangeId);
				cmd.Parameters.AddWithValue("@brokerId", account.BrokerId);
				cmd.Parameters.AddWithValue("@userId", account.UserId);
				cmd.Parameters.AddWithValue("@password", account.Password);
				cmd.Parameters.AddWithValue("@tradeAddr", account.TradeAddress);
				cmd.Parameters.AddWithValue("@marketAddr", account.MarketAddress);
				cmd.Parameters.AddWithValue("@instrumentId", account.InstrumentId);
	
				cmd.Parameters.AddWithValue("@ownerPassword", account.OwnerPassword);
				cmd.Parameters.AddWithValue("@teamPassword", account.TeamPassword);
				cmd.Parameters.AddWithValue("@adminPassword", account.AdminPassword);
				cmd.Parameters.AddWithValue("@operatorPassword", account.OperatorPassword);

				cmd.Parameters.AddWithValue("@startMoney", account.StartMoney);
				cmd.Parameters.AddWithValue("@totalLossRatio", account.TotalLossRatio);
				cmd.Parameters.AddWithValue("@totalLossAmount", account.TotalLossAmount);
				cmd.Parameters.AddWithValue("@minimalMoney", account.MinimalQuanyi);

				cmd.Parameters.AddWithValue("@dayLossAmount", account.DayLossAmount);
				cmd.Parameters.AddWithValue("@dayLossTimes", account.DayLossTimes);
				cmd.Parameters.AddWithValue("@stopMinutes", account.StopMinutes);
				cmd.Parameters.AddWithValue("@stopTime", account.StopTime);


				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return null;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return account;
			}
		}

		public bool DeleteAccount(string id)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"delete from trade_account where id = @id";
				cmd.Parameters.AddWithValue("@id", id);
				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return false;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return true;
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public Trade GetTrade(string accountId, string instrumentId)
		{
			using (var conn = new SQLiteConnection(Global.connstr))
			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = "SELECT * from trade_risk where account_id = @accountId and instrument_id = @instrumentId";
				cmd.Parameters.AddWithValue("@accountId", accountId);
				cmd.Parameters.AddWithValue("@instrumentId", instrumentId);
				using (var reader = cmd.ExecuteReader())
				{
					Trade trade = new Trade();
					while (reader.Read())
					{
						trade.AccountId = reader.IsDBNull(reader.GetOrdinal("account_id")) ? null : reader.GetString(reader.GetOrdinal("account_id"));
						trade.InstrumentId = reader.IsDBNull(reader.GetOrdinal("instrument_id")) ? null : reader.GetString(reader.GetOrdinal("instrument_id"));
						trade.VolumeMultiple = reader.GetInt32(reader.GetOrdinal("volume_multiple"));
						trade.PriceTick = reader.GetDouble(reader.GetOrdinal("price_tick"));
						trade.OpenRatioByMoney = reader.GetDouble(reader.GetOrdinal("open_ratio_by_money"));
						trade.CloseRatioByMoney = reader.GetDouble(reader.GetOrdinal("close_ratio_by_money"));
						trade.CloseTodayRatioByMoney = reader.GetDouble(reader.GetOrdinal("closetoday_ratio_by_money"));
						trade.DefaultVolume = reader.GetInt32(reader.GetOrdinal("default_volume"));
						trade.BuyAddPoint = reader.GetInt32(reader.GetOrdinal("buy_add_point"));
						trade.BuyStopPoint = reader.GetInt32(reader.GetOrdinal("buy_stop_point"));
						trade.SellAddPoint = reader.GetInt32(reader.GetOrdinal("sell_add_point"));
						trade.SellStopPoint = reader.GetInt32(reader.GetOrdinal("sell_stop_point"));
					}
					return trade;
				}
			}
		}

		public Trade AddTrade(Trade param)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"insert into trade_risk (account_id, instrument_id, volume_multiple, price_tick
						, open_ratio_by_money, close_ratio_by_money, closetoday_ratio_by_money
						, default_volume, buy_stop_point, buy_add_point, sell_stop_point, sell_add_point
						) values (@accountId, @instrumentId, @volumeMultiple, @priceTick
						, @openRatioByMoney, @closeRatioByMoney, @closeTodayRatioByMoney
						, @defaultVolume, @buyStopPoint, @buyAddPoint, @sellStopPoint, @sellAddPoint)";
				cmd.Parameters.AddWithValue("@accountId", param.AccountId);
				cmd.Parameters.AddWithValue("@instrumentId", param.InstrumentId);
				cmd.Parameters.AddWithValue("@volumeMultiple", param.VolumeMultiple);
				cmd.Parameters.AddWithValue("@priceTick", param.PriceTick);
				cmd.Parameters.AddWithValue("@openRatioByMoney", param.OpenRatioByMoney);
				cmd.Parameters.AddWithValue("@closeRatioByMoney", param.CloseRatioByMoney);
				cmd.Parameters.AddWithValue("@closetodayRatioByMoney", param.CloseTodayRatioByMoney);
				cmd.Parameters.AddWithValue("@defaultVolume", param.DefaultVolume);
				cmd.Parameters.AddWithValue("@buyStopPoint", param.BuyStopPoint);
				cmd.Parameters.AddWithValue("@buyAddPoint", param.BuyAddPoint);
				cmd.Parameters.AddWithValue("@sellStopPoint", param.SellStopPoint);
				cmd.Parameters.AddWithValue("@sellAddPoint", param.SellAddPoint);

				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return null;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return param;
			}
		}

		public Trade UpdateTrade(Trade param)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"update trade_risk set volume_multiple = @volumeMultiple, price_tick = @priceTick
						, open_ratio_by_money = @openRatioByMoney, close_ratio_by_money =  @closeRatioByMoney, closetoday_ratio_by_money = @closetodayRatioByMoney
						, default_volume = @defaultVolume, buy_stop_point = @buyStopPoint, buy_add_point = @buyAddPoint, sell_stop_point = @sellStopPoint, sell_add_point = @sellAddPoint
						where account_id = @accountId and instrument_id = @instrumentId";
				cmd.Parameters.AddWithValue("@accountId", param.AccountId);
				cmd.Parameters.AddWithValue("@instrumentId", param.InstrumentId);
				cmd.Parameters.AddWithValue("@volumeMultiple", param.VolumeMultiple);
				cmd.Parameters.AddWithValue("@priceTick", param.PriceTick);
				cmd.Parameters.AddWithValue("@openRatioByMoney", param.OpenRatioByMoney);
				cmd.Parameters.AddWithValue("@closeRatioByMoney", param.CloseRatioByMoney);
				cmd.Parameters.AddWithValue("@closetodayRatioByMoney", param.CloseTodayRatioByMoney);
				cmd.Parameters.AddWithValue("@defaultVolume", param.DefaultVolume);
				cmd.Parameters.AddWithValue("@buyStopPoint", param.BuyStopPoint);
				cmd.Parameters.AddWithValue("@buyAddPoint", param.BuyAddPoint);
				cmd.Parameters.AddWithValue("@sellStopPoint", param.SellStopPoint);
				cmd.Parameters.AddWithValue("@sellAddPoint", param.SellAddPoint);

				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return null;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return param;
			}
		}

		public bool DeleteTrade(string accountId, string instrumentId)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"delete from trade_risk where account_id = @accountId and instrument_id = @instrumentId";
				cmd.Parameters.AddWithValue("@accountId", accountId);
				cmd.Parameters.AddWithValue("@instrumentId", instrumentId);
				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return false;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return true;
			}
		}

		public string GetPassword(string accountId, string type)
		{
			string password = null;
			using (var conn = new SQLiteConnection(Global.connstr))
			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = "SELECT " + type + "_password from trade_account where id = @id";
				cmd.Parameters.AddWithValue("@id", accountId);
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						password = reader.IsDBNull(0) ? null : reader.GetString(0);
					}
					
				}
			}
			return password;
		}

		public string UpdatePassword(string accountId, string type, string password)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"update trade_account set " + type + "_password = @password where id = @id";
				cmd.Parameters.AddWithValue("@id", accountId);
				cmd.Parameters.AddWithValue("@password", password);

				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return null;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return password;
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//		public DayRisk GetDayRisk(string accountId, string instrumentId)
//		{
//			using (var conn = new SQLiteConnection(Global.connstr))
//			using (var cmd = conn.CreateCommand())
//			{
//				conn.Open();
//				cmd.CommandText = "SELECT * from day_risk where account_id = @accountId and instrument_id = @instrumentId";
//				cmd.Parameters.AddWithValue("@accountId", accountId);
//				cmd.Parameters.AddWithValue("@instrumentId", instrumentId);
//				using (var reader = cmd.ExecuteReader())
//				{
//					DayRisk dayRisk = new DayRisk();
//					while (reader.Read())
//					{
//						dayRisk.AccountId = reader.IsDBNull(reader.GetOrdinal("account_id")) ? null : reader.GetString(reader.GetOrdinal("account_id"));
//						dayRisk.InstrumentId = reader.IsDBNull(reader.GetOrdinal("instrument_id")) ? null : reader.GetString(reader.GetOrdinal("instrument_id"));
//						dayRisk.DayLossAmount = reader.GetDouble(reader.GetOrdinal("day_loss_amount"));
//						dayRisk.DayLossTimes = reader.GetInt32(reader.GetOrdinal("day_loss_times"));
//						dayRisk.StopMinutes = reader.GetInt32(reader.GetOrdinal("stop_minutes"));
//						dayRisk.StopTimes = reader.IsDBNull(reader.GetOrdinal("stop_time")) ? null : reader.GetString(reader.GetOrdinal("stop_time"));
//					}
//					return dayRisk;
//				}
//			}
//		}

//		public DayRisk AddDayRisk(DayRisk param)
//		{
//			using (var conn = new SQLiteConnection(Global.connstr))

//			using (var cmd = conn.CreateCommand())
//			{
//				conn.Open();
//				cmd.CommandText = @"insert into day_risk (account_id, instrument_id,
//						day_loss_amount, day_loss_times, 
//						stop_minutes, stop_time
//						) values (@accountId, @instrumentId,
//						, @dayLossAmount, @dayLossTimes,
//						, @stopMinutes, @stopTime)";
//				cmd.Parameters.AddWithValue("@accountId", param.AccountId);
//				cmd.Parameters.AddWithValue("@instrumentId", param.InstrumentId);
//				cmd.Parameters.AddWithValue("@dayLossAmount", param.DayLossAmount);
//				cmd.Parameters.AddWithValue("@dayLossTimes", param.DayLossTimes);
//				cmd.Parameters.AddWithValue("@stopMinutes", param.StopMinutes);
//				cmd.Parameters.AddWithValue("@stopTime", param.StopTimes);

//				SQLiteTransaction trans = conn.BeginTransaction();
//				try
//				{
//					int retval = cmd.ExecuteNonQuery();
//					if (retval < 1)
//						return null;
//				}
//				catch (Exception ex)
//				{
//					trans.Rollback();
//				}
//				finally
//				{
//					trans.Commit();
//				}
//				return param;
//			}
//		}

//		public DayRisk UpdateDayRisk(DayRisk param)
//		{
//			using (var conn = new SQLiteConnection(Global.connstr))

//			using (var cmd = conn.CreateCommand())
//			{
//				conn.Open();
//				cmd.CommandText = @"update day_risk set day_loss_amount = @dayLossAmount, day_loss_times = @dayLossTimes, 
//						stop_minutes = @stopMinutes, stop_time = @stopTim
//						where account_id = @accountId and instrument_id = @instrumentId";
//				cmd.Parameters.AddWithValue("@accountId", param.AccountId);
//				cmd.Parameters.AddWithValue("@instrumentId", param.InstrumentId);
//				cmd.Parameters.AddWithValue("@dayLossAmount", param.DayLossAmount);
//				cmd.Parameters.AddWithValue("@dayLossTimes", param.DayLossTimes);
//				cmd.Parameters.AddWithValue("@stopMinutes", param.StopMinutes);
//				cmd.Parameters.AddWithValue("@stopTime", param.StopTimes);

//				SQLiteTransaction trans = conn.BeginTransaction();
//				try
//				{
//					int retval = cmd.ExecuteNonQuery();
//					if (retval < 1)
//						return null;
//				}
//				catch (Exception ex)
//				{
//					trans.Rollback();
//				}
//				finally
//				{
//					trans.Commit();
//				}
//				return param;
//			}
//		}

//		public bool DeleteDayRisk(string accountId, string instrumentId)
//		{
//			using (var conn = new SQLiteConnection(Global.connstr))

//			using (var cmd = conn.CreateCommand())
//			{
//				conn.Open();
//				cmd.CommandText = @"delete from day_risk where account_id = @accountId and instrument_id = @instrumentId";
//				cmd.Parameters.AddWithValue("@accountId", accountId);
//				cmd.Parameters.AddWithValue("@instrumentId", instrumentId);
//				SQLiteTransaction trans = conn.BeginTransaction();
//				try
//				{
//					int retval = cmd.ExecuteNonQuery();
//					if (retval < 1)
//						return false;
//				}
//				catch (Exception ex)
//				{
//					trans.Rollback();
//				}
//				finally
//				{
//					trans.Commit();
//				}
//				return true;
//			}
//		}


		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public WaveRisk GetWaveRisk(string accountId, string instrumentId)
		{
			using (var conn = new SQLiteConnection(Global.connstr))
			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = "SELECT * from wave_strategy where account_id = @accountId and instrument_id = @instrumentId";
				cmd.Parameters.AddWithValue("@accountId", accountId);
				cmd.Parameters.AddWithValue("@instrumentId", instrumentId);
				using (var reader = cmd.ExecuteReader())
				{
					WaveRisk param = new WaveRisk();
					while (reader.Read())
					{
						param.AccountId = reader.IsDBNull(reader.GetOrdinal("account_id")) ? null : reader.GetString(reader.GetOrdinal("account_id"));
						param.InstrumentId = reader.IsDBNull(reader.GetOrdinal("instrument_id")) ? null : reader.GetString(reader.GetOrdinal("instrument_id"));
						param.Spread = reader.GetDouble(reader.GetOrdinal("spread"));
						param.SmallEnable= reader.GetInt32(reader.GetOrdinal("small_enable"));
						param.SmallRepeat = reader.GetInt32(reader.GetOrdinal("small_repeat"));
						
						param.SmallFullAmount = reader.GetDouble(reader.GetOrdinal("small_full_amount"));
						param.SmallFullTimes = reader.GetInt32(reader.GetOrdinal("small_full_times"));
						param.SmallPartialBuyAmount = reader.GetDouble(reader.GetOrdinal("small_partial_buy_amount"));
						param.SmallPartialBuyTimes = reader.GetInt32(reader.GetOrdinal("small_partial_buy_times"));
						param.SmallPartialSellAmount = reader.GetDouble(reader.GetOrdinal("small_partial_sell_amount"));
						param.SmallPartialSellTimes = reader.GetInt32(reader.GetOrdinal("small_partial_sell_times"));

						param.SmallUnlockCase1Ratio1 = reader.GetDouble(reader.GetOrdinal("small_unlock_case1_ratio1"));
						param.SmallUnlockCase2Ratio2 = reader.GetDouble(reader.GetOrdinal("small_unlock_case2_ratio2"));
						param.SmallUnlockCase2Times = reader.GetInt32(reader.GetOrdinal("small_unlock_case2_times"));

						param.SmallUnlockCase3NRecord = reader.GetInt32(reader.GetOrdinal("small_unlock_case3_nrecord"));
						param.SmallUnlockCase3DiffValue = reader.GetDouble(reader.GetOrdinal("small_unlock_case3_diffValue"));

						param.BigEnable = reader.GetInt32(reader.GetOrdinal("big_enable"));
						param.BigRepeat = reader.GetInt32(reader.GetOrdinal("big_repeat"));

						param.BigFullAmount = reader.GetDouble(reader.GetOrdinal("big_full_amount"));
						param.BigFullTimes = reader.GetInt32(reader.GetOrdinal("big_full_times"));
						param.BigPartialBuyAmount = reader.GetDouble(reader.GetOrdinal("big_partial_buy_amount"));
						param.BigPartialBuyTimes = reader.GetInt32(reader.GetOrdinal("big_partial_buy_times"));
						param.BigPartialSellAmount = reader.GetDouble(reader.GetOrdinal("big_partial_sell_amount"));
						param.BigPartialSellTimes = reader.GetInt32(reader.GetOrdinal("big_partial_sell_times"));

						param.BigUnlockCase1DiffPrice = reader.GetDouble(reader.GetOrdinal("big_unlock_case1_diffprice"));
						param.BigUnlockCase2DiffPrice = reader.GetDouble(reader.GetOrdinal("big_unlock_case2_diffprice"));
						param.BigUnlockCase2Multiple = reader.GetInt32(reader.GetOrdinal("big_unlock_case2_multiple"));
					}
					return param;
				}
			}
		}
		
		public WaveRisk AddWaveRisk(WaveRisk param)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"insert into wave_strategy (account_id, instrument_id, spread,
						small_enable, small_repeat, small_full_amount, small_full_times,
						small_partial_buy_amount, small_partial_buy_times,
						small_partial_sell_amount, small_partial_sell_times,
						small_unlock_case1_ratio1, small_unlock_case2_ratio2, small_unlock_case2_times,
						small_unlock_case3_nrecord, small_unlock_case3_diffValue,
						big_enable, big_repeat,
						big_full_amount, big_full_times,
						big_partial_buy_amount, big_partial_buy_times,
						big_partial_sell_amount, big_partial_sell_times,
						big_unlock_case1_diffprice, big_unlock_case2_diffprice, big_unlock_case2_multiple
						) values (@AccountId, @InstrumentId, @Spread,
						@SmallEnable, @SmallRepeat, @SmallFullAmount, @SmallFullTimes,
						@SmallPartialBuyAmount, @SmallPartialBuyTimes,
						@SmallPartialSellAmount, @SmallPartialSellTimes,
						@SmallUnlockCase1Ratio1, @SmallUnlockCase2Ratio2, @SmallUnlockCase2Times,
						@SmallUnlockCase3NRecord, @SmallUnlockCase3DiffValue,
						@BigEnable, @BigRepeat,
						@BigFullAmount, @BigFullTimes,
						@BigPartialBuyAmount, @BigPartialBuyTimes,
						@BigPartialSellAmount, @BigPartialSellTimes,
						@BigUnlockCase1DiffPrice, @BigUnlockCase2DiffPrice, @BigUnlockCase2Multiple)";

				cmd.Parameters.AddWithValue("@AccountId", param.AccountId);
				cmd.Parameters.AddWithValue("@InstrumentId", param.InstrumentId);
				cmd.Parameters.AddWithValue("@Spread", param.Spread);

				cmd.Parameters.AddWithValue("@SmallEnable", param.SmallEnable);
				cmd.Parameters.AddWithValue("@SmallRepeat", param.SmallRepeat);
				cmd.Parameters.AddWithValue("@SmallFullAmount", param.SmallFullAmount);
				cmd.Parameters.AddWithValue("@SmallFullTimes", param.SmallFullTimes);
				cmd.Parameters.AddWithValue("@SmallPartialBuyAmount", param.SmallPartialBuyAmount);
				cmd.Parameters.AddWithValue("@SmallPartialBuyTimes", param.SmallPartialBuyTimes);
				cmd.Parameters.AddWithValue("@SmallPartialSellAmount", param.SmallPartialSellAmount);
				cmd.Parameters.AddWithValue("@SmallPartialSellTimes", param.SmallPartialSellTimes);

				cmd.Parameters.AddWithValue("@SmallUnlockCase1Ratio1", param.SmallUnlockCase1Ratio1);
				cmd.Parameters.AddWithValue("@SmallUnlockCase2Ratio2", param.SmallUnlockCase2Ratio2);
				cmd.Parameters.AddWithValue("@SmallUnlockCase2Times", param.SmallUnlockCase2Times);
				cmd.Parameters.AddWithValue("@SmallUnlockCase3DiffValue", param.SmallUnlockCase3DiffValue);
				cmd.Parameters.AddWithValue("@SmallUnlockCase3NRecord", param.SmallUnlockCase3NRecord);

				cmd.Parameters.AddWithValue("@BigEnable", param.BigEnable);
				cmd.Parameters.AddWithValue("@BigRepeat", param.BigRepeat);
				cmd.Parameters.AddWithValue("@BigFullAmount", param.BigFullAmount);
				cmd.Parameters.AddWithValue("@BigFullTimes", param.BigFullTimes);
				cmd.Parameters.AddWithValue("@BigPartialBuyAmount", param.BigPartialBuyAmount);
				cmd.Parameters.AddWithValue("@BigPartialBuyTimes", param.BigPartialBuyTimes);
				cmd.Parameters.AddWithValue("@BigPartialSellAmount", param.BigPartialSellAmount);
				cmd.Parameters.AddWithValue("@BigPartialSellTimes", param.BigPartialSellTimes);

				cmd.Parameters.AddWithValue("@BigUnlockCase1DiffPrice", param.BigUnlockCase1DiffPrice);
				cmd.Parameters.AddWithValue("@BigUnlockCase2DiffPrice", param.BigUnlockCase2DiffPrice);
				cmd.Parameters.AddWithValue("@BigUnlockCase2Multiple", param.BigUnlockCase2Multiple);

				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return null;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return param;
			}
		}

		public WaveRisk UpdateWaveRisk(WaveRisk param)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"update wave_strategy set spread = @Spread,
						small_enable = @SmallEnable, small_repeat = @SmallRepeat,
						small_full_amount = @SmallFullAmount, small_full_times = @SmallFullTimes,
						small_partial_buy_amount = @SmallPartialBuyAmount, small_partial_buy_times = @SmallPartialBuyTimes,
						small_partial_sell_amount = @SmallPartialSellAmount, small_partial_sell_times = @SmallPartialSellTimes,
						small_unlock_case1_ratio1 = @SmallUnlockCase1Ratio1, small_unlock_case2_ratio2 = @SmallUnlockCase2Ratio2, small_unlock_case2_times = @SmallUnlockCase2Times,
						small_unlock_case3_nrecord = @SmallUnlockCase3NRecord, small_unlock_case3_diffValue = @SmallUnlockCase3DiffValue,
						big_enable = @BigEnable, big_repeat = @BigRepeat,
						big_full_amount = @BigFullAmount, big_full_times = @BigFullTimes,
						big_partial_buy_amount = @BigPartialBuyAmount, big_partial_buy_times = @BigPartialBuyTimes,
						big_partial_sell_amount = @BigPartialSellAmount ,big_partial_sell_times = @BigPartialSellTimes,
						big_unlock_case1_diffprice = @BigUnlockCase1DiffPrice, big_unlock_case2_diffprice = @BigUnlockCase2DiffPrice, big_unlock_case2_multiple = @BigUnlockCase2Multiple
						where account_id = @AccountId and instrument_id = @InstrumentId";
				cmd.Parameters.AddWithValue("@AccountId", param.AccountId);
				cmd.Parameters.AddWithValue("@InstrumentId", param.InstrumentId);
				cmd.Parameters.AddWithValue("@Spread", param.Spread);
				cmd.Parameters.AddWithValue("@SmallEnable", param.SmallEnable);
				cmd.Parameters.AddWithValue("@SmallRepeat", param.SmallRepeat);
				cmd.Parameters.AddWithValue("@SmallFullAmount", param.SmallFullAmount);
				cmd.Parameters.AddWithValue("@SmallFullTimes", param.SmallFullTimes);
				cmd.Parameters.AddWithValue("@SmallPartialBuyAmount", param.SmallPartialBuyAmount);
				cmd.Parameters.AddWithValue("@SmallPartialBuyTimes", param.SmallPartialBuyTimes);
				cmd.Parameters.AddWithValue("@SmallPartialSellAmount", param.SmallPartialSellAmount);
				cmd.Parameters.AddWithValue("@SmallPartialSellTimes", param.SmallPartialSellTimes);

				cmd.Parameters.AddWithValue("@SmallUnlockCase1Ratio1", param.SmallUnlockCase1Ratio1);
				cmd.Parameters.AddWithValue("@SmallUnlockCase2Ratio2", param.SmallUnlockCase2Ratio2);
				cmd.Parameters.AddWithValue("@SmallUnlockCase2Times", param.SmallUnlockCase2Times);
				cmd.Parameters.AddWithValue("@SmallUnlockCase3DiffValue", param.SmallUnlockCase3DiffValue);
				cmd.Parameters.AddWithValue("@SmallUnlockCase3NRecord", param.SmallUnlockCase3NRecord);

				cmd.Parameters.AddWithValue("@BigEnable", param.BigEnable);
				cmd.Parameters.AddWithValue("@BigRepeat", param.BigRepeat);
				cmd.Parameters.AddWithValue("@BigFullAmount", param.BigFullAmount);
				cmd.Parameters.AddWithValue("@BigFullTimes", param.BigFullTimes);
				cmd.Parameters.AddWithValue("@BigPartialBuyAmount", param.BigPartialBuyAmount);
				cmd.Parameters.AddWithValue("@BigPartialBuyTimes", param.BigPartialBuyTimes);
				cmd.Parameters.AddWithValue("@BigPartialSellAmount", param.BigPartialSellAmount);
				cmd.Parameters.AddWithValue("@BigPartialSellTimes", param.BigPartialSellTimes);

				cmd.Parameters.AddWithValue("@BigUnlockCase1DiffPrice", param.BigUnlockCase1DiffPrice);
				cmd.Parameters.AddWithValue("@BigUnlockCase2DiffPrice", param.BigUnlockCase2DiffPrice);
				cmd.Parameters.AddWithValue("@BigUnlockCase2Multiple", param.BigUnlockCase2Multiple);

				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return null;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return param;
			}
		}

		public bool DeleteWaveRisk(string accountId, string instrumentId)
		{
			using (var conn = new SQLiteConnection(Global.connstr))

			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = @"delete from wave_risk where account_id = @accountId and instrument_id = @instrumentId";
				cmd.Parameters.AddWithValue("@accountId", accountId);
				cmd.Parameters.AddWithValue("@instrumentId", instrumentId);
				SQLiteTransaction trans = conn.BeginTransaction();
				try
				{
					int retval = cmd.ExecuteNonQuery();
					if (retval < 1)
						return false;
				}
				catch (Exception ex)
				{
					trans.Rollback();
				}
				finally
				{
					trans.Commit();
				}
				return true;
			}
		}
	}
}
