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
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (1, N'Omar Cortes', N'omar.cortes@example.com', N'$2a$12$XkT93VhImW0yZH4g1rKMVeaJ.v/OuvI5Kq/m3GFvMK/9sR77oWOVu')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO