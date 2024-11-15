DELETE FROM [dbo].[Users]
GO
DELETE FROM [dbo].[TvShows]
GO
SET IDENTITY_INSERT [dbo].[TvShows] ON 
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (1, N'Breaking Bad', 1, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various interior and exterior settings', N'R')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (2, N'Game of Thrones', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'60 minutes or longer', N'Various interior and exterior settings', N'18A')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (3, N'The Office', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Office interior settings', N'PG')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (4, N'Friends', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Apartment interior settings', N'PG')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (5, N'Stranger Things', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various interior and exterior settings', N'14A')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (6, N'The Mandalorian', 1, N'Fiction', N'Series', N'Narrative units with continuity', N'30-40 minutes', N'Various interior and exterior settings', N'PG')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (7, N'Black Mirror', 0, N'Fiction', N'Series', N'Standalone narrative units', N'50-60 minutes', N'Various settings, futuristic and dystopian', N'18A')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (8, N'Rick and Morty', 1, N'Animation', N'Animation Series', N'Individual narrative units', N'20-30 minutes', N'Various sci-fi settings', N'R')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (9, N'The Crown', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Historical settings, interior and exterior', N'PG')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (10, N'Brooklyn Nine-Nine', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Police station interior settings', N'PG')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (11, N'Sherlock', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'90 minutes', N'Modern London settings', N'14A')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (12, N'Chernobyl', 1, N'Docudrama', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Historical settings', N'18A')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (13, N'House of Cards', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Political interior settings', N'18A')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (14, N'The Simpsons', 1, N'Animation', N'Animation Series', N'Individual narrative units', N'20-30 minutes', N'Springfield settings', N'PG')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification]) VALUES (15, N'Narcos', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various settings, interior and exterior', N'18A')
GO
SET IDENTITY_INSERT [dbo].[TvShows] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (1, N'John Doe', N'john.doe@example.com', N'$2a$12$XkT93VhImW0yZH4g1rKMVeaJ.v/OuvI5Kq/m3GFvMK/9sR77oWOVu')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (2, N'Jane Smith', N'jane.smith@example.com', N'$2a$12$OgKtxT3QJKL8sRysu.HI2OeqbZ8H2vZ3bN.O2QvxBnm/J2Gs9Q52i')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (3, N'Michael Johnson', N'michael.johnson@example.com', N'$2a$12$9tb5Kv1D8ph.BC0GjFZDiOvw1jD2PzWqGiJSmS6Sx6U2ZY5Y53F.e')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (4, N'Emily Davis', N'emily.davis@example.com', N'$2a$12$P0ZhRsDWcU2P8TdpHoxbJ.FF5bFfbUVThK/JN4rIbJvlAwnp48Tk2')
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (5, N'Chris Brown', N'chris.brown@example.com', N'$2a$12$QZ8wUmYLTKaEkD6VojS8EO1qAFZ7g0UsEkt9xKgEvTAn9cdEQpP0a')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
