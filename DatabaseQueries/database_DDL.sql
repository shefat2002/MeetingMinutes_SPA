CREATE DATABASE MeetingMinutesDB;
GO

USE MeetingMinutesDB;
GO


CREATE TABLE Corporate_Customer_Tbl (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
);
GO

CREATE TABLE Individual_Customer_Tbl (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
);
GO

CREATE TABLE Products_Service_Tbl (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Unit NVARCHAR(20) NOT NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
);
GO

CREATE TABLE Meeting_Minutes_Master_Tbl (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerType NVARCHAR(10) NOT NULL,
    CustomerId INT NULL,
    MeetingDate DATE NOT NULL,
    MeetingTime TIME NOT NULL,
    MeetingPlace NVARCHAR(200) NOT NULL,
    MeetingAgenda NVARCHAR(MAX) NOT NULL,
	MeetingDiscussion nvarchar(MAX) NOT NULL,
    MeetingDecision NVARCHAR(MAX) NOT NULL,
    ClientAttendees NVARCHAR(MAX) NOT NULL,
    HostAttendees NVARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
);
GO

CREATE TABLE Meeting_Minutes_Details_Tbl (
    Id INT PRIMARY KEY IDENTITY(1,1),
    MasterId INT NOT NULL,
    ProductServiceId INT NOT NULL,
    Quantity INT NOT NULL,
    Unit NVARCHAR(20) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT FK_MeetingMinutesMaster FOREIGN KEY (MasterId) 
        REFERENCES Meeting_Minutes_Master_Tbl(Id)
        ON DELETE CASCADE,
    CONSTRAINT FK_ProductService FOREIGN KEY (ProductServiceId) 
        REFERENCES Products_Service_Tbl(Id)
);
GO

CREATE PROCEDURE Meeting_Minutes_Master_Save_SP
    @CustomerType NVARCHAR(10),
    @CustomerId INT = NULL,
    @MeetingDate DATE,
    @MeetingTime TIME,
    @MeetingPlace NVARCHAR(200),
    @MeetingAgenda NVARCHAR(MAX),
    @MeetingDecision NVARCHAR(MAX),
    @ClientAttendees NVARCHAR(MAX),
    @HostAttendees NVARCHAR(MAX),
    @MasterId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Meeting_Minutes_Master_Tbl (
        CustomerType, CustomerId, MeetingDate, MeetingTime,
        MeetingPlace, MeetingAgenda, MeetingDecision,
        ClientAttendees, HostAttendees
    )
    VALUES (
        @CustomerType, @CustomerId, @MeetingDate, @MeetingTime,
        @MeetingPlace, @MeetingAgenda, @MeetingDecision,
        @ClientAttendees, @HostAttendees
    );
    
    SET @MasterId = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE Meeting_Minutes_Details_Save_SP
    @MasterId INT,
    @ProductServiceId INT,
    @Quantity INT,
    @Unit NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Meeting_Minutes_Details_Tbl (
        MasterId, ProductServiceId, Quantity, Unit
    )
    VALUES (
        @MasterId, @ProductServiceId, @Quantity, @Unit
    );
END;
GO

