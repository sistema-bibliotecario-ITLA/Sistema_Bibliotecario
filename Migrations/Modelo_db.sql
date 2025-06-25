
CREATE DATABASE LibrarySystem;
GO

USE LibrarySystem;
GO

-- Table Users
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Role VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL
);

-- Table Authors
CREATE TABLE Authors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL
);

-- Table Genres
CREATE TABLE Genres (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL
);

-- Table Books
CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AuthorId INT NOT NULL,
    GenreId INT NOT NULL,
    Title VARCHAR(150) NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    CONSTRAINT FK_Books_Genres FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);

-- Table Notifications
CREATE TABLE Notifications (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    BookId INT NOT NULL,
    CONSTRAINT FK_Notifications_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Notifications_Books FOREIGN KEY (BookId) REFERENCES Books(Id)
);

-- Table Loans
CREATE TABLE Loans (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ReturnDate DATE NOT NULL,
    RequestDate DATE NOT NULL,
    UserId INT NOT NULL,
    BookId INT NOT NULL,
    CONSTRAINT FK_Loans_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Loans_Books FOREIGN KEY (BookId) REFERENCES Books(Id)
);

-- Table Reservations
CREATE TABLE Reservations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    BookId INT NOT NULL,
    UserId INT NOT NULL,
    CONSTRAINT FK_Reservations_Books FOREIGN KEY (BookId) REFERENCES Books(Id),
    CONSTRAINT FK_Reservations_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);