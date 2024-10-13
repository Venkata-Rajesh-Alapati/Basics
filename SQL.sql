CREATE DATABASE Computer
GO
 
USE Computer
GO
 
CREATE SCHEMA ComputerSchema
GO
 
CREATE TABLE ComputerSchema.Computer(
    ComputerId INT IDENTITY(1,1) PRIMARY KEY,
    ModelName NVARCHAR(50),
    Storage INT,
    Price DECIMAL(18,4),
    New BIT,
    ReleaseDate DATE,
);