CREATE DATABASE CoffeeHouse
GO

USE CoffeeHouse
GO



CREATE TABLE FOODCATEGORY
(
	FoodCategoryID VARCHAR(10) PRIMARY KEY,
	Name NVARCHAR(50)
)
GO

CREATE TABLE FOOD
(
	FoodID CHAR(5) PRIMARY KEY,
	Name NVARCHAR(25) NOT NULL,
	Price INT NOT NULL,
	IDFoodCategory VARCHAR(10)

	FOREIGN KEY (IDFoodCategory) REFERENCES dbo.FOODCATEGORY(FoodCategoryID) 
)
GO

CREATE TABLE CTABLE
(
	TableID VARCHAR(3) PRIMARY KEY,
	IsAvailable BIT DEFAULT 1 NOT NULL
)
GO

CREATE TABLE ACCOUNT
(
	UserName VARCHAR(20) PRIMARY KEY,
	UserPassword VARCHAR(16) NOT NULL,
	DisplayName NVARCHAR(30),
	IsManager BIT DEFAULT 0 NOT NULL
)
GO

CREATE TABLE BILL
(
	ID INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE NOT NULL DEFAULT GETDATE(),
	TableID VARCHAR(3) NOT NULL,
	IsPaid BIT DEFAULT 0 NOT NULL

	FOREIGN KEY (TableID) REFERENCES dbo.CTABLE(TableID)
)
GO

CREATE TABLE BILLINFO
(
	ID INT IDENTITY PRIMARY KEY,
	BillID INT NOT NULL,
	FoodID CHAR(5) NOT NULL,
	FoodCount INT NOT NULL DEFAULT 0

	FOREIGN KEY (BillID) REFERENCES dbo.BILL(ID),
	FOREIGN KEY (FoodID) REFERENCES dbo.FOOD(FoodID)
)
GO 

INSERT dbo.ACCOUNT
        ( UserName ,
          UserPassword ,
          DisplayName ,
          IsManager
        )
VALUES  ( 'nghia1' , -- UserName - varchar(20)
          'nghia' , -- UserPassword - varchar(16)
          N'Trọng Nghĩa' , -- DisplayName - nvarchar(30)
          1  -- IsManager - bit
        )

INSERT dbo.ACCOUNT
        ( UserName ,
          UserPassword ,
          DisplayName ,
          IsManager
        )
VALUES  ( 'nghia2' , -- UserName - varchar(20)
          'nghia' , -- UserPassword - varchar(16)
          N'Trọng Nghĩa 2' , -- DisplayName - nvarchar(30)
          0  -- IsManager - bit
        )


INSERT dbo.ACCOUNT
        ( UserName ,
          UserPassword ,
          DisplayName ,
          IsManager
        )
VALUES  ( 'nghia3' , -- UserName - varchar(20)
          'nghia' , -- UserPassword - varchar(16)
          N'Trọng Nghĩa 3' , -- DisplayName - nvarchar(30)
          0  -- IsManager - bit
        )
GO
      
	  
Select UserName, DisplayName, IsManager from dbo.ACCOUNT  