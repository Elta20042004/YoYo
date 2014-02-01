CREATE TABLE [dbo].[Product] (
    [Name]        NVARCHAR (50)   NULL,
    [Price]       INT             NULL,
    [Color]       INT             NOT NULL,
    [Picture]     NVARCHAR (250)  NULL,
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [CategoryId]  INT             NULL,
    [Description] NVARCHAR (2096) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([id] ASC)
);

