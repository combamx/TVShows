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