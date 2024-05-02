--Creating a database
CREATE DATABASE Virtual_Art_Gallery

--Accessing the database
USE Virtual_Art_Gallery

--Creating the Artists table
CREATE TABLE Artists (
ArtistID INT PRIMARY KEY,
[Name] VARCHAR(255) NOT NULL,
Biography TEXT,
Nationality VARCHAR(100))

-- Creating the Categories table
CREATE TABLE Categories (
CategoryID INT PRIMARY KEY,
[Name] VARCHAR(100) NOT NULL)

-- Creating the Artworks table
CREATE TABLE Artworks (
ArtworkID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
ArtistID INT,
CategoryID INT,
[Year] INT,
[Description] TEXT,
ImageURL VARCHAR(255),
FOREIGN KEY (ArtistID) REFERENCES Artists (ArtistID),
FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID))

-- Creating the Exhibitions table
CREATE TABLE Exhibitions (
ExhibitionID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
StartDate DATE,
EndDate DATE,
[Description] TEXT)

-- Creating a table to associate artworks with exhibitions
CREATE TABLE ExhibitionArtworks (
ExhibitionID INT,
ArtworkID INT,
PRIMARY KEY (ExhibitionID, ArtworkID),
FOREIGN KEY (ExhibitionID) REFERENCES Exhibitions (ExhibitionID),
FOREIGN KEY (ArtworkID) REFERENCES Artworks (ArtworkID))

-- Insert sample data into the Artists table
INSERT INTO Artists (ArtistID, [Name], Biography, Nationality) VALUES
(1, 'Pablo Picasso', 'Renowned Spanish painter and sculptor.', 'Spanish'),
(2, 'Vincent van Gogh', 'Dutch post-impressionist painter.', 'Dutch'),
(3, 'Leonardo da Vinci', 'Italian polymath of the Renaissance.', 'Italian')

-- Insert sample data into the Categories table
INSERT INTO Categories (CategoryID, [Name]) VALUES
 (1, 'Painting'),
 (2, 'Sculpture'),
 (3, 'Photography')

-- Insert sample data into the Artworks table
INSERT INTO Artworks (ArtworkID, Title, ArtistID, CategoryID, [Year], [Description], ImageURL) VALUES
 (1, 'Starry Night', 2, 1, 1889, 'A famous painting by Vincent van Gogh.', 'starry_night.jpg'),
 (2, 'Mona Lisa', 3, 1, 1503, 'The iconic portrait by Leonardo da Vinci.', 'mona_lisa.jpg'),
 (3, 'Guernica', 1, 1, 1937, 'Pablo Picasso powerful anti-war mural.', 'guernica.jpg')

-- Insert sample data into the Exhibitions table
INSERT INTO Exhibitions (ExhibitionID, Title, StartDate, EndDate, [Description]) VALUES
 (1, 'Modern Art Masterpieces', '2023-01-01', '2023-03-01', 'A collection of modern art masterpieces.'),
 (2, 'Renaissance Art', '2023-04-01', '2023-06-01', 'A showcase of Renaissance art treasures.')

-- Insert artworks into exhibitions
INSERT INTO ExhibitionArtworks (ExhibitionID, ArtworkID) VALUES
 (1, 1),
 (1, 2),
 (1, 3),
 (2, 2)

/* 1. Retrieve the names of all artists along with the number of artworks they have in the gallery, and
list them in descending order of the number of artworks*/
SELECT A.ArtistID,A.[Name],COUNT(W.ArtistID) AS Number_of_artworks
FROM Artists A LEFT JOIN Artworks W
ON A.ArtistID=W.ArtistID
GROUP BY A.ArtistID,A.[Name]
ORDER BY Number_of_artworks DESC

/* 2. List the titles of artworks created by artists from 'Spanish' and 'Dutch' nationalities, and order
them by the year in ascending order*/
SELECT A.[Name],A.Nationality,W.Title AS Artwork_title,W.[Year]
FROM Artists A JOIN Artworks W
ON A.ArtistID=W.ArtistID
WHERE A.Nationality IN ('Spanish','Dutch')
ORDER BY YEAR([Year]) 

/*3. Find the names of all artists who have artworks in the 'Painting' category, and the number of
artworks they have in this category*/
SELECT A.[Name],C.[Name],
COUNT(W.ArtistID) AS Number_of_artworks
FROM Artists A JOIN Artworks W
ON A.ArtistID=W.ArtistID JOIN
Categories C
ON W.CategoryID=C.CategoryID
GROUP BY A.[Name],C.[Name]
HAVING C.[Name]='Painting'

/*4. List the names of artworks from the 'Modern Art Masterpieces' exhibition, along with their
artists and categories*/
SELECT W.Title,A.[Name],E.Title
FROM Exhibitions E JOIN ExhibitionArtworks EA
ON E.ExhibitionID=EA.ExhibitionID
JOIN Artworks W ON EA.ArtworkID=W.ArtworkID
JOIN Artists A
ON W.ArtistID=A.ArtistID
WHERE E.Title='Modern Art Masterpieces'

/*5. Find the artists who have more than two artworks in the gallery*/
SELECT A.[Name], COUNT(EA.ArtworkID) AS Number_of_artworks
FROM Artists A JOIN Artworks W
ON W.ArtistID=A.ArtistID
JOIN ExhibitionArtworks EA 
ON W.ArtworkID=EA.ArtworkID
GROUP BY A.[Name]
HAVING COUNT(EA.ArtworkID)>2

/*6. Find the titles of artworks that were exhibited in both 'Modern Art Masterpieces' and
'Renaissance Art' exhibitions*/
SELECT W.Title,E.Title
FROM ExhibitionArtworks EA RIGHT JOIN Exhibitions E
ON EA.ExhibitionID=E.ExhibitionID
JOIN Artworks W
ON EA.ArtworkID =W.ArtworkID
WHERE E.Title IN('Modern Art Masterpieces','Renaissance Art')

/*7. Find the total number of artworks in each category*/SELECT C.[Name],COUNT(W.ArtworkID) AS number_of_artworksFROM Categories C LEFT JOIN Artworks WON C.CategoryID=W.CategoryIDGROUP BY C.[Name]
/*8. List artists who have more than 3 artworks in the gallery*/
SELECT A.[Name],COUNT(EA.ArtworkID) AS Number_of_artworks
FROM ExhibitionArtworks EA JOIN Artworks W
ON EA.ArtworkID=W.ArtworkID
JOIN Artists A
ON W.ArtistID=A.ArtistID
GROUP BY A.[Name]
HAVING COUNT(EA.ArtworkID)>3

/*9. Find the artworks created by artists from a specific nationality (e.g., Spanish)*/
SELECT W.ArtworkID,W.Title,A.[Name],A.Nationality
FROM Artists A JOIN Artworks W
ON A.ArtistID=W.ArtistID
WHERE A.Nationality='Spanish'

/*10. List exhibitions that feature artwork by both Vincent van Gogh and Leonardo da Vinci*/
SELECT EA.ExhibitionID,A.[Name],E.Title
FROM ExhibitionArtworks EA JOIN Exhibitions E
ON E.ExhibitionID=EA.ExhibitionID
JOIN Artworks W
ON EA.ArtworkID=W.ArtworkID
JOIN Artists A
ON W.ArtistID=A.ArtistID
WHERE A.[Name] IN ('Vincent van Gogh','Leonardo da Vinci')

/*11. Find all the artworks that have not been included in any exhibition*/SELECT ArtworkID,TitleFROM Artworks WHERE ArtworkID NOT IN (SELECT exhibitionID FROM ExhibitionArtworks)
/*12. List artists who have created artworks in all available categories*/
INSERT INTO Artworks VALUES(4,'Geldautomat',1,3,1809,'A photography of lights','light.jpg')
INSERT INTO Artworks VALUES(5,'Birds',1,2,1856,'A sculpture with birds','sculpture.jpg')

SELECT A.[Name],C.[Name],W.Title
FROM Categories C RIGHT JOIN Artworks W
ON W.CategoryID=C.CategoryID
JOIN Artists A
ON W.ArtistID=A.ArtistID
WHERE C.CategoryID = 
ALL(SELECT CategoryID FROM Categories)

/*13. List the total number of artworks in each category*/
SELECT C.CategoryID,C.[Name],COUNT(W.ArtworkID) AS Number_of_artworks
FROM Artworks W JOIN Categories C
ON W.CategoryID=C.CategoryID
GROUP BY C.CategoryID,C.[Name]

/*14. Find the artists who have more than 2 artworks in the gallery*/
SELECT A.[Name],COUNT(EA.ArtworkID) AS Number_of_artworks
FROM ExhibitionArtworks EA JOIN Artworks W
ON EA.ArtworkID=W.ArtworkID
JOIN Artists A 
ON W.ArtistID=A.ArtistID
GROUP BY A.[Name]
HAVING COUNT(EA.ArtworkID)>2

/*15. List the categories with the average year of artworks they contain, only for categories with more
than 1 artwork*/
SELECT C.[Name],AVG(W.[Year]) AS Avg_year
FROM Categories C JOIN Artworks W
ON C.CategoryID=W.CategoryID
GROUP BY C.[Name],W.CategoryID
HAVING COUNT(W.CategoryID) > 1

/*16. Find the artworks that were exhibited in the 'Modern Art Masterpieces' exhibition*/SELECT E.ExhibitionID,E.Title,W.TitleFROM Exhibitions E JOIN ExhibitionArtworks EAON E.ExhibitionID=EA.ExhibitionIDJOIN Artworks WON EA.ArtworkID=W.ArtworkIDWHERE E.Title='Modern Art Masterpieces'

/*17. Find the categories where the average year of artworks is greater than the average year of all
artworks*/
SELECT C.CategoryID,C.[Name],AVG(W.[Year]) AS Avg_year
FROM Categories C JOIN Artworks W
ON C.CategoryID=W.CategoryID
GROUP BY C.CategoryID,C.[Name],W.[Year]
HAVING AVG(W.[Year]) < W.[Year]

/*18. List the artworks that were not exhibited in any exhibition*/
SELECT ArtworkID,Title
FROM Artworks 
WHERE ArtworkID NOT IN 
(SELECT ArtworkID FROM ExhibitionArtworks)

/*19. Show artists who have artworks in the same category as "Mona Lisa*/
SELECT A.[Name],W.Title
FROM Artists A JOIN Artworks W
ON A.ArtistID=W.ArtistID
WHERE W.CategoryID IN (SELECT CategoryID FROM Artworks
WHERE Title='Mona Lisa')

/*20. List the names of artists and the number of artworks they have in the gallery*/
SELECT A.[Name],COUNT(EA.ArtworkID) AS Number_of_artworks
FROM ExhibitionArtworks EA JOIN Artworks W 
ON EA.ArtworkID=W.ArtworkID
JOIN Artists A 
ON W.ArtistID=A.ArtistID
GROUP BY A.[Name]

