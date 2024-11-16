/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [TVShowData]
GO
DELETE FROM [dbo].[TvShows]
GO
SET IDENTITY_INSERT [dbo].[TvShows] ON 
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (1, N'Breaking Bad', 1, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various interior and exterior settings', N'R', N'https://hipermediaciones.com/wp-content/uploads/2013/10/bbs5-1600x1200-pre-e.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (2, N'Game of Thrones', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'60 minutes or longer', N'Various interior and exterior settings', N'18A', N'https://t.ctcdn.com.br/wQkKKDBe1HpwEmbJ7ADMfLznS_Q=/990x557/smart/i350335.jpeg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (3, N'The Office', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Office interior settings', N'PG', N'https://images.reporteindigo.com/wp-content/uploads/2023/09/the-office-reboot.png')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (4, N'Friends', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Apartment interior settings', N'PG', N'https://beam-images.warnermediacdn.com/BEAM_LWM_DELIVERABLES/52dae4c7-2ab1-4bb9-ab1c-8100fd54e2f9/24ec1000-8a0f-4ba4-be79-8c7a5eb288ee?host=wbd-images.prod-vod.h264.io&partner=beamcom&w=500')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (5, N'Stranger Things', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various interior and exterior settings', N'14A', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQWN8AkViFHvaTTH0C7fRRJCnLiYL3CtpbTdw&s')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (6, N'The Mandalorian', 1, N'Fiction', N'Series', N'Narrative units with continuity', N'30-40 minutes', N'Various interior and exterior settings', N'PG', N'https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/4826879538A92B52B2B316E2E9D5A1BEC5C774C094FF9F96E3265E0D4220E3E6/scale?width=1200&aspectRatio=1.78&format=webp')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (7, N'Black Mirror', 0, N'Fiction', N'Series', N'Standalone narrative units', N'50-60 minutes', N'Various settings, futuristic and dystopian', N'18A', N'https://media.gq.com.mx/photos/66f06cc998463deeaf2a4854/16:9/w_2992,h_1683,c_limit/BM.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (8, N'Rick and Morty', 1, N'Animation', N'Animation Series', N'Individual narrative units', N'20-30 minutes', N'Various sci-fi settings', N'R', N'https://wallpapers.com/images/featured/imagenes-de-rick-and-morty-b3e2pq02sb2fuvy3.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (9, N'The Crown', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Historical settings, interior and exterior', N'PG', N'https://occ-0-8407-1722.1.nflxso.net/dnm/api/v6/E8vDc_W8CLv7-yMQu8KMEC7Rrr8/AAAABRa2Ojolth_4mw7fNztaPZJHe6V0oyMCD-NF0By0ddFyNQRb7NdWoHl3BPwSXVS3dbgG-jeiIaKzqAxqcpR_BGOHghInV3iHy6pY.jpg?r=f43')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (10, N'Brooklyn Nine-Nine', 1, N'Fiction', N'Comedy', N'Individual narrative units', N'20-30 minutes', N'Police station interior settings', N'PG', N'https://media.revistagq.com/photos/5d47d3043b83c000083d3ba1/16:9/w_2560%2Cc_limit/B99%25201.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (11, N'Sherlock', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'90 minutes', N'Modern London settings', N'14A', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQB3abubwqH5tkoKV-fXq6TatvAr4r9m5j_Pg&s')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (12, N'Chernobyl', 1, N'Docudrama', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Historical settings', N'18A', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaLopBI8RHM6FiXOhepa9al9cZqwBQEDSN3g&s')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (13, N'House of Cards', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Political interior settings', N'18A', N'https://i.ytimg.com/vi/jNTgPxHKlbo/maxresdefault.jpg')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (14, N'The Simpsons', 1, N'Animation', N'Animation Series', N'Individual narrative units', N'20-30 minutes', N'Springfield settings', N'PG', N'https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/0E97E967C1744CB09006B7A86EEB05F4B070665074177C32E159BEBE22D22D7C/scale?width=1200&aspectRatio=1.78&format=webp')
GO
INSERT [dbo].[TvShows] ([Id], [Name], [Favorite], [Content], [Format], [Episodes], [Duration], [Scenarios], [Classification], [Image]) VALUES (15, N'Narcos', 0, N'Fiction', N'Series', N'Narrative units with continuity', N'50-60 minutes', N'Various settings, interior and exterior', N'18A', N'https://i.ytimg.com/vi/iiuW754iw7o/maxresdefault.jpg')
GO
SET IDENTITY_INSERT [dbo].[TvShows] OFF
GO