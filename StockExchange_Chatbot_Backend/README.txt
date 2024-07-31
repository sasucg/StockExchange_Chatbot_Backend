For this project I am ussing the following technology stack: 
-> .NET Core 8
-> Angular 18.1.2
-> SQL Server
-> Node 20.16.0
-> EntityFrameworkCore 7.0.5

I created tables in a local database & I populated according to JSON
-> StockEnginge_Chatbot_SQLScript.sql

Implementing REST Apis on Chatbot Controller: 
-> GetStockExchange 		-> http://localhost:5174/api/Chatbot/stockExchange 		// get all stockExchanges
-> GetStocksByStockExchangeId 	-> http://localhost:5174/api/Chatbot/stockExchange/1/stocks 	// get stocks for a stockExchange
-> GetStockById			-> http://localhost:5174/api/Chatbot/stockExchange/stocks/1		//get stock by id
-> SaveUserActivity		-> http://localhost:5174/api/Chatbot/stockExchange 		// save user activity
				->> SET HTTP POST
				->> provide valid userId, entityId, entityTypeId, 
				->> setcontent-type: application/json

Tables & Entities: 
-> StockExchange
-> Stock
-> EntityType	-> used as a dictionary of entities: Stock / StockExchange
-> UserHistory	-> Used to store user activity navigating in chatbot