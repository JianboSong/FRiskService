-- 账号
CREATE TABLE trade_account (
	id TEXT primary key,
	name TEXT,
	exchange_id TEXT,
	broker_id TEXT,
	user_id TEXT,
	password TEXT,
	trade_addr TEXT,
	market_addr TEXT,
	instrument_id TEXT,

	owner_password TEXT,	-- 金主密码
	team_password TEXT,		-- 投资团队密码
	admin_password TEXT,	-- 风控管理员密码
	operator_password TEXT,	-- 交易操作员密码

	-- 账号总风险
	start_money REAL,		-- 起始资金
	total_loss_ratio REAL,	-- 亏损比例
	total_loss_amount REAL,	-- 亏损金额
	minimal_money REAL,		-- 最低动态权益

	-- 日风险
	day_loss_amount REAL,	--日最大亏损金额
	day_loss_times INT,		--日最大亏损次数
	stop_minutes INT,		--开盘前多少分钟自动止损
	stop_time TEXT			--收盘时间
);

---- 交易风险
CREATE TABLE trade_risk (
	account_id TEXT,
	instrument_id TEXT,
	volume_multiple INT,
	price_tick REAL,
	open_ratio_by_money REAL,			-- 开仓手续费率
	open_ratio_by_volume REAL,			-- 开仓手续费
	close_ratio_by_money REAL,			-- 平仓手续费率
	close_ratio_by_volume REAL,			-- 平仓手续费
	closetoday_ratio_by_money REAL,		-- 平今手续费率
	closetoday_ratio_by_volume REAL,	-- 平今手续费
	default_volume INT,					-- 默认手数
	buy_stop_point INT,					-- 多单止损点
	buy_add_point INT,					-- 多单追价点
	sell_stop_point INT,				-- 空单止损点
	sell_add_point INT,					-- 空单追价点
	constraint pk_t1 primary key (account_id,instrument_id)
);

CREATE TABLE wave_strategy (
	account_id TEXT,
	instrument_id TEXT,

	spread REAL,						-- 波动判定值 (实际值)

	small_enable INT,					-- 启用小波控制
	small_repeat INT,					-- 连续进入次数
	small_full_amount REAL,				-- 小波总金额
	small_full_times INT,				-- 小波总次数
	small_partial_buy_amount REAL,		-- 多单部分总金额
	small_partial_buy_times INT,		-- 多单部分总次数
	small_partial_sell_amount REAL,		-- 空单部分总金额
	small_partial_sell_times INT,		-- 空单部分总次数

	small_unlock_case1_ratio1 REAL,		-- 现波大于前波比例
	small_unlock_case2_ratio2 REAL,		-- 现波小于前波比例
	small_unlock_case2_times INT,		-- 现波小于前波次数

	small_unlock_case3_nrecord INT,		-- 连续 n 根五分钟线最大差值小于
	small_unlock_case3_diffValue REAL,

	big_enable INT,						-- 启用大波控制
	big_repeat INT,						-- 连续进入次数
	big_full_amount INT,				-- 大波总金额
	big_full_times INT,					-- 大波总次数

	big_partial_buy_amount REAL,
	big_partial_buy_times INT,
	big_partial_sell_amount REAL,
	big_partial_sell_times INT,

	big_unlock_case1_diffprice REAL,	-- |最新市场成交价 - 最近成交区域均价| >

	big_unlock_case2_multiple INT,		-- 某5分钟线波动大于实际涨跌绝对值 n 倍, 实际涨跌值大于 m
	big_unlock_case2_diffprice REAL,

	constraint pk_t2 primary key (account_id,instrument_id)
);