
create table StockExchange (
	StockExchangeId int primary key,
	Code nvarchar(10) not null,
	Name nvarchar(100) not null,
)

create table Stock (
	StockId int primary key,
	StockExchangeId int,
	Code nvarchar(10) not null,
	Name nvarchar(100) not null,
	Price decimal(18, 2) not null,
)

create table UserHistory (
    UserHistoryId int identity(1,1) primary key,
    UserId int not null,
    EntityId int not null,
    EntityTypeId int not null,
    [Date] datetime not null default getutcdate()
    foreign key (EntityTypeId) references EntityType(EntityTypeId)
);
create table EntityType (
	EntityTypeId int  identity(1,1) primary key,
	Code nvarchar(50) not null,
	Name nvarchar(50) not null
)

-- Insert data into StockExchange
insert into StockExchange (StockExchangeId, Code, Name) values
(1, 'LSE', 'London Stock Exchange'),
(2, 'NYSE', 'New York Stock Exchange'),
(3, 'NASDAQ', 'Nasdaq');

-- Insert data into Stock
insert into Stock (StockId, StockExchangeId, Code, Name, Price) values
-- For London Stock Exchange (StockExchangeId = 1)
(1, 1, 'CRDA', 'CRODA INTERNATIONAL PLC', 4807.00),
(2, 1, 'GSK', 'GSK PLC', 1574.80),
(3, 1, 'ANTO', 'ANTOFAGASTA PLC', 1746.00),
(4, 1, 'FLTR', 'FLUTTER ENTERTAINMENT PLC', 16340.00),
(5, 1, 'BDEV', 'BARRATT DEVELOPMENTS PLC', 542.60),

-- For New York Stock Exchange (StockExchangeId = 2)
(6, 2, 'AHT', 'Ashford Hospitality Trust', 1.72),
(7, 2, 'KUKE', 'Kuke Music Holding Ltd', 1.20),
(8, 2, 'ASH', 'Ashland Inc.', 93.42),
(9, 2, 'NMR', 'Nomura Holdings Inc.', 5.84),
(10, 2, 'LC', 'LendingClub Corp', 9.71),

-- For Nasdaq (StockExchangeId = 3)
(11, 3, 'AMD', 'Advanced Micro Devices, Inc.', 164.21),
(12, 3, 'TSLA', 'Tesla, Inc.', 190.35),
(13, 3, 'SOFI', 'SoFi Technologies, Inc.', 8.24),
(14, 3, 'PARA', 'Paramount Global', 14.92),
(15, 3, 'GOOGL', 'Alphabet Inc.', 141.91);

-- Insert data into EntityType
insert into EntityType (Code, Name) values
('STOCK', 'Stock'),
('STOCK_EXCHANGE', 'Stock exchange');

