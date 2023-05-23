USE [master]
GO

IF db_id('FITQUEST') IS NULL
  CREATE DATABASE [FITQUEST]
GO
USE [FITQUEST]
GO

DROP TABLE IF EXISTS [challengeCheckIn];
DROP TABLE IF EXISTS [leaderBoard];
DROP TABLE IF EXISTS [userChallenges];
DROP TABLE IF EXISTS [Challenges];
DROP TABLE IF EXISTS [User];



CREATE TABLE [User] (
  [id]  int PRIMARY KEY identity NOT NULL,
  [userName] nvarchar(255) NOT NULL,
  [email] nvarchar(255) NOT NULL,
  [imgUrl] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Challenges] (
  [id]  int PRIMARY KEY identity NOT NULL,
  [title] nvarchar(255) NOT NULL,
  [tier] int
)
GO

CREATE TABLE [userChallenges] (
  [id]  int PRIMARY KEY identity NOT NULL,
  [userId] int,
  [challengeId] int,
  [achieved] bit
)
GO

CREATE TABLE [leaderBoard] (
  [id]  int PRIMARY KEY identity NOT NULL,
  [challengeId] int
)
GO

CREATE TABLE [challengeCheckIn] (
  [id]  int PRIMARY KEY identity NOT NULL,
  [date] date,
  [userChallengesId] int,
  [successful] bit
)
GO

ALTER TABLE [userChallenges] ADD FOREIGN KEY ([userId]) REFERENCES [User] ([id])
GO

ALTER TABLE [userChallenges] ADD FOREIGN KEY ([challengeId]) REFERENCES [Challenges] ([id])
GO

ALTER TABLE [Leaderboard] ADD FOREIGN KEY ([challengeId]) REFERENCES [Challenges] ([id])
GO

ALTER TABLE [challengeCheckIn] ADD FOREIGN KEY ([userChallengesId]) REFERENCES [userChallenges] ([id])
GO

SET IDENTITY_INSERT [User] ON
  INSERT INTO [User] ([id], userName, email,imgUrl) 
  VALUES 
  (1,'Chase', 'CBurnett@test.com', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Windows_10_Default_Profile_Picture.svg/1200px-Windows_10_Default_Profile_Picture.svg.png'),
  (2,'Kate', 'KBurnett@test.com', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Windows_10_Default_Profile_Picture.svg/1200px-Windows_10_Default_Profile_Picture.svg.png'),
  (3,'Wesley', 'WBurnett@test.com', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Windows_10_Default_Profile_Picture.svg/1200px-Windows_10_Default_Profile_Picture.svg.png'),
  (4,'Cassidy', 'COBurnett@test.com', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Windows_10_Default_Profile_Picture.svg/1200px-Windows_10_Default_Profile_Picture.svg.png')
  SET IDENTITY_INSERT [User] OFF

  SET IDENTITY_INSERT [Challenges] ON
  INSERT INTO [Challenges] ([id], title, tier) 
  VALUES 
  (1,'Eat 1G of Protien per pound of Ideal-Bodyweight everyday for 30 days', 1),
  (2,'Walk 10,000 steps a day for 30 days', 1),
  (3,'Get 8 hours sleep a night for 30 days', 1),
  (4,'Lift weights 3x a week for 4 consecutive weeks',1),
  (5, '100 Kettlebell swings a day for 60 days ', 2),
  (6, 'Eat at a caloric deficet for 60 days', 2),
  (7, 'Workout 4x a week for 8 consecutive weeks', 2),
  (8, '500M Row (sub 1:30 Male, sub 1:45 Female)',2),
  (9, '10 Turkish Getups in 10 minutes (32KG Male, 24KG Female)', 3),
  (10, '2000M Row (sub 7min Male, 7:30 Female)',3),
  (11, 'Unassisted Pullups x 10 reps',3),
  (12, 'Bench Press Bodyweight X 10 reps',3)
  SET IDENTITY_INSERT [Challenges] OFF

   SET IDENTITY_INSERT [userChallenges] ON
  INSERT INTO [userChallenges] ([id], [userId], [challengeId],[achieved]) 
  VALUES 
  (1,1,5,1),
  (2,1,8,1),
  (3,1,9,1),
  (4,1,10,1),
  (5,1,11,1),
  (6,1,12,1),
  (7,1,3,0),
  (8,2,4,1),
  (9,2,6,1),
  (10,2,3,1),
  (11,2,12,0),
  (12,3,3,1),
  (13,3,1,1),
  (14,4,3,1),
  (15,4,1,1)
  SET IDENTITY_INSERT [userChallenges] OFF

    SET IDENTITY_INSERT [challengeCheckIn] ON
  INSERT INTO [challengeCheckIn] ([id], date, [userChallengesId],[successful]) 
  VALUES
 (1, '4/7/2023', 1, 1),
(2, '10/10/2022', 2, 1),
(3, '5/26/2022', 3, 1),
(4, '4/3/2023', 4, 1),
(5, '8/23/2022', 5, 1),
(6, '11/14/2022', 6, 1),
(7, '2/10/2023', 7, 0),
(8, '6/23/2022', 8, 1),
(9, '1/10/2023', 9, 1),
(10, '11/11/2022', 10, 1),
(11, '5/20/2023', 11, 0),
(12, '5/11/2023', 12, 1),
(13, '9/9/2022', 13, 1),
(14, '5/16/2023', 14, 1),
(15, '12/6/2022', 15, 1)
SET IDENTITY_INSERT [challengeCheckIn] OFF


SET IDENTITY_INSERT [leaderBoard] ON
  INSERT INTO [leaderBoard] ([id],[challengeId]) 
  VALUES
  (1,5),
  (2,8),
  (3,9),
  (4,10),
  (5,11),
  (6,12),
  (7,3),
  (8,4),
  (9,6),
  (10,3),
  (11,12),
  (12,3),
  (13,1),
  (14,3),
  (15,1)
SET IDENTITY_INSERT [leaderBoard] OFF

