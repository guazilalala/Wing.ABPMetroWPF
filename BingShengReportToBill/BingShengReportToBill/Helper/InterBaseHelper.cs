using BingShengReportToBill.Model;
using Borland.Data;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace BingShengReportToBill.Helper
{
	public class InterBaseHelper
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private string _connectionString;
		public readonly object _obj = new object();

		public InterBaseHelper(string path, string UserName, string Password, string databaseIp)
		{
			_connectionString = "DriverName=Interbase;Database=" + databaseIp + ":" + path + ";RoleName=RoleName;User_Name=" + UserName + ";Password=" + Password + ";SQLDialect=3;MetaDataAssemblyLoader=Borland.Data.TDBXInterbaseMetaDataCommandFactory,Borland.Data.DbxReadOnlyMetaData,Version=11.0.5000.0,Culture=neutral,PublicKeyToken=91d62ebb5b0d1b1b;GetDriverFunc=getSQLDriverINTERBASE;LibraryName=dbxint30.dll;VendorLib=GDS32.DLL";
		}
		public int ExecuteNonQuery(string sqlStr)
		{
			lock (_obj)
			{
				using (TAdoDbxConnection conn = new TAdoDbxConnection(_connectionString))
				{
					int NonQuery = 0;
					TAdoDbxCommand cmd = new TAdoDbxCommand();
					cmd.Connection = conn;
					cmd.CommandText = sqlStr;
					try
					{
						cmd.Connection.Open();
						NonQuery = cmd.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						if (ex.Message != "message length error (encountered 0, expected 8)" && ex.Message != "message length error (encountered 0, expected 12)")
						{
							_logger.Error(ex, "执行SQL错误:");
						}
						return NonQuery;
					}
					finally
					{
						cmd.Connection.Close();
						cmd.Connection.Dispose();
						cmd.Dispose();
					}
					return NonQuery;
				}

			}
		}

		public object ExecuteScalar(string sqlStr)
		{
			lock (_obj)
			{
				using (TAdoDbxConnection conn = new TAdoDbxConnection(_connectionString))
				{
					TAdoDbxCommand cmd = new TAdoDbxCommand();
					cmd.Connection = conn;
					cmd.CommandText = sqlStr;
					try
					{
						cmd.Connection.Open();
						return cmd.ExecuteScalar();
					}
					catch (Exception ex)
					{
						_logger.Error(ex, "执行SQL错误:");
						return null;
					}
					finally
					{
						cmd.Connection.Close();
						cmd.Connection.Dispose();
						cmd.Dispose();
					}
				}
			}
		}

		public DataTable GetData(string sqlStr)
		{
			lock (_obj)
			{
				using (TAdoDbxConnection conn = new TAdoDbxConnection(_connectionString))
				{
					DataSet ds = new DataSet();
					TAdoDbxCommand cmd = new TAdoDbxCommand();
					cmd.Connection = conn;
					cmd.CommandText = sqlStr;

					try
					{
						cmd.Connection.Open();
						DbDataReader myreader = cmd.ExecuteReader();
						DataTable dt = new DataTable();
						if (myreader.HasRows)
						{
							if (!Convert.IsDBNull(myreader))
							{
								dt.Load(myreader);
								ds.Tables.Add(dt);
								ds.Load(myreader, LoadOption.PreserveChanges, ds.Tables[0]);
							}
							else
							{
								ds.Tables.Add(dt);
							}
						}
						else
						{
							ds.Tables.Add(dt);
						}
						myreader.Close();
						myreader.Dispose();

					}
					catch (Exception ex)
					{
						_logger.Error(ex, "执行SQL错误:");
					}
					finally
					{
						cmd.Connection.Close();
						cmd.Connection.Dispose();
						cmd.Dispose();
					}

					if (ds.Tables.Count > 0)
					{
						return ds.Tables[0];
					}
					else
					{
						return new DataTable();
					}
				}

			}
		}

		public List<Folio> ReadFolioData(string queryString)
		{
			List<Folio> folios = new List<Folio>();
			try
			{
				using (TAdoDbxConnection connection = new TAdoDbxConnection(_connectionString))
				{
					using (TAdoDbxCommand cmd = new TAdoDbxCommand())
					{
						cmd.Connection = connection;
						cmd.CommandText = queryString;
						cmd.Connection.Open();

						using (var reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								folios.Add(new Folio
								{
									Serial = reader["SERIAL"].ToString(),
									StartTim = Convert.ToDateTime(reader["STARTTIM"]),
									Amt = reader["AMT"].ToString(),
									UploadSuccess = true
								});
							}
						}
					}
				}

			}
			catch (Exception)
			{
			}
			return folios;
		}

		public List<FolioPayment> ReadFolioPaymentData(string queryString)
		{
			List<FolioPayment> folioPayments = new List<FolioPayment>();
			try
			{
				using (TAdoDbxConnection connection = new TAdoDbxConnection(_connectionString))
				{
					using (TAdoDbxCommand cmd = new TAdoDbxCommand())
					{
						cmd.Connection = connection;
						cmd.CommandText = queryString;
						cmd.Connection.Open();

						using (var reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								folioPayments.Add(new FolioPayment
								{
									PaymentDes = reader["PAYMENTDES"].ToString(),
									Amt = Convert.ToDouble(reader["AMT"])
								});
							}
						}
					}
				}

			}
			catch (Exception)
			{
			}
			return folioPayments;
		}
		public List<Ordr> ReadOrdrData(string queryString)
		{
			List<Ordr> ordrs = new List<Ordr>();
			try
			{
				using (TAdoDbxConnection connection = new TAdoDbxConnection(_connectionString))
				{
					using (TAdoDbxCommand cmd = new TAdoDbxCommand())
					{
						cmd.Connection = connection;
						cmd.CommandText = queryString;
						cmd.Connection.Open();

						using (var reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								ordrs.Add(new Ordr
								{
									Cnt = Convert.ToInt32(reader["CNT"]),
									Amt = Convert.ToDouble(reader["AMT"]),
									Disc = Convert.ToDouble(reader["DISC"]),
								});
							}
						}
					}
				}

			}
			catch (Exception)
			{
			}
			return ordrs;
		}

		/// <summary>
		/// 测试数据库是否连接成功
		/// </summary>
		/// <returns></returns>
		public bool TestConnect()
		{
			lock (_obj)
			{
				try
				{
					TAdoDbxCommand cmd = new TAdoDbxCommand();
					cmd.Connection = new TAdoDbxConnection(_connectionString);
					cmd.Connection.Open();
					cmd.Connection.Close();
					return true;
				}
				catch (Exception ex)
				{
					_logger.Error(ex, "执行SQL错误:");
					return false;
				}

			}
		}
	}
}
