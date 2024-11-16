CREATE TABLE [dbo].[TvShows] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [Favorite]       BIT            NOT NULL,
    [Content]        NVARCHAR (255) NOT NULL,
    [Format]         NVARCHAR (255) NOT NULL,
    [Episodes]       NVARCHAR (255) NOT NULL,
    [Duration]       NVARCHAR (50)  NOT NULL,
    [Scenarios]      NVARCHAR (255) NOT NULL,
    [Classification] NVARCHAR (50)  NOT NULL,
    [Image]          VARCHAR (800)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

