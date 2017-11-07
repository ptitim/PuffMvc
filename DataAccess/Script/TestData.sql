
--Adresses
SET IDENTITY_INSERT [Adresses] ON
MERGE INTO [Adresses] AS TARGET
USING (VALUES
	(1, 'Lyon', 'France', 79, '69003', 'Rue de la république'),
	(2, 'Lyon', 'France', 80, '69006', 'quai Charles De Gaulle'),
	(3, 'Lyon', 'France', 0, '69003', 'Centre Commercial La Part-Dieu')
	)
AS Source ([Id], [City], [Country], [Number], [PostalCode], [Street])
ON TARGET.[Id] = Source.[Id]
WHEN Not matched BY TARGET THEN
INSERT ([Id], [City], [Country], [Number], [PostalCode], [Street])
VALUES ([Id], [City], [Country], [Number], [PostalCode], [Street]);
SET IDENTITY_INSERT [Adresses] OFF
GO


SET IDENTITY_INSERT [Cinemas] ON
MERGE INTO [Cinemas] AS TARGET
USING (VALUES
	(1, 1, 'Pathé', 'Bellcour'),
	(2,2,'UGC','Cité international')
	)
AS Source ([Id], [AdressId], [Company], [Name])
ON TARGET.[Id] = Source.[Id]
WHEN Not matched BY TARGET THEN
INSERT ([Id], [AdressId], [Company], [Name])
VALUES ([Id], [AdressId], [Company], [Name]);
SET IDENTITY_INSERT [Cinemas] OFF
GO

SET IDENTITY_INSERT [Movies] ON
MERGE INTO [Movies] AS TARGET
USING (VALUES
	(1, 'Thor : Ragnarok', 0, 'Taika waititi', '25/10/2017', '02.10.00'),
	(2, 'Carbonne', 0, 'Olivier Marchal', '19/18/2017', '01:44:00'),
	(3, 'Geostorm', 0, 'Dean Delvin', '11/10/2017', '01:47:00')
	)
AS Source ([Id], [Name], [PG], [Real], [ReleaseDate], [TimeLength])
ON TARGET.[Id] = Source.[Id]
WHEN Not matched BY TARGET THEN
INSERT  ([Id], [Name], [PG], [Real], [ReleaseDate], [TimeLength])
VALUES  ([Id], [Name], [PG], [Real], [ReleaseDate], [TimeLength]);
SET IDENTITY_INSERT [Movies] OFF
GO