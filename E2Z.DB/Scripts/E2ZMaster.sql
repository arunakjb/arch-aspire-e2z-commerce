-- Create Database
CREATE DATABASE E2ZDB;
GO

USE E2ZDB;
GO

-- =========================
-- Products Table
-- =========================
CREATE TABLE Products (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Category NVARCHAR(100),
    ProductImageId INT NULL,
    Features NVARCHAR(MAX),
    IsReturnApplicable BIT DEFAULT 0,
    CreationTime DATETIME2 DEFAULT GETDATE()
);

-- =========================
-- ProductImages Table
-- =========================
CREATE TABLE ProductImages (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    BlobUrl NVARCHAR(500) NOT NULL,
    LastUpdated DATETIME2 DEFAULT GETDATE(),
    ProductId INT NOT NULL,
    CONSTRAINT FK_ProductImages_Products FOREIGN KEY (ProductId) REFERENCES Products(ID) ON DELETE CASCADE
);

-- =========================
-- UserProfile Table
-- =========================
CREATE TABLE UserProfile (
    UserId UNIQUEIDENTIFIER PRIMARY KEY, -- maps to Azure AD B2C Object ID
    Name NVARCHAR(200),
    Gender NVARCHAR(50),
    Preferences NVARCHAR(MAX),
    Email NVARCHAR(255) UNIQUE,
    Address NVARCHAR(MAX),
    CreationTime DATETIME2 DEFAULT GETDATE(),
    IsLoggedIn BIT DEFAULT 0,
    LastLoggedInTime DATETIME2
);

-- =========================
-- UserFavorites Table
-- =========================
CREATE TABLE UserFavorites (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    ProductId INT NOT NULL,
    CreationTime DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT FK_UserFavorites_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId),
    CONSTRAINT FK_UserFavorites_Products FOREIGN KEY (ProductId) REFERENCES Products(ID)
);

-- =========================
-- UserRecentActivity Table
-- =========================
CREATE TABLE UserRecentActivity (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    ProductClicked INT NOT NULL,
    LastVisitedTime DATETIME2 DEFAULT GETDATE(),
    VisitedOccurences INT DEFAULT 1,
    CONSTRAINT FK_UserRecentActivity_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId),
    CONSTRAINT FK_UserRecentActivity_Products FOREIGN KEY (ProductClicked) REFERENCES Products(ID)
);

-- =========================
-- UserReviews Table
-- =========================
CREATE TABLE UserReviews (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comments NVARCHAR(MAX),
    UserImageId INT NULL,
    UserId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_UserReviews_Products FOREIGN KEY (ProductId) REFERENCES Products(ID),
    CONSTRAINT FK_UserReviews_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId)
);

-- =========================
-- UserReviewImages Table
-- =========================
CREATE TABLE UserReviewImages (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    BlobUrl NVARCHAR(500) NOT NULL,
    ReviewId INT NOT NULL,
    CONSTRAINT FK_UserReviewImages_UserReviews FOREIGN KEY (ReviewId) REFERENCES UserReviews(ID) ON DELETE CASCADE
);

-- =========================
-- Orders Table
-- =========================
CREATE TABLE Orders (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Quantity INT NOT NULL,
    Rating INT NULL,
    OriginalPrice DECIMAL(10,2),
    DiscountedPrice DECIMAL(10,2),
    TransactionId INT NOT NULL,
    ProductId INT NOT NULL,
    CONSTRAINT FK_Orders_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId),
    CONSTRAINT FK_Orders_Products FOREIGN KEY (ProductId) REFERENCES Products(ID)
);

-- =========================
-- Transactions Table
-- =========================
CREATE TABLE Transactions (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    PaymentMode NVARCHAR(50),
    DeliveryId INT NOT NULL,
    AmountPaid DECIMAL(10,2),
    DiscountedAmount DECIMAL(10,2),
    IsTransactionSuccess BIT DEFAULT 1,
    TransactionTime DATETIME2 DEFAULT GETDATE(),
    InvoiceNumber NVARCHAR(100),
    CONSTRAINT FK_Transactions_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId)
);

-- =========================
-- DeliveryDetails Table
-- =========================
CREATE TABLE DeliveryDetails (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    DeliveryAddress NVARCHAR(MAX),
    DeliveryInstructions NVARCHAR(MAX),
    IsDelivered BIT DEFAULT 0,
    IsCashOnDelivery BIT DEFAULT 0,
    ReturnProduct BIT DEFAULT 0,
    CONSTRAINT FK_DeliveryDetails_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId)
);

-- =========================
-- CartDetails Table
-- =========================
CREATE TABLE CartDetails (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UserId UNIQUEIDENTIFIER NOT NULL,
    IsBought BIT DEFAULT 0,
    IsDeleted BIT DEFAULT 0,
    CONSTRAINT FK_CartDetails_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId),
    CONSTRAINT FK_CartDetails_Products FOREIGN KEY (ProductId) REFERENCES Products(ID)
);

-- =========================
-- ReturnDetails Table
-- =========================
CREATE TABLE ReturnDetails (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Reason NVARCHAR(MAX),
    IsCancelled BIT DEFAULT 0,
    DeliveryId INT NOT NULL,
    CONSTRAINT FK_ReturnDetails_UserProfile FOREIGN KEY (UserId) REFERENCES UserProfile(UserId),
    CONSTRAINT FK_ReturnDetails_Products FOREIGN KEY (ProductId) REFERENCES Products(ID),
    CONSTRAINT FK_ReturnDetails_DeliveryDetails FOREIGN KEY (DeliveryId) REFERENCES DeliveryDetails(ID)
);