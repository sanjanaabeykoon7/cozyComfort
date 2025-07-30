CREATE TABLE Stock (
    StockID INT PRIMARY KEY IDENTITY(1,1),
    BlanketID INT NOT NULL,
    BlanketName NVARCHAR(100) NOT NULL,
    OwnerID INT NOT NULL,
    Quantity INT NOT NULL,
    LastUpdated DATETIME NOT NULL
);

CREATE TABLE StockRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    DistributorID INT NOT NULL,
    DistributorName NVARCHAR(100) NOT NULL,
    BlanketID INT NOT NULL,
    BlanketName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    RequestDate DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL
);