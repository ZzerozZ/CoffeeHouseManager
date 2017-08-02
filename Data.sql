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
      
	  
CREATE PROC USP_GetUserByUserName
@UserName VARCHAR(20)
AS
BEGIN
	SELECT * FROM dbo.ACCOUNT WHERE dbo.ACCOUNT.UserName = @UserName
END
GO


EXEC dbo.USP_GetUserByUserName @UserName = 'nghia1' -- varchar(20)

INSERT dbo.CTABLE
        ( TableID, IsAvailable )
VALUES  ( '101', -- TableID - varchar(3)
          0)
INSERT dbo.CTABLE
        ( TableID, IsAvailable )
VALUES  ( '102', -- TableID - varchar(3)
          0)
INSERT dbo.CTABLE
        ( TableID, IsAvailable )
VALUES  ( '201', -- TableID - varchar(3)
          1  -- IsAvailable - bit
          )
INSERT dbo.CTABLE
        ( TableID, IsAvailable )
VALUES  ( '103', -- TableID - varchar(3)
          1)
INSERT dbo.CTABLE
        ( TableID, IsAvailable )
VALUES  ( '301', -- TableID - varchar(3)
          0)
INSERT dbo.CTABLE
        ( TableID, IsAvailable )
VALUES  ( '202', -- TableID - varchar(3)
          1  -- IsAvailable - bit
          )




INSERT dbo.FOODCATEGORY
        ( FoodCategoryID, Name )
VALUES  ( 'HAS', -- FoodCategoryID - varchar(10)
          N'Hải sản'  -- Name - nvarchar(50)
          )

INSERT dbo.FOODCATEGORY
        ( FoodCategoryID, Name )
VALUES  ( 'DUO', -- FoodCategoryID - varchar(10)
          N'Đồ uống'  -- Name - nvarchar(50)
          )

INSERT dbo.FOODCATEGORY
        ( FoodCategoryID, Name )
VALUES  ( 'THI', -- FoodCategoryID - varchar(10)
          N'Thịt'  -- Name - nvarchar(50)
          )



INSERT dbo.FOOD
        ( FoodID, Name, Price, IDFoodCategory )
VALUES  ( 'HEL', -- FoodID - char(5)
          N'Heo luộc', -- Name - nvarchar(25)
          20000, -- Price - int
          'THI'  -- IDFoodCategory - varchar(10)
          )

INSERT dbo.FOOD
        ( FoodID, Name, Price, IDFoodCategory )
VALUES  ( 'HHA', -- FoodID - char(5)
          N'Hàu hấp', -- Name - nvarchar(25)
          100000, -- Price - int
          'HAS'  -- IDFoodCategory - varchar(10)
          )
INSERT dbo.FOOD
        ( FoodID, Name, Price, IDFoodCategory )
VALUES  ( 'Coca', -- FoodID - char(5)
          N'Coca Cola', -- Name - nvarchar(25)
          10000, -- Price - int
          'DUO'  -- IDFoodCategory - varchar(10)
          )


SELECT IsManager FROM dbo.ACCOUNT WHERE UserName = 'nghia2'

SELECT * FROM dbo.CTABLE


DECLARE @i INT = 302

WHILE @i < 310
BEGIN
	INSERT dbo.CTABLE
	        ( TableID, IsAvailable )
	VALUES  ( CAST(@i AS VARCHAR(3)), -- TableID - varchar(3)
	          0  -- IsAvailable - bit
	          )

	SET @i = @i + 1
END 

INSERT dbo.FOOD
        ( FoodID, Name, Price, IDFoodCategory )
VALUES  ( '', -- FoodID - char(5)
          N'', -- Name - nvarchar(25)
          0, -- Price - int
          ''  -- IDFoodCategory - varchar(10)
          )

SELECT FoodID, Name, Price FROM dbo.FOOD WHERE IDFoodCategory = 